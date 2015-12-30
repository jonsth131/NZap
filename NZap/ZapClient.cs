﻿using System.Collections.Generic;
using System.Net;
using NZap.Components;
using NZap.Entities;
using NZap.Helpers;

namespace NZap
{
    public interface IZapClient
    {
        IAcsrfComponent Acsrf { get; }
        IAjaxSpiderComponent AjaxSpider { get; }
        IAscanComponent Ascan { get; }
        IAuthenticationComponent Authentication { get; }
        IAuthorizationComponent Authorization { get; }
        IAutoupdateComponent Autoupdate { get; }
        IBreakComponent Break { get; }
        IContextComponent Context { get; }
        ICoreComponent Core { get; }
        IForcedUserComponent ForcedUser { get; }
        IHttpSessionsComponent HttpSessions { get; }
        IParamsComponent Params { get; }
        IPscanComponent Pscan { get; }
        IRevealComponent Reveal { get; }
        IScriptComponent Script { get; }
        ISearchComponent Search { get; }
        ISeleniumComponent Selenium { get; }
        ISessionManagementComponent SessionManagement { get; }
        ISpiderComponent Spider { get; }
        IUsersComponent Users { get; }
        IApiResult CallApi(string uri);
        IApiResult CallApi(string uri, IDictionary<string, string> parameters);
        IApiResult CallApi(string component, string type, string action);
        IApiResult CallApi(string component, string type, string action, IDictionary<string, string> parameters);
    }

    public class ZapClient : IZapClient
    {
        private readonly string _host;
        private readonly int _port;
        private readonly bool _https;

        public IAcsrfComponent Acsrf { get; }
        public IAjaxSpiderComponent AjaxSpider { get; }
        public IAscanComponent Ascan { get; }
        public IAuthenticationComponent Authentication { get; }
        public IAuthorizationComponent Authorization { get; }
        public IAutoupdateComponent Autoupdate { get; }
        public IBreakComponent Break { get; }
        public IContextComponent Context { get; }
        public ICoreComponent Core { get; }
        public IForcedUserComponent ForcedUser { get; }
        public IHttpSessionsComponent HttpSessions { get; }
        public IParamsComponent Params { get; }
        public IPscanComponent Pscan { get; }
        public IRevealComponent Reveal { get; }
        public IScriptComponent Script { get; }
        public ISearchComponent Search { get; }
        public ISeleniumComponent Selenium { get; }
        public ISessionManagementComponent SessionManagement { get; }
        public ISpiderComponent Spider { get; }
        public IUsersComponent Users { get; }

        public ZapClient(string host, int port) : this(host, port, false)
        {
        }

        public ZapClient(string host, int port, bool https)
        {
            _host = host;
            _port = port;
            _https = https;
            Acsrf = new AcsrfComponent(this);
            AjaxSpider = new AjaxSpiderComponent(this);
            Ascan = new AscanComponent(this);
            Authentication = new AuthenticationComponent(this);
            Authorization = new AuthorizationComponent(this);
            Autoupdate = new AutoupdateComponent(this);
            Break = new BreakComponent(this);
            Context = new ContextComponent(this);
            Core = new CoreComponent(this);
            ForcedUser = new ForcedUserComponent(this);
            HttpSessions = new HttpSessionsComponent(this);
            Params = new ParamsComponent(this);
            Pscan = new PscanComponent(this);
            Reveal = new RevealComponent(this);
            Script = new ScriptComponent(this);
            Search = new SearchComponent(this);
            Selenium = new SeleniumComponent(this);
            SessionManagement = new SessionManagementComponent(this);
            Spider = new SpiderComponent(this);
            Users = new UsersComponent(this);
        }

        public IApiResult CallApi(string uri)
        {
            return CallApi(uri, null);
        }

        public IApiResult CallApi(string uri, IDictionary<string, string> parameters)
        {
            var requestUri = UriHelper.BuildZapUri(_host, _port, _https, uri, parameters);
            string result;
            using (var webClient = new WebClient())
            {
                result = webClient.DownloadString(requestUri);
            }
            return SerializationHelper.DeserializeJsonToApiResult(result);
        }

        public IApiResult CallApi(string component, string type, string action)
        {
            var uri = UriHelper.CreateUriStringFromParameters(component, type, action, _host);
            return CallApi(uri);
        }

        public IApiResult CallApi(string component, string type, string action, IDictionary<string, string> parameters)
        {
            var uri = UriHelper.CreateUriStringFromParameters(component, type, action, _host);
            return CallApi(uri, parameters);
        }
    }
}