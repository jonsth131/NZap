using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IRevealComponent
    {
        /* VIEWS */
        IApiResult GetReveal();

        /* ACTIONS */
        IApiResult SetReveal(string apikey, bool reveal);
    }

    public class RevealComponent : IRevealComponent
    {
        private const string Component = "reveal";

        private readonly IZapClient _zapClient;

        public RevealComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        /// <summary>
        /// Tells if shows hidden fields and enables disabled fields
        /// </summary>
        /// <returns>Result</returns>
        public IApiResult GetReveal()
        {
            return _zapClient.CallApi(Component, "view", "reveal");
        }

        /// <summary>
        /// Sets if shows hidden fields and enables disabled fields
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="reveal">If reveal should be enabled</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetReveal(string apikey, bool reveal)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("reveal", reveal.ToString());
            return _zapClient.CallApi(Component, "action", "setReveal", parameters);
        }
    }
}
