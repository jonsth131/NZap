using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
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

    internal class SpiderComponent : ISpiderComponent
    {
        private const string Component = "spider";

        private readonly IZapClient _zapClient;
        private readonly CommonActions _commonActions;

        public SpiderComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
            _commonActions = new CommonActions(zapClient, Component);
        }

        public IApiResult GetExcludedFromScan()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "excludedFromScan");
        }

        public IApiResult GetFullResults(string scanId)
        {
            var parameters = new Dictionary<string, string> { { "scanId", scanId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "fullResults", parameters);
        }

        public IApiResult GetOptionDomainsAlwaysInScope()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDomainsAlwaysInScope");
        }

        public IApiResult GetOptionDomainsAlwaysInScopeEnabled()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDomainsAlwaysInScopeEnabled");
        }

        public IApiResult GetOptionHandleODataParametersVisited()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionHandleODataParametersVisited");
        }

        public IApiResult GetOptionHandleParameters()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionHandleParameters");
        }

        public IApiResult GetOptionMaxDepth()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxDepth");
        }

        public IApiResult GetOptionMaxScansInUi()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxScansInUI");
        }

        public IApiResult GetOptionParseComments()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionParseComments");
        }

        public IApiResult GetOptionParseGit()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionParseGit");
        }

        public IApiResult GetOptionParseRobotsTxt()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionParseRobotsTxt");
        }

        public IApiResult GetOptionParseSvnEntries()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionParseSVNEntries");
        }

        public IApiResult GetOptionParseSitemapXml()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionParseSitemapXml");
        }

        public IApiResult GetOptionPostForm()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionPostForm");
        }

        public IApiResult GetOptionProcessForm()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProcessForm");
        }

        public IApiResult GetOptionRequestWaitTime()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionRequestWaitTime");
        }

        public IApiResult GetOptionScope()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionScope");
        }

        public IApiResult GetOptionScopeText()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionScopeText");
        }

        public IApiResult GetOptionSendRefererHeader()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionSendRefererHeader");
        }

        public IApiResult GetOptionShowAdvancedDialog()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionShowAdvancedDialog");
        }

        public IApiResult GetOptionSkipUrlString()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionSkipURLString");
        }

        public IApiResult GetOptionThreadCount()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionThreadCount");
        }

        public IApiResult GetOptionUserAgent()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionUserAgent");
        }

        public IApiResult GetResults(string scanId = null)
        {
            return GetScanIdAction(scanId, "results");
        }

        public IApiResult GetScans()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "scans");
        }

        public IApiResult GetStatus(string scanId = null)
        {
            return GetScanIdAction(scanId, "status");
        }

        public IApiResult ClearExcludedFromScan(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "clearExcludedFromScan", parameters);
        }

        public IApiResult ExcludeFromScan(string apikey, string regex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, ActionTypes.Action, "excludeFromScan", parameters);
        }

        public IApiResult Pause(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "pause", parameters);
        }

        public IApiResult PauseAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "pauseAllScans", parameters);
        }

        public IApiResult RemoveAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "removeAllScans", parameters);
        }

        public IApiResult Scan(string apikey, string url, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            parameters.Add("url", url);
            return _zapClient.CallApi(Component, ActionTypes.Action, "scan", parameters);
        }

        public IApiResult ScanAsUser(string apikey, string url, string contextId, string userId, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            parameters.Add("url", url);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "scanAsUser", parameters);
        }

        public IApiResult SetOptionHandleODataParametersVisited(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionHandleODataParametersVisited");
        }

        public IApiResult SetOptionHandleParameters(string apikey, string param)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("param", param);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setOptionHandleParameters", parameters);
        }

        public IApiResult SetOptionMaxDepth(string apikey, int depth)
        {
            return _commonActions.ActionWithParameter(apikey, depth, "setOptionMaxDepth");
        }

        public IApiResult SetOptionMaxScansInUi(string apikey, int maxScans)
        {
            return _commonActions.ActionWithParameter(apikey, maxScans, "setOptionMaxScansInUI");
        }

        public IApiResult SetOptionParseComments(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionParseComments");
        }

        public IApiResult SetOptionParseGit(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionParseGit");
        }

        public IApiResult SetOptionParseRobotsTxt(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionParseRobotsTxt");
        }

        public IApiResult SetOptionParseSvnEntries(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionParseSVNEntries");
        }

        public IApiResult SetOptionParseSitemapXml(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionParseSitemapXml");
        }

        public IApiResult SetOptionPostForm(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionPostForm");
        }

        public IApiResult SetOptionProcessForm(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionProcessForm");
        }

        public IApiResult SetOptionRequestWaitTime(string apikey, int waitTime)
        {
            return _commonActions.ActionWithParameter(apikey, waitTime, "setOptionRequestWaitTime");
        }

        public IApiResult SetOptionScopeString(string apikey, string scope)
        {
            return _commonActions.ActionWithParameter(apikey, scope, "setOptionScopeString");
        }

        public IApiResult SetOptionSendRefererHeader(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionSendRefererHeader");
        }

        public IApiResult SetOptionShowAdvancedDialog(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionShowAdvancedDialog");
        }

        public IApiResult SetOptionSkipUrlString(string apikey, string url)
        {
            return _commonActions.ActionWithParameter(apikey, url, "setOptionSkipURLString");
        }

        public IApiResult SetOptionThreadCount(string apikey, int threadCount)
        {
            return _commonActions.ActionWithParameter(apikey, threadCount, "setOptionThreadCount");
        }

        public IApiResult SetOptionUserAgent(string apikey, string userAgent)
        {
            return _commonActions.ActionWithParameter(apikey, userAgent, "setOptionUserAgent");
        }

        public IApiResult Stop(string apikey, string scanId = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "stop", parameters);
        }

        public IApiResult StopAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "stopAllScans", parameters);
        }

        private IApiResult GetScanIdAction(string scanId, string action)
        {
            var parameters = new Dictionary<string, string>();
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.View, action, parameters);
        }
    }
}
