using NZap.Entities;
using NZap.Enums;
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
            return _zapClient.CallApi(Component, ActionTypes.View, "isLatestVersion");
        }

        public IApiResult GetLatestVersionNumber()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "latestVersionNumber");
        }

        public IApiResult GetOptionAddonDirectories()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionAddonDirectories");
        }

        public IApiResult GetOptionCheckAddonUpdates()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionCheckAddonUpdates");
        }

        public IApiResult GetOptionCheckOnStart()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionCheckOnStart");
        }

        public IApiResult GetOptionDayLastChecked()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDayLastChecked");
        }

        public IApiResult GetOptionDayLastInstallWarned()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDayLastInstallWarned");
        }

        public IApiResult GetOptionDayLastUpdateWarned()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDayLastUpdateWarned");
        }

        public IApiResult GetOptionDownloadDirectory()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDownloadDirectory");
        }

        public IApiResult GetOptionDownloadNewRelease()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDownloadNewRelease");
        }

        public IApiResult GetOptionInstallAddonUpdates()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionInstallAddonUpdates");
        }

        public IApiResult GetOptionInstallScannerRules()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionInstallScannerRules");
        }

        public IApiResult GetOptionReportAlphaAddons()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionReportAlphaAddons");
        }

        public IApiResult GetOptionReportBetaAddons()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionReportBetaAddons");
        }

        public IApiResult GetOptionReportReleaseAddons()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionReportReleaseAddons");
        }

        public IApiResult DownloadLatestRelease(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "downloadLatestRelease", parameters);
        }

        public IApiResult SetOptionCheckAddonUpdates(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionCheckAddonUpdates");
        }

        public IApiResult SetOptionCheckOnStart(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionCheckOnStart");
        }

        public IApiResult SetOptionDownloadNewRelease(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionDownloadNewRelease");
        }

        public IApiResult SetOptionInstallAddonUpdates(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionInstallAddonUpdates");
        }

        public IApiResult SetOptionInstallScannerRules(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionInstallScannerRules");
        }

        public IApiResult SetOptionReportAlphaAddons(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionReportAlphaAddons");
        }

        public IApiResult SetOptionReportBetaAddons(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionReportBetaAddons");
        }

        public IApiResult SetOptionReportReleaseAddons(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionReportReleaseAddons");
        }
    }
}
