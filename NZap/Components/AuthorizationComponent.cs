using System.Collections.Generic;
using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAuthorizationComponent
    {
        /* VIEWS */
        IApiResult GetAuthorizationDetectionMethod(string contextId);

        /* ACTIONS */
        IApiResult SetBasicAuthorizationDetectionMethod(string apikey, string contextId, IDictionary<string, string> parameters = null);
    }

    internal class AuthorizationComponent : IAuthorizationComponent
    {
        private const string Component = "authorization";

        private readonly IZapClient _zapClient;

        public AuthorizationComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        /// <summary>
        /// Obtains all the configuration of the authorization detection method that is currently set for a context.
        /// </summary>
        /// <param name="contextId">Id of the context</param>
        /// <returns>Authorization configuration</returns>
        public IApiResult GetAuthorizationDetectionMethod(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, "view", "getAuthorizationDetectionMethod", parameters);
        }

        /// <summary>
        /// Sets the authorization detection method for a context as one that identifies un-authorized messages based on: the message's status code or a regex pattern in the response's header or body.
        /// Also, whether all conditions must match or just some can be specified via the logicalOperator parameter, which accepts two values: "AND" (default), "OR".
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="contextId">Id of the context</param>
        /// <param name="parameters">List of optional parameters</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetBasicAuthorizationDetectionMethod(string apikey, string contextId, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            parameters.Add("contextId", contextId);
            return _zapClient.CallApi(Component, "action", "setBasicAuthorizationDetectionMethod", parameters);
        }
    }
}
