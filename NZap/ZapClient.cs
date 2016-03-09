using System;
using System.Collections.Generic;
using System.Net;
using NZap.Components;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap
{
    public interface IZapClient
    {
        Protocols Protocol { get; }
        string Host { get; }
        int Port { get; }
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
        string GetApiResult(Uri requestUri);
        IReportResponse CallReportApi(string component, string type, string action, IDictionary<string, string> parameters = null);
    }

    public class ZapClient : IZapClient
    {
        public Protocols Protocol { get; }
        public string Host { get; }
        public int Port { get; }

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

        public ZapClient(string host, int port) : this(host, port, Protocols.http)
        {
        }

        public ZapClient(string host, int port, Protocols protocol)
        {
            Protocol = protocol;
            Host = host;
            Port = port;
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
            var requestUri = UriHelper.BuildZapUri(Host, Port, uri, Protocol, parameters);
            var result = GetApiResult(requestUri);
            return SerializationHelper.DeserializeJsonToApiResult(result);
        }

        public IApiResult CallApi(string component, string type, string action)
        {
            var uri = UriHelper.CreateUriStringFromParameters(component, type, action);
            return CallApi(uri);
        }

        public IApiResult CallApi(string component, string type, string action, IDictionary<string, string> parameters)
        {
            var uri = UriHelper.CreateUriStringFromParameters(component, type, action);
            return CallApi(uri, parameters);
        }

        public string GetApiResult(Uri requestUri)
        {
            string result;
            using (var webClient = new WebClient())
            {
                result = webClient.DownloadString(requestUri);
            }
            return result;
        }

        public IReportResponse CallReportApi(string component, string type, string action, IDictionary<string, string> parameters = null)
        {
            var uriString = UriHelper.CreateUriStringFromParameters(component, type, action, ResponseType.OTHER);
            var requestUri = UriHelper.BuildZapUri(Host, Port, uriString, Protocol, parameters);
            var apiResult = GetApiResult(requestUri);
            return new ReportResponse(apiResult);
        }
    }
}