using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IPscanComponent
    {
        /* VIEWS */
        IApiResult GetRecordsToScan();
        IApiResult GetScanners();

        /* ACTIONS */
        IApiResult DisableAllScanners(string apikey);
        IApiResult DisableScanners(string apikey, string ids);
        IApiResult EnableAllScanners(string apikey);
        IApiResult EnableScanners(string apikey, string ids);
        IApiResult SetEnabled(string apikey, bool enabled);
        IApiResult SetScannerAlertThreshold(string apikey, string id, string alertThreshold);
    }

    public class PscanComponent : IPscanComponent
    {
        private const string Component = "pscan";

        private readonly IZapClient _zapClient;

        public PscanComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        /// <summary>
        /// The number of records the passive scanner still has to scan
        /// </summary>
        /// <returns>List of records the passive scanner still has to scan</returns>
        public IApiResult GetRecordsToScan()
        {
            return _zapClient.CallApi(Component, "view", "recordsToScan");
        }

        /// <summary>
        /// Lists all passive scanners with its ID, name, enabled state and alert threshold.
        /// </summary>
        /// <returns>List of all passive scanners available</returns>
        public IApiResult GetScanners()
        {
            return _zapClient.CallApi(Component, "view", "scanners");
        }

        /// <summary>
        /// Disables all passive scanners
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <returns>Result of the action</returns>
        public IApiResult DisableAllScanners(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "disableAllScanners", parameters);
        }

        /// <summary>
        /// Disables all passive scanners with the given IDs (comma separated list of IDs)
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="ids">Comma separated list of IDs</param>
        /// <returns>Result of the action</returns>
        public IApiResult DisableScanners(string apikey, string ids)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("ids", ids);
            return _zapClient.CallApi(Component, "action", "disableScanners", parameters);
        }

        /// <summary>
        /// Enables all passive scanners
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <returns>Result of the action</returns>
        public IApiResult EnableAllScanners(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "enableAllScanners", parameters);
        }

        /// <summary>
        /// Enables all passive scanners with the given IDs (comma separated list of IDs)
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="ids">Comma separated list of IDs</param>
        /// <returns>Result of the action</returns>
        public IApiResult EnableScanners(string apikey, string ids)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("ids", ids);
            return _zapClient.CallApi(Component, "action", "enableScanners", parameters);
        }

        /// <summary>
        /// Sets whether or not the passive scanning is enabled
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="enabled">If scanning should be set enabled</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetEnabled(string apikey, bool enabled)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("enabled", enabled.ToString());
            return _zapClient.CallApi(Component, "action", "setEnabled", parameters);
        }

        /// <summary>
        /// Sets the alert threshold of the passive scanner with the given ID, accepted values for alert threshold: OFF, DEFAULT, LOW, MEDIUM and HIGH
        /// </summary>
        /// <param name="apikey">The api key for the Zap-server</param>
        /// <param name="id">ID of the passive scanner</param>
        /// <param name="alertThreshold">Accepted values for alert threshold: OFF, DEFAULT, LOW, MEDIUM and HIGH</param>
        /// <returns>Result of the action</returns>
        public IApiResult SetScannerAlertThreshold(string apikey, string id, string alertThreshold)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("id", id);
            parameters.Add("alertThreshold", alertThreshold);
            return _zapClient.CallApi(Component, "action", "setScannerAlertThreshold", parameters);
        }
    }
}
