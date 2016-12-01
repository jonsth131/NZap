using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IHttpSessionsComponent
    {
        /* VIEWS */
        IApiResult GetActiveSession(string site);
        IApiResult GetSessionTokens(string site);
        IApiResult GetSessions(string site, string session = null);

        /* ACTIONS */
        IApiResult AddSessionToken(string apikey, string site, string sessionToken);
        IApiResult CreateEmptySession(string apikey, string site, string session = null);
        IApiResult RemoveSession(string apikey, string site, string session);
        IApiResult RemoveSessionToken(string apikey, string site, string sessionToken);
        IApiResult RenameSession(string apikey, string site, string oldSessionName, string newSessionName);
        IApiResult SetActiveSession(string apikey, string site, string session);
        IApiResult SetSessionTokenValue(string apikey, string session, string sessionToken, string tokenValue);
        IApiResult UnsetActiveSession(string apikey, string site);
    }

    internal class HttpSessionsComponent : IHttpSessionsComponent
    {
        private const string Component = "httpSessions";

        private readonly IZapClient _zapClient;

        public HttpSessionsComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetActiveSession(string site)
        {
            var parameters = new Dictionary<string, string> { { "site", site } };
            return _zapClient.CallApi(Component, ActionTypes.View, "activeSession", parameters);
        }

        public IApiResult GetSessionTokens(string site)
        {
            var parameters = new Dictionary<string, string> { { "site", site } };
            return _zapClient.CallApi(Component, ActionTypes.View, "sessionTokens", parameters);
        }

        public IApiResult GetSessions(string site, string session = null)
        {
            var parameters = new Dictionary<string, string> { { "site", site } };
            if (session != null) parameters.Add("session", session);
            return _zapClient.CallApi(Component, ActionTypes.View, "sessions", parameters);
        }

        public IApiResult AddSessionToken(string apikey, string site, string sessionToken)
        {
            return SetSessionToken(apikey, site, sessionToken, "addSessionToken");
        }

        public IApiResult CreateEmptySession(string apikey, string site, string session = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("site", site);
            if (session != null) parameters.Add("session", session);
            return _zapClient.CallApi(Component, ActionTypes.Action, "createEmptySession", parameters);
        }

        public IApiResult RemoveSession(string apikey, string site, string session)
        {
            return SetSession(apikey, site, session, "removeSession");
        }

        public IApiResult RemoveSessionToken(string apikey, string site, string sessionToken)
        {
            return SetSessionToken(apikey, site, sessionToken, "removeSessionToken");
        }

        public IApiResult RenameSession(string apikey, string site, string oldSessionName, string newSessionName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("site", site);
            parameters.Add("oldSessionName", oldSessionName);
            parameters.Add("newSessionName", newSessionName);
            return _zapClient.CallApi(Component, ActionTypes.Action, "renameSession", parameters);
        }

        public IApiResult SetActiveSession(string apikey, string site, string session)
        {
            return SetSession(apikey, site, session, "setActiveSession");
        }

        public IApiResult SetSessionTokenValue(string apikey, string session, string sessionToken, string tokenValue)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("session", session);
            parameters.Add("sessionToken", sessionToken);
            parameters.Add("tokenValue", tokenValue);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setSessionTokenValue", parameters);
        }

        public IApiResult UnsetActiveSession(string apikey, string site)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("site", site);
            return _zapClient.CallApi(Component, ActionTypes.Action, "unsetActiveSession", parameters);
        }

        private IApiResult SetSessionToken(string apikey, string site, string sessionToken, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("site", site);
            parameters.Add("sessionToken", sessionToken);
            return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
        }

        private IApiResult SetSession(string apikey, string site, string session, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("site", site);
            parameters.Add("session", session);
            return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
        }
    }
}
