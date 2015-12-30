using System.Collections.Generic;
using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface ISpiderComponent
    {
        /* VIEWS */
        IApiResult GetExcludedFromScan();
        IApiResult GetFullResults(string scanId);
        IApiResult GetOptionDomainsAlwaysInScope();
        IApiResult GetOptionDomainsAlwaysInScopeEnabled();
        IApiResult GetOptionHandleODataParametersVisited();
        IApiResult GetOptionHandleParameters();
        IApiResult GetOptionMaxDepth();
        IApiResult GetOptionMaxScansInUi();
        IApiResult GetOptionParseComments();
        IApiResult GetOptionParseGit();
        IApiResult GetOptionParseRobotsTxt();
        IApiResult GetOptionParseSvnEntries();
        IApiResult GetOptionParseSitemapXml();
        IApiResult GetOptionPostForm();
        IApiResult GetOptionProcessForm();
        IApiResult GetOptionRequestWaitTime();
        IApiResult GetOptionScope();
        IApiResult GetOptionScopeText();
        IApiResult GetOptionSendRefererHeader();
        IApiResult GetOptionShowAdvancedDialog();
        IApiResult GetOptionSkipUrlString();
        IApiResult GetOptionThreadCount();
        IApiResult GetOptionUserAgent();
        IApiResult GetResults(string scanId = null);
        IApiResult GetScans();
        IApiResult GetStatus(string scanId = null);

        /* ACTIONS */
        IApiResult ClearExcludedFromScan(string apikey);
        IApiResult ExcludeFromScan(string apikey, string regex);
        IApiResult Pause(string apikey, string scanId);
        IApiResult PauseAllScans(string apikey);
        IApiResult RemoveAllScans(string apikey);
        IApiResult Scan(string apikey, string url, IDictionary<string, string> parameters = null);
        IApiResult ScanAsUser(string apikey, string url, string contextId, string userId, IDictionary<string, string> parameters = null);
        IApiResult SetOptionHandleODataParametersVisited(string apikey, bool option);
        IApiResult SetOptionHandleParameters(string apikey, string parameters);
        IApiResult SetOptionMaxDepth(string apikey, int depth);
        IApiResult SetOptionMaxScansInUi(string apikey, int maxScans);
        IApiResult SetOptionParseComments(string apikey, bool option);
        IApiResult SetOptionParseGit(string apikey, bool option);
        IApiResult SetOptionParseRobotsTxt(string apikey, bool option);
        IApiResult SetOptionParseSvnEntries(string apikey, bool option);
        IApiResult SetOptionParseSitemapXml(string apikey, bool option);
        IApiResult SetOptionPostForm(string apikey, bool option);
        IApiResult SetOptionProcessForm(string apikey, bool option);
        IApiResult SetOptionRequestWaitTime(string apikey, int waitTime);
        IApiResult SetOptionScopeString(string apikey, string scope);
        IApiResult SetOptionSendRefererHeader(string apikey, bool option);
        IApiResult SetOptionShowAdvancedDialog(string apikey, bool option);
        IApiResult SetOptionSkipUrlString(string apikey, string url);
        IApiResult SetOptionThreadCount(string apikey, int threadCount);
        IApiResult SetOptionUserAgent(string apikey, string userAgent);
        IApiResult Stop(string apikey, string scanId = null);
        IApiResult StopAllScans(string apikey);
    }

    public class SpiderComponent : ISpiderComponent
    {
        private const string Component = "spider";

        private readonly IZapClient _zapClient;

        public SpiderComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetExcludedFromScan()
        {
            return _zapClient.CallApi(Component, "view", "excludedFromScan");
        }

        public IApiResult GetFullResults(string scanId)
        {
            var parameters = new Dictionary<string, string> { { "scanId", scanId } };
            return _zapClient.CallApi(Component, "view", "fullResults", parameters);
        }

        public IApiResult GetOptionDomainsAlwaysInScope()
        {
            return _zapClient.CallApi(Component, "view", "optionDomainsAlwaysInScope");
        }

        public IApiResult GetOptionDomainsAlwaysInScopeEnabled()
        {
            return _zapClient.CallApi(Component, "view", "optionDomainsAlwaysInScopeEnabled");
        }

        public IApiResult GetOptionHandleODataParametersVisited()
        {
            return _zapClient.CallApi(Component, "view", "optionHandleODataParametersVisited");
        }

        public IApiResult GetOptionHandleParameters()
        {
            return _zapClient.CallApi(Component, "view", "optionHandleParameters");
        }

        public IApiResult GetOptionMaxDepth()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxDepth");
        }

        public IApiResult GetOptionMaxScansInUi()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxScansInUI");
        }

        public IApiResult GetOptionParseComments()
        {
            return _zapClient.CallApi(Component, "view", "optionParseComments");
        }

        public IApiResult GetOptionParseGit()
        {
            return _zapClient.CallApi(Component, "view", "optionParseGit");
        }

        public IApiResult GetOptionParseRobotsTxt()
        {
            return _zapClient.CallApi(Component, "view", "optionParseRobotsTxt");
        }

        public IApiResult GetOptionParseSvnEntries()
        {
            return _zapClient.CallApi(Component, "view", "optionParseSVNEntries");
        }

        public IApiResult GetOptionParseSitemapXml()
        {
            return _zapClient.CallApi(Component, "view", "optionParseSitemapXml");
        }

        public IApiResult GetOptionPostForm()
        {
            return _zapClient.CallApi(Component, "view", "optionPostForm");
        }

        public IApiResult GetOptionProcessForm()
        {
            return _zapClient.CallApi(Component, "view", "optionProcessForm");
        }

        public IApiResult GetOptionRequestWaitTime()
        {
            return _zapClient.CallApi(Component, "view", "optionRequestWaitTime");
        }

        public IApiResult GetOptionScope()
        {
            return _zapClient.CallApi(Component, "view", "optionScope");
        }

        public IApiResult GetOptionScopeText()
        {
            return _zapClient.CallApi(Component, "view", "optionScopeText");
        }

        public IApiResult GetOptionSendRefererHeader()
        {
            return _zapClient.CallApi(Component, "view", "optionSendRefererHeader");
        }

        public IApiResult GetOptionShowAdvancedDialog()
        {
            return _zapClient.CallApi(Component, "view", "optionShowAdvancedDialog");
        }

        public IApiResult GetOptionSkipUrlString()
        {
            return _zapClient.CallApi(Component, "view", "optionSkipURLString");
        }

        public IApiResult GetOptionThreadCount()
        {
            return _zapClient.CallApi(Component, "view", "optionThreadCount");
        }

        public IApiResult GetOptionUserAgent()
        {
            return _zapClient.CallApi(Component, "view", "optionUserAgent");
        }

        public IApiResult GetResults(string scanId = null)
        {
            var parameters = new Dictionary<string, string>();
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "view", "results", parameters);
        }

        public IApiResult GetScans()
        {
            return _zapClient.CallApi(Component, "view", "scans");
        }

        public IApiResult GetStatus(string scanId = null)
        {
            var parameters = new Dictionary<string, string>();
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "view", "status", parameters);
        }

        public IApiResult ClearExcludedFromScan(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "clearExcludedFromScan", parameters);
        }

        public IApiResult ExcludeFromScan(string apikey, string regex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "action", "excludeFromScan", parameters);
        }

        public IApiResult Pause(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "action", "pause", parameters);
        }

        public IApiResult PauseAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "pauseAllScans", parameters);
        }

        public IApiResult RemoveAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "removeAllScans", parameters);
        }

        public IApiResult Scan(string apikey, string url, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            parameters.Add("url", url);
            return _zapClient.CallApi(Component, "action", "scan", parameters);
        }

        public IApiResult ScanAsUser(string apikey, string url, string contextId, string userId, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            parameters.Add("url", url);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            return _zapClient.CallApi(Component, "action", "scanAsUser", parameters);
        }

        public IApiResult SetOptionHandleODataParametersVisited(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionHandleODataParametersVisited", parameters);
        }

        public IApiResult SetOptionHandleParameters(string apikey, string param)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("param", param);
            return _zapClient.CallApi(Component, "action", "setOptionHandleParameters", parameters);
        }

        public IApiResult SetOptionMaxDepth(string apikey, int depth)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", depth.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionMaxDepth", parameters);
        }

        public IApiResult SetOptionMaxScansInUi(string apikey, int maxScans)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", maxScans.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionMaxScansInUI", parameters);
        }

        public IApiResult SetOptionParseComments(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionParseComments", parameters);
        }

        public IApiResult SetOptionParseGit(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionParseGit", parameters);
        }

        public IApiResult SetOptionParseRobotsTxt(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionParseRobotsTxt", parameters);
        }

        public IApiResult SetOptionParseSvnEntries(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionParseSVNEntries", parameters);
        }

        public IApiResult SetOptionParseSitemapXml(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionParseSitemapXml", parameters);
        }

        public IApiResult SetOptionPostForm(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionPostForm", parameters);
        }

        public IApiResult SetOptionProcessForm(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionProcessForm", parameters);
        }

        public IApiResult SetOptionRequestWaitTime(string apikey, int waitTime)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", waitTime.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionRequestWaitTime", parameters);
        }

        public IApiResult SetOptionScopeString(string apikey, string scope)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", scope);
            return _zapClient.CallApi(Component, "action", "setOptionScopeString", parameters);
        }

        public IApiResult SetOptionSendRefererHeader(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionSendRefererHeader", parameters);
        }

        public IApiResult SetOptionShowAdvancedDialog(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionShowAdvancedDialog", parameters);
        }

        public IApiResult SetOptionSkipUrlString(string apikey, string url)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", url);
            return _zapClient.CallApi(Component, "action", "setOptionSkipURLString", parameters);
        }

        public IApiResult SetOptionThreadCount(string apikey, int threadCount)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", threadCount.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionThreadCount", parameters);
        }

        public IApiResult SetOptionUserAgent(string apikey, string userAgent)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", userAgent);
            return _zapClient.CallApi(Component, "action", "setOptionUserAgent", parameters);
        }

        public IApiResult Stop(string apikey, string scanId = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "action", "stop", parameters);
        }

        public IApiResult StopAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "stopAllScans", parameters);
        }
    }
}
