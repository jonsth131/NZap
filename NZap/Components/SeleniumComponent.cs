using NZap.Entities;
using NZap.Enums;

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
        private readonly CommonActions _commonActions;

        public SeleniumComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
            _commonActions = new CommonActions(zapClient, Component);
        }

        /// <summary>
        /// Returns the current path to ChromeDriver
        /// </summary>
        /// <returns>Current path to ChromeDriver</returns>
        public IApiResult GetOptionChromeDriverPath()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionChromeDriverPath");
        }

        /// <summary>
        /// Returns the current path to IEDriverServer
        /// </summary>
        /// <returns>Current path to IEDriverServer</returns>
        public IApiResult GetOptionIeDriverPath()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionIeDriverPath");
        }

        /// <summary>
        /// Returns the current path to PhantomJS binary
        /// </summary>
        /// <returns>Current path to PhantomJS binary</returns>
        public IApiResult GetOptionPhantomJsBinaryPath()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionPhantomJsBinaryPath");
        }

        /// <summary>
        /// Sets the current path to ChromeDriver
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="path">Path to ChromeDriver</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetOptionChromeDriverPath(string apikey, string path)
        {
            return _commonActions.ActionWithParameter(apikey, path, "setOptionChromeDriverPath");
        }

        /// <summary>
        /// Sets the current path to IEDriverServer
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="path">Path to IEDriverServer</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetOptionIeDriverPath(string apikey, string path)
        {
            return _commonActions.ActionWithParameter(apikey, path, "setOptionIeDriverPath");
        }

        /// <summary>
        /// Sets the current path to PhantomJS binary
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="path">Path to PhantomJS binary</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetOptionPhantomJsBinaryPath(string apikey, string path)
        {
            return _commonActions.ActionWithParameter(apikey, path, "setOptionPhantomJsBinaryPath");
        }
    }
}
