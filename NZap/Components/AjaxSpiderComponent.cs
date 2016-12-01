using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAjaxSpiderComponent
    {
        /* VIEWS */
        IApiResult GetNumberOfResults();
        IApiResult GetOptionBrowserId();
        IApiResult GetOptionClickDefaultElems();
        IApiResult GetOptionClickElemsOnce();
        IApiResult GetOptionConfigVersionKey();
        IApiResult GetOptionCurrentVersion();
        IApiResult GetOptionElems();
        IApiResult GetOptionElemsNames();
        IApiResult GetOptionEventWait();
        IApiResult GetOptionMaxCrawlDepth();
        IApiResult GetOptionMaxCrawlStates();
        IApiResult GetOptionMaxDuration();
        IApiResult GetOptionNumberOfBrowsers();
        IApiResult GetOptionRandomInputs();
        IApiResult GetOptionReloadWait();
        IApiResult GetResults(IDictionary<string, string> parameters = null);
        IApiResult GetStatus();

        /* ACTIONS */
        IApiResult Scan(string apikey, string url, string inScope = null);
        IApiResult SetOptionBrowserId(string apikey, string id);
        IApiResult SetOptionClickDefaultElems(string apikey, bool option);
        IApiResult SetOptionClickElemsOnce(string apikey, bool option);
        IApiResult SetOptionEventWait(string apikey, int wait);
        IApiResult SetOptionMaxCrawlDepth(string apikey, int depth);
        IApiResult SetOptionMaxCrawlStates(string apikey, int states);
        IApiResult SetOptionMaxDuration(string apikey, int duration);
        IApiResult SetOptionNumberOfBrowsers(string apikey, int numberOfBrowsers);
        IApiResult SetOptionRandomInputs(string apikey, bool option);
        IApiResult SetOptionReloadWait(string apikey, int wait);
        IApiResult Stop(string apikey);
    }

    internal class AjaxSpiderComponent : IAjaxSpiderComponent
    {
        private const string Component = "ajaxSpider";

        private readonly IZapClient _zapClient;
        private readonly CommonActions _commonActions;

        public AjaxSpiderComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
            _commonActions = new CommonActions(zapClient, Component);
        }

        public IApiResult GetNumberOfResults()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "numberOfResults");
        }

        public IApiResult GetOptionBrowserId()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionBrowserId");
        }

        public IApiResult GetOptionClickDefaultElems()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionClickDefaultElems");
        }

        public IApiResult GetOptionClickElemsOnce()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionClickElemsOnce");
        }

        public IApiResult GetOptionConfigVersionKey()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionConfigVersionKey");
        }

        public IApiResult GetOptionCurrentVersion()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionCurrentVersion");
        }

        public IApiResult GetOptionElems()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionElems");
        }

        public IApiResult GetOptionElemsNames()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionElemsNames");
        }

        public IApiResult GetOptionEventWait()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionEventWait");
        }

        public IApiResult GetOptionMaxCrawlDepth()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxCrawlDepth");
        }

        public IApiResult GetOptionMaxCrawlStates()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxCrawlStates");
        }

        public IApiResult GetOptionMaxDuration()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxDuration");
        }

        public IApiResult GetOptionNumberOfBrowsers()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionNumberOfBrowsers");
        }

        public IApiResult GetOptionRandomInputs()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionRandomInputs");
        }

        public IApiResult GetOptionReloadWait()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionReloadWait");
        }

        public IApiResult GetResults(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "results", parameters);
        }

        public IApiResult GetStatus()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "status");
        }

        public IApiResult Scan(string apikey, string url, string inScope = "")
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("url", url);
            if (string.IsNullOrEmpty(inScope)) inScope = string.Empty;
            parameters.Add("inScope", inScope);
            return _zapClient.CallApi(Component, ActionTypes.Action, "scan", parameters);
        }

        public IApiResult SetOptionBrowserId(string apikey, string id)
        {
            return _commonActions.ActionWithParameter(apikey, id, "setOptionBrowserId");
        }

        public IApiResult SetOptionClickDefaultElems(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionClickDefaultElems");
        }

        public IApiResult SetOptionClickElemsOnce(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionClickElemsOnce");
        }

        public IApiResult SetOptionEventWait(string apikey, int wait)
        {
            return _commonActions.ActionWithParameter(apikey, wait, "setOptionEventWait");
        }

        public IApiResult SetOptionMaxCrawlDepth(string apikey, int depth)
        {
            return _commonActions.ActionWithParameter(apikey, depth, "setOptionMaxCrawlDepth");
        }

        public IApiResult SetOptionMaxCrawlStates(string apikey, int states)
        {
            return _commonActions.ActionWithParameter(apikey, states, "setOptionMaxCrawlStates");
        }

        public IApiResult SetOptionMaxDuration(string apikey, int duration)
        {
            return _commonActions.ActionWithParameter(apikey, duration, "setOptionMaxDuration");
        }

        public IApiResult SetOptionNumberOfBrowsers(string apikey, int numberOfBrowsers)
        {
            return _commonActions.ActionWithParameter(apikey, numberOfBrowsers, "setOptionNumberOfBrowsers");
        }

        public IApiResult SetOptionRandomInputs(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionRandomInputs");
        }

        public IApiResult SetOptionReloadWait(string apikey, int wait)
        {
            return _commonActions.ActionWithParameter(apikey, wait, "setOptionReloadWait");
        }

        public IApiResult Stop(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "stop", parameters);
        }
    }
}
