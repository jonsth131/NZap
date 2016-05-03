using System.Collections.Generic;
using NZap.Entities;
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

        public AscanComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetAlertsIds(string scanId)
        {
            var parameters = new Dictionary<string, string> { { "scanId", scanId } };
            return _zapClient.CallApi(Component, "view", "alertsIds", parameters);
        }

        public IApiResult GetAttackModeQueue()
        {
            return _zapClient.CallApi(Component, "view", "attackModeQueue");
        }

        public IApiResult GetExcludedFromScan()
        {
            return _zapClient.CallApi(Component, "view", "excludedFromScan");
        }

        public IApiResult GetMessagesIds(string scanId)
        {
            var parameters = new Dictionary<string, string> { { "scanId", scanId } };
            return _zapClient.CallApi(Component, "view", "messagesIds", parameters);
        }

        public IApiResult GetOptionAllowAttackOnStart()
        {
            return _zapClient.CallApi(Component, "view", "optionAllowAttackOnStart");
        }

        public IApiResult GetOptionAttackPolicy()
        {
            return _zapClient.CallApi(Component, "view", "optionAttackPolicy");
        }

        public IApiResult GetOptionDefaultPolicy()
        {
            return _zapClient.CallApi(Component, "view", "optionDefaultPolicy");
        }

        public IApiResult GetOptionDelayInMs()
        {
            return _zapClient.CallApi(Component, "view", "optionDelayInMs");
        }

        public IApiResult GetOptionExcludedParamList()
        {
            return _zapClient.CallApi(Component, "view", "optionExcludedParamList");
        }

        public IApiResult GetOptionHandleAntiCsrfTokens()
        {
            return _zapClient.CallApi(Component, "view", "optionHandleAntiCSRFTokens");
        }

        public IApiResult GetOptionHostPerScan()
        {
            return _zapClient.CallApi(Component, "view", "optionHostPerScan");
        }

        public IApiResult GetOptionInjectPluginIdInHeader()
        {
            return _zapClient.CallApi(Component, "view", "optionInjectPluginIdInHeader");
        }

        public IApiResult GetOptionMaxChartTimeInMins()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxChartTimeInMins");
        }

        public IApiResult GetOptionMaxResultsToList()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxResultsToList");
        }

        public IApiResult GetOptionMaxScansInUi()
        {
            return _zapClient.CallApi(Component, "view", "optionMaxScansInUI");
        }

        public IApiResult GetOptionPromptInAttackMode()
        {
            return _zapClient.CallApi(Component, "view", "optionPromptInAttackMode");
        }

        public IApiResult GetOptionPromptToClearFinishedScans()
        {
            return _zapClient.CallApi(Component, "view", "optionPromptToClearFinishedScans");
        }

        public IApiResult GetOptionRescanInAttackMode()
        {
            return _zapClient.CallApi(Component, "view", "optionRescanInAttackMode");
        }

        public IApiResult GetOptionShowAdvancedDialog()
        {
            return _zapClient.CallApi(Component, "view", "optionShowAdvancedDialog");
        }

        public IApiResult GetOptionTargetParamsEnabledRpc()
        {
            return _zapClient.CallApi(Component, "view", "optionTargetParamsEnabledRPC");
        }

        public IApiResult GetOptionTargetParamsInjectable()
        {
            return _zapClient.CallApi(Component, "view", "optionTargetParamsInjectable");
        }

        public IApiResult GetOptionThreadPerHost()
        {
            return _zapClient.CallApi(Component, "view", "optionThreadPerHost");
        }

        public IApiResult GetPolicies(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "policies", parameters);
        }

        public IApiResult GetScanPolicyNames()
        {
            return _zapClient.CallApi(Component, "view", "scanPolicyNames");
        }

        public IApiResult GetScanProgress(string scanId = null)
        {
            return GetScanIdAction(scanId, "scanProgress");
        }

        public IApiResult GetScanners(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "scanners", parameters);
        }

        public IApiResult GetScans()
        {
            return _zapClient.CallApi(Component, "view", "scans");
        }

        public IApiResult GetStatus(string scanId = null)
        {
            return GetScanIdAction(scanId, "status");
        }

        public IApiResult AddScanPolicy(string apikey, string scanPolicyName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, "action", "addScanPolicy", parameters);
        }

        public IApiResult ClearExcludedFromScan(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "clearExcludedFromScan", parameters);
        }

        public IApiResult DisableAllScanners(string apikey, string scanPolicyName = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, "action", "disableAllScanners", parameters);
        }

        public IApiResult DisableScanners(string apikey, string ids)
        {
            return SetScanners(apikey, ids, "disableScanners");
        }

        public IApiResult EnableAllScanners(string apikey, string scanPolicyName = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, "action", "enableAllScanners", parameters);
        }

        public IApiResult EnableScanners(string apikey, string ids)
        {
            return SetScanners(apikey, ids, "enableScanners");
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

        public IApiResult PausAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "pauseAllScans", parameters);
        }

        public IApiResult RemoveAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "removeAllScans", parameters);
        }

        public IApiResult RemoveScan(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "action", "removeScan", parameters);
        }

        public IApiResult RemoveScanPolicy(string apikey, string scanPolicyName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, "action", "removeScanPolicy", parameters);
        }

        public IApiResult Resume(string apikey, string scanId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "action", "resume", parameters);
        }

        public IApiResult ResumeAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "resumeAllScans", parameters);
        }

        public IApiResult Scan(string apikey, string url, IDictionary<string, string> param = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, param);
            parameters.Add("url", url);
            return _zapClient.CallApi(Component, "action", "scan", parameters);
        }

        public IApiResult ScanAsUser(string apikey, string url, string contextId, string userId, IDictionary<string, string> param = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, param);
            parameters.Add("url", url);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            return _zapClient.CallApi(Component, "action", "scanAsUser", parameters);
        }

        public IApiResult SetEnabledPolicies(string apikey, string ids)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("ids", ids);
            return _zapClient.CallApi(Component, "action", "setEnabledPolicies", parameters);
        }

        public IApiResult SetOptionAllowAttackOnStart(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionAllowAttackOnStart");
        }

        public IApiResult SetOptionAttackPolicy(string apikey, string policy)
        {
            return ActionWithParameterString(apikey, policy, "setOptionAttackPolicy");
        }

        public IApiResult SetOptionDefaultPolicy(string apikey, string policy)
        {
            return ActionWithParameterString(apikey, policy, "setOptionDefaultPolicy");
        }

        public IApiResult SetOptionDelayInMs(string apikey, int delay)
        {
            return ActionWithParameterInteger(apikey, delay, "setOptionDelayInMs");
        }

        public IApiResult SetOptionHandleAntiCsrfTokens(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionHandleAntiCSRFTokens");
        }

        public IApiResult SetOptionHostPerScan(string apikey, int hostPerScan)
        {
            return ActionWithParameterInteger(apikey, hostPerScan, "setOptionHostPerScan");
        }

        public IApiResult SetOptionInjectPluginIdInHeader(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionInjectPluginIdInHeader");
        }

        public IApiResult SetOptionMaxChartTimeInMins(string apikey, int mins)
        {
            return ActionWithParameterInteger(apikey, mins, "setOptionMaxChartTimeInMins");
        }

        public IApiResult SetOptionMaxScansInUi(string apikey, int maxScans)
        {
            return ActionWithParameterInteger(apikey, maxScans, "setOptionMaxScansInUI");
        }

        public IApiResult SetOptionPromptInAttackMode(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionPromptInAttackMode");
        }

        public IApiResult SetOptionPromptToClearFinishedScans(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionPromptToClearFinishedScans");
        }

        public IApiResult SetOptionRescanInAttackMode(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionRescanInAttackMode");
        }

        public IApiResult SetOptionShowAdvancedDialog(string apikey, bool option)
        {
            return ActionWithParameterBoolean(apikey, option, "setOptionShowAdvancedDialog");
        }

        public IApiResult SetOptionTargetParamsEnabledRpc(string apikey, int paramsEnabled)
        {
            return ActionWithParameterInteger(apikey, paramsEnabled, "setOptionTargetParamsEnabledRPC");
        }

        public IApiResult SetOptionTargetParamsInjectable(string apikey, int paramsInjectable)
        {
            return ActionWithParameterInteger(apikey, paramsInjectable, "setOptionTargetParamsInjectable");
        }

        public IApiResult SetOptionThreadPerHost(string apikey, int optionThreadPerHost)
        {
            return ActionWithParameterInteger(apikey, optionThreadPerHost, "setOptionThreadPerHost");
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
            return _zapClient.CallApi(Component, "action", "stop", parameters);
        }

        public IApiResult StopAllScans(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "stopAllScans", parameters);
        }

        private IApiResult SetAlertThreshold(string apikey, string id, string alertThreshold, string scanPolicyName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("id", id);
            parameters.Add("alertThreshold", alertThreshold);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, "action", action, parameters);
        }

        private IApiResult SetAttackStrength(string apikey, string id, string attackStrength, string scanPolicyName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("id", id);
            parameters.Add("attackStrength", attackStrength);
            if (scanPolicyName != null) parameters.Add("scanPolicyName", scanPolicyName);
            return _zapClient.CallApi(Component, "action", action, parameters);
        }

        private IApiResult GetScanIdAction(string scanId, string action)
        {
            var parameters = new Dictionary<string, string>();
            if (scanId != null) parameters.Add("scanId", scanId);
            return _zapClient.CallApi(Component, "view", action, parameters);
        }

        private IApiResult SetScanners(string apikey, string ids, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("ids", ids);
            return _zapClient.CallApi(Component, "action", action, parameters);
        }

        private IApiResult ActionWithParameterBoolean(string apikey, bool option, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", action, parameters);
        }

        private IApiResult ActionWithParameterString(string apikey, string s, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", s);
            return _zapClient.CallApi(Component, "action", action, parameters);
        }

        private IApiResult ActionWithParameterInteger(string apikey, int n, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", n.ToString());
            return _zapClient.CallApi(Component, "action", action, parameters);
        }
    }
}
