using System.Collections.Generic;
using NZap.Entities;
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

    public class AjaxSpiderComponent : IAjaxSpiderComponent
    {
        private const string Component = "ajaxSpider";

        private readonly IZapClient _zapClient;

        public AjaxSpiderComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetNumberOfResults()
        {
            return _zapClient.CallApi(Component, "view", "numberOfResults");
        }

        public IApiResult GetOptionBrowserId()
        {
            return _zapClient.CallApi(Component, "view", "optionBrowserId");
        }

        public IApiResult GetOptionClickDefaultElems()
        {
            return _zapClient.CallApi(Component, "view", "optionClickDefaultElems");
        }

        public IApiResult GetOptionClickElemsOnce()
        {
            return _zapClient.CallApi(Component, "view", "optionClickElemsOnce");
        }

        public IApiResult GetOptionConfigVersionKey()
        {
            return _zapClient.CallApi(Component, "view", "optionConfigVersionKey");
        }

        public IApiResult GetOptionCurrentVersion()
        {
            return _zapClient.CallApi(Component, "view", "optionCurrentVersion");
        }

        public IApiResult GetOptionElems()
        {
            return _zapClient.CallApi(Component, "view", "optionElems");
        }

        public IApiResult GetOptionElemsNames()
        {
            return _zapClient.CallApi(Component, "view", "optionElemsNames");
        }

        public IApiResult GetOptionEventWait()
        {
            return _zapClient.CallApi(Component, "view", "optionEventWait");
        }

        public IApiResult GetOptionMaxCrawlDepth()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxCrawlDepth");
        }

        public IApiResult GetOptionMaxCrawlStates()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxCrawlStates");
        }

        public IApiResult GetOptionMaxDuration()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxDuration");
        }

        public IApiResult GetOptionNumberOfBrowsers()
        {
            return _zapClient.CallApi(Component, "view", "optionNumberOfBrowsers");
        }

        public IApiResult GetOptionRandomInputs()
        {
            return _zapClient.CallApi(Component, "view", "optionRandomInputs");
        }

        public IApiResult GetOptionReloadWait()
        {
            return _zapClient.CallApi(Component, "view", "optionReloadWait");
        }

        public IApiResult GetResults(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "results", parameters);
        }

        public IApiResult GetStatus()
        {
            return _zapClient.CallApi(Component, "view", "status");
        }

        public IApiResult Scan(string apikey, string url, string inScope = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("url", url);
            if (inScope != null) parameters.Add("inScope", inScope);
            return _zapClient.CallApi(Component, "action", "scan", parameters);
        }

        public IApiResult SetOptionBrowserId(string apikey, string id)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("id", id);
            return _zapClient.CallApi(Component, "action", "setOptionBrowserId", parameters);
        }

        public IApiResult SetOptionClickDefaultElems(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionClickDefaultElems", parameters);
        }

        public IApiResult SetOptionClickElemsOnce(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionClickElemsOnce", parameters);
        }

        public IApiResult SetOptionEventWait(string apikey, int wait)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", wait.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionEventWait", parameters);
        }

        public IApiResult SetOptionMaxCrawlDepth(string apikey, int depth)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", depth.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionMaxCrawlDepth", parameters);
        }

        public IApiResult SetOptionMaxCrawlStates(string apikey, int states)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", states.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionMaxCrawlStates", parameters);
        }

        public IApiResult SetOptionMaxDuration(string apikey, int duration)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", duration.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionMaxDuration", parameters);
        }

        public IApiResult SetOptionNumberOfBrowsers(string apikey, int numberOfBrowsers)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", numberOfBrowsers.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionNumberOfBrowsers", parameters);
        }

        public IApiResult SetOptionRandomInputs(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionRandomInputs", parameters);
        }

        public IApiResult SetOptionReloadWait(string apikey, int wait)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", wait.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionReloadWait", parameters);
        }

        public IApiResult Stop(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "stop", parameters);
        }
    }
}
