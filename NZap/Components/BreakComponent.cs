using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IBreakComponent
    {
        /* ACTIONS */

        IApiResult AddHttpBreakpoint(string apikey, string str, string location, string match, string inverse, bool ignorecase);
        IApiResult Break(string apikey, string type, string scope, string state);
        IApiResult RemoveHttpBreakpoint(string apikey, string str, string location, string match, string inverse, bool ignorecase);
    }

    internal class BreakComponent : IBreakComponent
    {
        private const string Component = "break";

        private readonly IZapClient _zapClient;

        public BreakComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        /// <summary>
        /// Add http breakpoint
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="str">String</param>
        /// <param name="location">Location</param>
        /// <param name="match">Match</param>
        /// <param name="inverse">Inverse</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Result of the action</returns>
        public IApiResult AddHttpBreakpoint(string apikey, string str, string location, string match, string inverse, bool ignorecase)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("string", str);
            parameters.Add("location", location);
            parameters.Add("match", match);
            parameters.Add("inverse", inverse);
            parameters.Add("ignorecase", ignorecase.ToString());
            return _zapClient.CallApi(Component, "action", "addHttpBreakpoint", parameters);
        }

        /// <summary>
        /// Break
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="type">Type</param>
        /// <param name="scope">Scope</param>
        /// <param name="state">State</param>
        /// <returns>Result of the action</returns>
        public IApiResult Break(string apikey, string type, string scope, string state)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("type", type);
            parameters.Add("scope", scope);
            parameters.Add("state", state);
            return _zapClient.CallApi(Component, "action", "break", parameters);
        }

        /// <summary>
        /// Remove http breakpoint
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="str">String</param>
        /// <param name="location">Location</param>
        /// <param name="match">Match</param>
        /// <param name="inverse">Inverse</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Result of the action</returns>
        public IApiResult RemoveHttpBreakpoint(string apikey, string str, string location, string match, string inverse,
            bool ignorecase)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("string", str);
            parameters.Add("location", location);
            parameters.Add("match", match);
            parameters.Add("inverse", inverse);
            parameters.Add("ignorecase", ignorecase.ToString());
            return _zapClient.CallApi(Component, "action", "removeHttpBreakpoint", parameters);
        }
    }
}
