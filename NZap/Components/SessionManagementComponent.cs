using System.Collections.Generic;
using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface ISessionManagementComponent
    {
        /* VIEWS */
        IApiResult GetSessionManagementMethod(string contextId);
        IApiResult GetSessionManagementMethodConfigParams(string methodName);
        IApiResult GetSupportedSessionManagementMethods();

        /* ACTIONS */
        IApiResult SetSessionManagementMethod(string apikey, string contextId, string methodName, string methodConfigParams = null);
    }

    public class SessionManagementComponent : ISessionManagementComponent
    {
        private const string Component = "sessionManagement";

        private readonly IZapClient _zapClient;

        public SessionManagementComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetSessionManagementMethod(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, "view", "getSessionManagementMethod", parameters);
        }

        public IApiResult GetSessionManagementMethodConfigParams(string methodName)
        {
            var parameters = new Dictionary<string, string> { { "methodName", methodName } };
            return _zapClient.CallApi(Component, "view", "getSessionManagementMethodConfigParams", parameters);
        }

        public IApiResult GetSupportedSessionManagementMethods()
        {
            return _zapClient.CallApi(Component, "view", "getSupportedSessionManagementMethods");
        }

        public IApiResult SetSessionManagementMethod(string apikey, string contextId, string methodName,
            string methodConfigParams = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("methodName", methodName);
            if (methodConfigParams != null) parameters.Add("methodConfigParams", methodConfigParams);
            return _zapClient.CallApi(Component, "action", "setReveal", parameters);
        }
    }
}
