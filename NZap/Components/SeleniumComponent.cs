using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface ISeleniumComponent
    {
        /* VIEWS */
        IApiResult GetOptionChromeDriverPath();
        IApiResult GetOptionIeDriverPath();
        IApiResult GetOptionPhantomJsBinaryPath();

        /* ACTIONS */
        IApiResult SetOptionChromeDriverPath(string apikey, string path);
        IApiResult SetOptionIeDriverPath(string apikey, string path);
        IApiResult SetOptionPhantomJsBinaryPath(string apikey, string path);
    }

    internal class SeleniumComponent : ISeleniumComponent
    {
        private const string Component = "selenium";

        private readonly IZapClient _zapClient;

        public SeleniumComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        /// <summary>
        /// Returns the current path to ChromeDriver
        /// </summary>
        /// <returns>Current path to ChromeDriver</returns>
        public IApiResult GetOptionChromeDriverPath()
        {
            return _zapClient.CallApi(Component, "view", "optionChromeDriverPath");
        }

        /// <summary>
        /// Returns the current path to IEDriverServer
        /// </summary>
        /// <returns>Current path to IEDriverServer</returns>
        public IApiResult GetOptionIeDriverPath()
        {
            return _zapClient.CallApi(Component, "view", "optionIeDriverPath");
        }

        /// <summary>
        /// Returns the current path to PhantomJS binary
        /// </summary>
        /// <returns>Current path to PhantomJS binary</returns>
        public IApiResult GetOptionPhantomJsBinaryPath()
        {
            return _zapClient.CallApi(Component, "view", "optionPhantomJsBinaryPath");
        }

        /// <summary>
        /// Sets the current path to ChromeDriver
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="path">Path to ChromeDriver</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetOptionChromeDriverPath(string apikey, string path)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", path);
            return _zapClient.CallApi(Component, "action", "setOptionChromeDriverPath", parameters);
        }

        /// <summary>
        /// Sets the current path to IEDriverServer
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="path">Path to IEDriverServer</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetOptionIeDriverPath(string apikey, string path)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", path);
            return _zapClient.CallApi(Component, "action", "setOptionIeDriverPath", parameters);
        }

        /// <summary>
        /// Sets the current path to PhantomJS binary
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="path">Path to PhantomJS binary</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetOptionPhantomJsBinaryPath(string apikey, string path)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", path);
            return _zapClient.CallApi(Component, "action", "setOptionPhantomJsBinaryPath", parameters);
        }
    }
}
