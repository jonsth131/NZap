using System.Collections.Generic;
using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAuthenticationComponent
    {
        /* VIEWS */
        IApiResult GetAuthenticationMethod(string contextId);
        IApiResult GetAuthenticationMethodConfigParams(string authMethodName);
        IApiResult GetLoggedInIndicator(string contextId);
        IApiResult GetLoggedOutIndicator(string contextId);
        IApiResult GetSupportedAuthenticationMethods();

        /* ACTIONS */
        IApiResult SetAuthenticationMethod(string apikey, string contextId, string authMethodName, string aauthMethodConfigParams = null);
        IApiResult SetLoggedInIndicator(string apikey, string contextId, string loggedInIndicatorRegex);
        IApiResult SetLoggedOutIndicator(string apikey, string contextId, string loggedOutIndicatorRegex);
    }

    public class AuthenticationComponent : IAuthenticationComponent
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
            return _zapClient.CallApi(Component, "view", "getAuthenticationMethod", parameters);
        }

        public IApiResult GetAuthenticationMethodConfigParams(string authMethodName)
        {
            var parameters = new Dictionary<string, string> { { "authMethodName", authMethodName } };
            return _zapClient.CallApi(Component, "view", "getAuthenticationMethodConfigParams", parameters);
        }

        public IApiResult GetLoggedInIndicator(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, "view", "getLoggedInIndicator", parameters);
        }

        public IApiResult GetLoggedOutIndicator(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, "view", "getLoggedOutIndicator", parameters);
        }

        public IApiResult GetSupportedAuthenticationMethods()
        {
            return _zapClient.CallApi(Component, "view", "getSupportedAuthenticationMethods");
        }

        public IApiResult SetAuthenticationMethod(string apikey, string contextId, string authMethodName,
            string aauthMethodConfigParams = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("authMethodName", authMethodName);
            if (aauthMethodConfigParams != null) parameters.Add("aauthMethodConfigParams", aauthMethodConfigParams);
            return _zapClient.CallApi(Component, "action", "setAuthenticationMethod", parameters);
        }

        public IApiResult SetLoggedInIndicator(string apikey, string contextId, string loggedInIndicatorRegex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("loggedInIndicatorRegex", loggedInIndicatorRegex);
            return _zapClient.CallApi(Component, "action", "setLoggedInIndicator", parameters);
        }

        public IApiResult SetLoggedOutIndicator(string apikey, string contextId, string loggedOutIndicatorRegex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("loggedOutIndicatorRegex", loggedOutIndicatorRegex);
            return _zapClient.CallApi(Component, "action", "setLoggedOutIndicator", parameters);
        }
    }
}
