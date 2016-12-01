using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAuthenticationComponent
    {
        /* VIEWS */
        IApiResult GetAuthenticationMethod(string contextId);
        IApiResult GetAuthenticationMethodConfigParams(AuthMethodName authMethodName);
        IApiResult GetLoggedInIndicator(string contextId);
        IApiResult GetLoggedOutIndicator(string contextId);
        IApiResult GetSupportedAuthenticationMethods();

        /* ACTIONS */
        IApiResult SetAuthenticationMethod(string apikey, string contextId, string authMethodName, string aauthMethodConfigParams = null);
        IApiResult SetLoggedInIndicator(string apikey, string contextId, string loggedInIndicatorRegex);
        IApiResult SetLoggedOutIndicator(string apikey, string contextId, string loggedOutIndicatorRegex);
    }

    internal class AuthenticationComponent : IAuthenticationComponent
    {
        private const string Component = "authentication";

        private readonly IZapClient _zapClient;

        public AuthenticationComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetAuthenticationMethod(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "getAuthenticationMethod", parameters);
        }

        public IApiResult GetAuthenticationMethodConfigParams(AuthMethodName authMethodName)
        {
            var parameters = new Dictionary<string, string> { { "authMethodName", authMethodName.ToString() } };
            return _zapClient.CallApi(Component, ActionTypes.View, "getAuthenticationMethodConfigParams", parameters);
        }

        public IApiResult GetLoggedInIndicator(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "getLoggedInIndicator", parameters);
        }

        public IApiResult GetLoggedOutIndicator(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "getLoggedOutIndicator", parameters);
        }

        public IApiResult GetSupportedAuthenticationMethods()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "getSupportedAuthenticationMethods");
        }

        public IApiResult SetAuthenticationMethod(string apikey, string contextId, string authMethodName,
            string aauthMethodConfigParams = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("authMethodName", authMethodName);
            if (aauthMethodConfigParams != null) parameters.Add("aauthMethodConfigParams", aauthMethodConfigParams);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setAuthenticationMethod", parameters);
        }

        public IApiResult SetLoggedInIndicator(string apikey, string contextId, string loggedInIndicatorRegex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("loggedInIndicatorRegex", loggedInIndicatorRegex);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setLoggedInIndicator", parameters);
        }

        public IApiResult SetLoggedOutIndicator(string apikey, string contextId, string loggedOutIndicatorRegex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("loggedOutIndicatorRegex", loggedOutIndicatorRegex);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setLoggedOutIndicator", parameters);
        }
    }
}
