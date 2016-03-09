using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAcsrfComponent
    {
        /* VIEWS */
        IApiResult GetOptionTokenNames();

        /* ACTIONS */
        IApiResult AddOptionToken(string apikey, string name);
        IApiResult RemoveOptionToken(string apikey, string name);
    }

    internal class AcsrfComponent : IAcsrfComponent
    {
        private const string Component = "acsrf";

        private readonly IZapClient _zapClient;

        public AcsrfComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        /// <summary>
        /// Lists the names of all anti CSRF tokens
        /// </summary>
        /// <returns>List of anti CSRF tokens</returns>
        public IApiResult GetOptionTokenNames()
        {
            return _zapClient.CallApi(Component, "view", "optionTokensNames");
        }

        /// <summary>
        /// Adds an anti CSRF token with the given name, enabled by default
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="name">Name of the CSRF token</param>
        /// <returns>Result of the action</returns>
        public IApiResult AddOptionToken(string apikey, string name)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", name);
            return _zapClient.CallApi(Component, "action", "addOptionToken", parameters);
        }

        /// <summary>
        /// Removes the anti CSRF token with the given name
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="name">Name of the CSRF token</param>
        /// <returns>Result of the action</returns>
        public IApiResult RemoveOptionToken(string apikey, string name)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", name);
            return _zapClient.CallApi(Component, "action", "removeOptionToken", parameters);
        }
    }
}
