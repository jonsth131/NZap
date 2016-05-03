using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IAutoupdateComponent
    {
        /* VIEWS */
        IApiResult GetIsLatestVersion();
        IApiResult GetLatestVersionNumber();
        IApiResult GetOptionAddonDirectories();
        IApiResult GetOptionCheckAddonUpdates();
        IApiResult GetOptionCheckOnStart();
        IApiResult GetOptionDayLastChecked();
        IApiResult GetOptionDayLastInstallWarned();
        IApiResult GetOptionDayLastUpdateWarned();
        IApiResult GetOptionDownloadDirectory();
        IApiResult GetOptionDownloadNewRelease();
        IApiResult GetOptionInstallAddonUpdates();
        IApiResult GetOptionInstallScannerRules();
        IApiResult GetOptionReportAlphaAddons();
        IApiResult GetOptionReportBetaAddons();
        IApiResult GetOptionReportReleaseAddons();

        /* ACTIONS */
        IApiResult DownloadLatestRelease(string apikey);
        IApiResult SetOptionCheckAddonUpdates(string apikey, bool option);
        IApiResult SetOptionCheckOnStart(string apikey, bool option);
        IApiResult SetOptionDownloadNewRelease(string apikey, bool option);
        IApiResult SetOptionInstallAddonUpdates(string apikey, bool option);
        IApiResult SetOptionInstallScannerRules(string apikey, bool option);
        IApiResult SetOptionReportAlphaAddons(string apikey, bool option);
        IApiResult SetOptionReportBetaAddons(string apikey, bool option);
        IApiResult SetOptionReportReleaseAddons(string apikey, bool option);
    }

    internal class AutoupdateComponent : IAutoupdateComponent
    {
        private const string Component = "autoupdate";

        private readonly IZapClient _zapClient;
        private readonly CommonActions _commonActions;

        public AutoupdateComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
            _commonActions = new CommonActions(zapClient, Component);
        }

        public IApiResult GetIsLatestVersion()
        {
            return _zapClient.CallApi(Component, "view", "isLatestVersion");
        }

        public IApiResult GetLatestVersionNumber()
        {
            return _zapClient.CallApi(Component, "view", "latestVersionNumber");
        }

        public IApiResult GetOptionAddonDirectories()
        {
            return _zapClient.CallApi(Component, "view", "optionAddonDirectories");
        }

        public IApiResult GetOptionCheckAddonUpdates()
        {
            return _zapClient.CallApi(Component, "view", "optionCheckAddonUpdates");
        }

        public IApiResult GetOptionCheckOnStart()
        {
            return _zapClient.CallApi(Component, "view", "optionCheckOnStart");
        }

        public IApiResult GetOptionDayLastChecked()
        {
            return _zapClient.CallApi(Component, "view", "optionDayLastChecked");
        }

        public IApiResult GetOptionDayLastInstallWarned()
        {
            return _zapClient.CallApi(Component, "view", "optionDayLastInstallWarned");
        }

        public IApiResult GetOptionDayLastUpdateWarned()
        {
            return _zapClient.CallApi(Component, "view", "optionDayLastUpdateWarned");
        }

        public IApiResult GetOptionDownloadDirectory()
        {
            return _zapClient.CallApi(Component, "view", "optionDownloadDirectory");
        }

        public IApiResult GetOptionDownloadNewRelease()
        {
            return _zapClient.CallApi(Component, "view", "optionDownloadNewRelease");
        }

        public IApiResult GetOptionInstallAddonUpdates()
        {
            return _zapClient.CallApi(Component, "view", "optionInstallAddonUpdates");
        }

        public IApiResult GetOptionInstallScannerRules()
        {
            return _zapClient.CallApi(Component, "view", "optionInstallScannerRules");
        }

        public IApiResult GetOptionReportAlphaAddons()
        {
            return _zapClient.CallApi(Component, "view", "optionReportAlphaAddons");
        }

        public IApiResult GetOptionReportBetaAddons()
        {
            return _zapClient.CallApi(Component, "view", "optionReportBetaAddons");
        }

        public IApiResult GetOptionReportReleaseAddons()
        {
            return _zapClient.CallApi(Component, "view", "optionReportReleaseAddons");
        }

        public IApiResult DownloadLatestRelease(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "downloadLatestRelease", parameters);
        }

        public IApiResult SetOptionCheckAddonUpdates(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionCheckAddonUpdates");
        }

        public IApiResult SetOptionCheckOnStart(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionCheckOnStart");
        }

        public IApiResult SetOptionDownloadNewRelease(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionDownloadNewRelease");
        }

        public IApiResult SetOptionInstallAddonUpdates(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionInstallAddonUpdates");
        }

        public IApiResult SetOptionInstallScannerRules(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionInstallScannerRules");
        }

        public IApiResult SetOptionReportAlphaAddons(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionReportAlphaAddons");
        }

        public IApiResult SetOptionReportBetaAddons(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionReportBetaAddons");
        }

        public IApiResult SetOptionReportReleaseAddons(string apikey, bool option)
        {
            return _commonActions.ActionWithParameterBoolean(apikey, option, "setOptionReportReleaseAddons");
        }
    }
}
