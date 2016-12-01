using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAscanComponent
    {
        /* VIEWS */
        IApiResult GetAlertsIds(string scanId);
        IApiResult GetAttackModeQueue();
        IApiResult GetExcludedFromScan();
        IApiResult GetMessagesIds(string scanId);
        IApiResult GetOptionAllowAttackOnStart();
        IApiResult GetOptionAttackPolicy();
        IApiResult GetOptionDefaultPolicy();
        IApiResult GetOptionDelayInMs();
        IApiResult GetOptionExcludedParamList();
        IApiResult GetOptionHandleAntiCsrfTokens();
        IApiResult GetOptionHostPerScan();
        IApiResult GetOptionInjectPluginIdInHeader();
        IApiResult GetOptionMaxChartTimeInMins();
        IApiResult GetOptionMaxResultsToList();
        IApiResult GetOptionMaxScansInUi();
        IApiResult GetOptionPromptInAttackMode();
        IApiResult GetOptionPromptToClearFinishedScans();
        IApiResult GetOptionRescanInAttackMode();
        IApiResult GetOptionShowAdvancedDialog();
        IApiResult GetOptionTargetParamsEnabledRpc();
        IApiResult GetOptionTargetParamsInjectable();
        IApiResult GetOptionThreadPerHost();
        IApiResult GetPolicies(IDictionary<string, string> parameters = null);
        IApiResult GetScanPolicyNames();
        IApiResult GetScanProgress(string scanId = null);
        IApiResult GetScanners(IDictionary<string, string> parameters = null);
        IApiResult GetScans();
        IApiResult GetStatus(string scanId = null);

        /* ACTIONS */
        IApiResult AddScanPolicy(string apikey, string scanPolicyName);
        IApiResult ClearExcludedFromScan(string apikey);
        IApiResult DisableAllScanners(string apikey, string scanPolicyName = null);
        IApiResult DisableScanners(string apikey, string ids);
        IApiResult EnableAllScanners(string apikey, string scanPolicyName = null);
        IApiResult EnableScanners(string apikey, string ids);
        IApiResult ExcludeFromScan(string apikey, string regex);
        IApiResult Pause(string apikey, string scanId);
        IApiResult PausAllScans(string apikey);
        IApiResult RemoveAllScans(string apikey);
        IApiResult RemoveScan(string apikey, string scanId);
        IApiResult RemoveScanPolicy(string apikey, string scanPolicyName);
        IApiResult Resume(string apikey, string scanId);
        IApiResult ResumeAllScans(string apikey);
        IApiResult Scan(string apikey, string url, IDictionary<string, string> parameters = null);
        IApiResult ScanAsUser(string apikey, string url, string contextId, string userId, IDictionary<string, string> parameters = null);
        IApiResult SetEnabledPolicies(string apikey, string ids);
        IApiResult SetOptionAllowAttackOnStart(string apikey, bool option);
        IApiResult SetOptionAttackPolicy(string apikey, string policy);
        IApiResult SetOptionDefaultPolicy(string apikey, string policy);
        IApiResult SetOptionDelayInMs(string apikey, int delay);
        IApiResult SetOptionHandleAntiCsrfTokens(string apikey, bool option);
        IApiResult SetOptionHostPerScan(string apikey, int hostPerScan);
        IApiResult SetOptionInjectPluginIdInHeader(string apikey, bool option);
        IApiResult SetOptionMaxChartTimeInMins(string apikey, int mins);
        IApiResult SetOptionMaxScansInUi(string apikey, int maxScans);
        IApiResult SetOptionPromptInAttackMode(string apikey, bool option);
        IApiResult SetOptionPromptToClearFinishedScans(string apikey, bool option);
        IApiResult SetOptionRescanInAttackMode(string apikey, bool option);
        IApiResult SetOptionShowAdvancedDialog(string apikey, bool option);
        IApiResult SetOptionTargetParamsEnabledRpc(string apikey, int paramsEnabled);
        IApiResult SetOptionTargetParamsInjectable(string apikey, int paramsInjectable);
        IApiResult SetOptionThreadPerHost(string apikey, int optionThreadPerHost);
        IApiResult SetPolicyAlertThreshold(string apikey, string id, string alertThreshold, string scanPolicyName = null);
        IApiResult SetPolicyAttackStrength(string apikey, string id, string attackStrength, string scanPolicyName = null);
        IApiResult SetScannerAlertThreshold(string apikey, string id, string alertThreshold, string scanPolicyName = null);
        IApiResult SetScannerAttackStrength(string apikey, string id, string attackStrength, string scanPolicyName = null);
        IApiResult Stop(string apikey, string scanId);
        IApiResult StopAllScans(string apikey);
    }

    internal class AscanComponent : IAscanComponent
    {
        private const string Component = "ascan";

        private readonly IZapClient _zapClient;
        private readonly CommonActions _commonActions;

        public AscanComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
            _commonActions = new CommonActions(zapClient, Component);
        }

        public IApiResult GetAlertsIds(string scanId)
        {
            var parameters = new Dictionary<string, string> { { "scanId", scanId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "alertsIds", parameters);
        }

        public IApiResult GetAttackModeQueue()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "attackModeQueue");
        }

        public IApiResult GetExcludedFromScan()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "excludedFromScan");
        }

        public IApiResult GetMessagesIds(string scanId)
        {
            var parameters = new Dictionary<string, string> { { "scanId", scanId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "messagesIds", parameters);
        }

        public IApiResult GetOptionAllowAttackOnStart()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionAllowAttackOnStart");
        }

        public IApiResult GetOptionAttackPolicy()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionAttackPolicy");
        }

        public IApiResult GetOptionDefaultPolicy()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDefaultPolicy");
        }

        public IApiResult GetOptionDelayInMs()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDelayInMs");
        }

        public IApiResult GetOptionExcludedParamList()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionExcludedParamList");
        }

        public IApiResult GetOptionHandleAntiCsrfTokens()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionHandleAntiCSRFTokens");
        }

        public IApiResult GetOptionHostPerScan()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionHostPerScan");
        }

        public IApiResult GetOptionInjectPluginIdInHeader()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionInjectPluginIdInHeader");
        }

        public IApiResult GetOptionMaxChartTimeInMins()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxChartTimeInMins");
        }

        public IApiResult GetOptionMaxResultsToList()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxResultsToList");
        }

        public IApiResult GetOptionMaxScansInUi()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionMaxScansInUI");
        }

        public IApiResult GetOptionPromptInAttackMode()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionPromptInAttackMode");
        }

        public IApiResult GetOptionPromptToClearFinishedScans()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionPromptToClearFinishedScans");
        }

        public IApiResult GetOptionRescanInAttackMode()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionRescanInAttackMode");
        }

        public IApiResult GetOptionShowAdvancedDialog()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionShowAdvancedDialog");
        }

        public IApiResult GetOptionTargetParamsEnabledRpc()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionTargetParamsEnabledRPC");
        }

        public IApiResult GetOptionTargetParamsInjectable()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionTargetParamsInjectable");
        }

        public IApiResult GetOptionThreadPerHost()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionThreadPerHost");
        }

        public IApiResult GetPolicies(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "policies", parameters);
        }

        public IApiResult GetScanPolicyNames()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "scanPolicyNames");
        }

        public IApiResult GetScanProgress(string scanId = null)
        {
            return GetScanIdAction(scanId, "scanProgress");
        }

        public IApiResult GetScanners(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "scanners", parameters);
        }

        public IApiResult GetScans()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "scans");
        }

        public IApiResult GetStatus(string scanId = null)
        {
            return GetScanIdAction(scanId, "status");
        }

        public IApiResult AddScanPolicy(string apikey, string scanPolicyName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, ActionTypes.Action, "addScanPolicy", parameters);
        }

        public IApiResult ClearExcludedFromScan(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "clearExcludedFromScan", parameters);
        }

        public IApiResult DisableAllScanners(string apikey, string scanPolicyName = null)
        {
            return SetAllScanners(apikey, scanPolicyName, "disableAllScanners");
        }

        public IApiResult DisableScanners(string apikey, string ids)
        {
            return SetScanners(apikey, ids, "disableScanners");
        }

        public IApiResult EnableAllScanners(string apikey, string scanPolicyName = null)
        {
            return SetAllScanners(apikey, scanPolicyName, "enableAllScanners");
        }

        public IApiResult EnableScanners(string apikey, string ids)
        {
            return SetScanners(apikey, ids, "enableScanners");
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

        public IApiResult PausAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "pauseAllScans", parameters);
        }

        public IApiResult RemoveAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "removeAllScans", parameters);
        }

        public IApiResult RemoveScan(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "removeScan", parameters);
        }

        public IApiResult RemoveScanPolicy(string apikey, string scanPolicyName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, ActionTypes.Action, "removeScanPolicy", parameters);
        }

        public IApiResult Resume(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "resume", parameters);
        }

        public IApiResult ResumeAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "resumeAllScans", parameters);
        }

        public IApiResult Scan(string apikey, string url, IDictionary<string, string> param = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, param);
            parameters.Add("url", url);
            return _zapClient.CallApi(Component, ActionTypes.Action, "scan", parameters);
        }

        public IApiResult ScanAsUser(string apikey, string url, string contextId, string userId, IDictionary<string, string> param = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, param);
            parameters.Add("url", url);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "scanAsUser", parameters);
        }

        public IApiResult SetEnabledPolicies(string apikey, string ids)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("ids", ids);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setEnabledPolicies", parameters);
        }

        public IApiResult SetOptionAllowAttackOnStart(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionAllowAttackOnStart");
        }

        public IApiResult SetOptionAttackPolicy(string apikey, string policy)
        {
            return _commonActions.ActionWithParameter(apikey, policy, "setOptionAttackPolicy");
        }

        public IApiResult SetOptionDefaultPolicy(string apikey, string policy)
        {
            return _commonActions.ActionWithParameter(apikey, policy, "setOptionDefaultPolicy");
        }

        public IApiResult SetOptionDelayInMs(string apikey, int delay)
        {
            return _commonActions.ActionWithParameter(apikey, delay, "setOptionDelayInMs");
        }

        public IApiResult SetOptionHandleAntiCsrfTokens(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionHandleAntiCSRFTokens");
        }

        public IApiResult SetOptionHostPerScan(string apikey, int hostPerScan)
        {
            return _commonActions.ActionWithParameter(apikey, hostPerScan, "setOptionHostPerScan");
        }

        public IApiResult SetOptionInjectPluginIdInHeader(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionInjectPluginIdInHeader");
        }

        public IApiResult SetOptionMaxChartTimeInMins(string apikey, int mins)
        {
            return _commonActions.ActionWithParameter(apikey, mins, "setOptionMaxChartTimeInMins");
        }

        public IApiResult SetOptionMaxScansInUi(string apikey, int maxScans)
        {
            return _commonActions.ActionWithParameter(apikey, maxScans, "setOptionMaxScansInUI");
        }

        public IApiResult SetOptionPromptInAttackMode(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionPromptInAttackMode");
        }

        public IApiResult SetOptionPromptToClearFinishedScans(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionPromptToClearFinishedScans");
        }

        public IApiResult SetOptionRescanInAttackMode(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionRescanInAttackMode");
        }

        public IApiResult SetOptionShowAdvancedDialog(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionShowAdvancedDialog");
        }

        public IApiResult SetOptionTargetParamsEnabledRpc(string apikey, int paramsEnabled)
        {
            return _commonActions.ActionWithParameter(apikey, paramsEnabled, "setOptionTargetParamsEnabledRPC");
        }

        public IApiResult SetOptionTargetParamsInjectable(string apikey, int paramsInjectable)
        {
            return _commonActions.ActionWithParameter(apikey, paramsInjectable, "setOptionTargetParamsInjectable");
        }

        public IApiResult SetOptionThreadPerHost(string apikey, int optionThreadPerHost)
        {
            return _commonActions.ActionWithParameter(apikey, optionThreadPerHost, "setOptionThreadPerHost");
        }

        public IApiResult SetPolicyAlertThreshold(string apikey, string id, string alertThreshold, string scanPolicyName = null)
        {
            return SetAlertThreshold(apikey, id, alertThreshold, scanPolicyName, "setPolicyAlertThreshold");
        }

        public IApiResult SetPolicyAttackStrength(string apikey, string id, string attackStrength, string scanPolicyName = null)
        {
            return SetAttackStrength(apikey, id, attackStrength, scanPolicyName, "setPolicyAttackStrength");
        }

        public IApiResult SetScannerAlertThreshold(string apikey, string id, string alertThreshold, string scanPolicyName = null)
        {
            return SetAlertThreshold(apikey, id, alertThreshold, scanPolicyName, "setScannerAlertThreshold");
        }

        public IApiResult SetScannerAttackStrength(string apikey, string id, string attackStrength, string scanPolicyName = null)
        {
            return SetAttackStrength(apikey, id, attackStrength, scanPolicyName, "setScannerAttackStrength");
        }

        public IApiResult Stop(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "stop", parameters);
        }

        public IApiResult StopAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "stopAllScans", parameters);
        }

        private IApiResult SetAlertThreshold(string apikey, string id, string alertThreshold, string scanPolicyName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("id", id);
            parameters.Add("alertThreshold", alertThreshold);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
        }

        private IApiResult SetAttackStrength(string apikey, string id, string attackStrength, string scanPolicyName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("id", id);
            parameters.Add("attackStrength", attackStrength);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
        }

        private IApiResult GetScanIdAction(string scanId, string action)
        {
            var parameters = new Dictionary<string, string>();
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, ActionTypes.View, action, parameters);
        }

        private IApiResult SetScanners(string apikey, string ids, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("ids", ids);
            return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
        }

        private IApiResult SetAllScanners(string apikey, string scanPolicyName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
        }

    }
}
