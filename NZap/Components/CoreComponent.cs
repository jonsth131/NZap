using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    public interface ICoreComponent
    {
        /* VIEWS */
        IAlertResult GetAlert(int id);
        List<IAlertResult> GetAlerts(string baseurl = "", int start = 0, int count = 0);
        IApiResult GetExcludedFromProxy();
        IApiResult GetHomeDirectory();
        IApiResult GetHosts();
        IApiResult GetMessage(string id);
        IApiResult GetMessages(IDictionary<string, string> parameters = null);
        IApiResult GetNumberOfAlerts(IDictionary<string, string> parameters = null);
        IApiResult GetNumberOfMessages(IDictionary<string, string> parameters = null);
        IApiResult GetOptionDefaultUserAgent();
        IApiResult GetOptionHttpState();
        IApiResult GetOptionHttpStateEnabled();
        IApiResult GetOptionProxyChainName();
        IApiResult GetOptionProxyChainPassword();
        IApiResult GetOptionProxyChainPort();
        IApiResult GetOptionProxyChainPrompt();
        IApiResult GetOptionProxyChainRealm();
        IApiResult GetOptionProxyChainSkipName();
        IApiResult GetOptionProxyChainUserName();
        IApiResult GetOptionProxyExcludedDomains();
        IApiResult GetOptionProxyExcludedDomainsEnabled();
        IApiResult GetOptionSingleCookieRequestHeader();
        IApiResult GetOptionTimeoutInSecs();
        IApiResult GetOptionUseProxyChain();
        IApiResult GetOptionUseProxyChainAuth();
        IApiResult GetSites();
        IApiResult GetUrls();
        IApiResult GetVersion();

        /* ACTIONS */

        IApiResult ClearExcludedFromProxy(string apikey);
        IApiResult ClearStats(string apikey, string keyPrefix);
        IApiResult DeleteAllAlerts(string apikey);
        IApiResult ExcludeFromProxy(string apikey, string regex);
        IApiResult GenerateRootCa(string apikey);
        IApiResult LoadSession(string apikey, string name);
        IApiResult NewSession(string apikey, IDictionary<string, string> parameters = null);
        IApiResult RunGarbageCollection(string apikey);
        IApiResult SaveSession(string apikey, string name, string overwrite = null);
        IApiResult SendRequest(string apikey, string request, string followRedirects = null);
        IApiResult SetHomeDirectory(string apikey, string dir);
        IApiResult SetOptionDefaultUserAgent(string apikey, string defaultUserAgent);
        IApiResult SetOptionHttpStateEnabled(string apikey, bool option);
        IApiResult SetOptionProxyChainName(string apikey, string proxyChainName);
        IApiResult SetOptionProxyChainPassword(string apikey, string proxyChainPassword);
        IApiResult SetOptionProxyChainPort(string apikey, int port);
        IApiResult SetOptionProxyChainPrompt(string apikey, bool option);
        IApiResult SetOptionProxyChainRealm(string apikey, string proxyChainRealm);
        IApiResult SetOptionProxyChainSkipName(string apikey, string proxyChainSkipName);
        IApiResult SetOptionProxyChainUserName(string apikey, string proxyChainUserName);
        IApiResult SetOptionSingleCookieRequestHeader(string apikey, bool option);
        IApiResult SetOptionTimeoutInSecs(string apikey, int secs);
        IApiResult SetOptionUseProxyChain(string apikey, bool option);
        IApiResult SetOptionUseProxyChainAuth(string apikey, bool option);
        IApiResult Shutdown(string apikey);
        IApiResult SnapshotSession(string apikey);


        /* OTHERS */
        IReportResponse GetHtmlReport(string apikey);
        IReportResponse GetXmlReport(string apikey);
        /* TODO:
Others

messageHar (id* )	Gets the message with the given ID in HAR format
messagesHar (baseurl start count )	Gets the HTTP messages sent through/by ZAP, in HAR format, optionally filtered by URL and paginated with 'start' position and 'count' of messages
proxy.pac ()	
rootcert ()	
sendHarRequest (request* followRedirects )	Sends the first HAR request entry, optionally following redirections. Returns, in HAR format, the request sent and response received and followed redirections, if any.
setproxy (proxy* )	
    */
    }

    internal class CoreComponent : ICoreComponent
    {
        private const string Component = "core";

        private readonly IZapClient _zapClient;
        private readonly CommonActions _commonActions;

        public CoreComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
            _commonActions = new CommonActions(zapClient, Component);
        }

        public IAlertResult GetAlert(int id)
        {
            var parameters = new Dictionary<string, string>
            {
                {"id", id.ToString()}
            };
            var result = GetAlertApiResult("alert", parameters);
            return SerializationHelper.DeserializeJsonToAlertResult(result);
        }

        public List<IAlertResult> GetAlerts(string baseurl = "", int start = 0, int count = 0)
        {
            var parameters = new Dictionary<string, string>
            {
                {"baseurl", baseurl},
                {"start", start.ToString()},
                {"count", count.ToString()}
            };
            var result = GetAlertApiResult("alerts", parameters);
            return SerializationHelper.DeserializeJsonToAlertResultList(result);
        }

        public IApiResult GetExcludedFromProxy()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "excludedFromProxy");
        }

        public IApiResult GetHomeDirectory()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "homeDirectory");
        }

        public IApiResult GetHosts()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "hosts");
        }

        public IApiResult GetMessage(string id)
        {
            var parameters = new Dictionary<string, string> { { "id", id } };
            return _zapClient.CallApi(Component, ActionTypes.View, "message", parameters);
        }

        public IApiResult GetMessages(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "messages", parameters);
        }

        public IApiResult GetNumberOfAlerts(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "numberOfAlerts", parameters);
        }

        public IApiResult GetNumberOfMessages(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "numberOfMessages", parameters);
        }

        public IApiResult GetOptionDefaultUserAgent()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionDefaultUserAgent");
        }

        public IApiResult GetOptionHttpState()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionHttpState");
        }

        public IApiResult GetOptionHttpStateEnabled()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionHttpStateEnabled");
        }

        public IApiResult GetOptionProxyChainName()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainName");
        }

        public IApiResult GetOptionProxyChainPassword()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainPassword");
        }

        public IApiResult GetOptionProxyChainPort()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainPort");
        }

        public IApiResult GetOptionProxyChainPrompt()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainPrompt");
        }

        public IApiResult GetOptionProxyChainRealm()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainRealm");
        }

        public IApiResult GetOptionProxyChainSkipName()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainSkipName");
        }

        public IApiResult GetOptionProxyChainUserName()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyChainUserName");
        }

        public IApiResult GetOptionProxyExcludedDomains()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyExcludedDomains");
        }

        public IApiResult GetOptionProxyExcludedDomainsEnabled()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionProxyExcludedDomainsEnabled");
        }

        public IApiResult GetOptionSingleCookieRequestHeader()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionSingleCookieRequestHeader");
        }

        public IApiResult GetOptionTimeoutInSecs()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionTimeoutInSecs");
        }

        public IApiResult GetOptionUseProxyChain()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionUseProxyChain");
        }

        public IApiResult GetOptionUseProxyChainAuth()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "optionUseProxyChainAuth");
        }

        public IApiResult GetSites()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "sites");
        }

        public IApiResult GetUrls()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "urls");
        }

        public IApiResult GetVersion()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "version");
        }

        public IApiResult ClearExcludedFromProxy(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "clearExcludedFromProxy", parameters);
        }

        public IApiResult ClearStats(string apikey, string keyPrefix)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("keyPrefix", keyPrefix);
            return _zapClient.CallApi(Component, ActionTypes.Action, "clearStats", parameters);
        }

        public IApiResult DeleteAllAlerts(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "deleteAllAlerts", parameters);
        }

        public IApiResult ExcludeFromProxy(string apikey, string regex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, ActionTypes.Action, "excludeFromProxy", parameters);
        }

        public IApiResult GenerateRootCa(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "GenerateRootCA", parameters);
        }

        public IApiResult LoadSession(string apikey, string name)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("name", name);
            return _zapClient.CallApi(Component, ActionTypes.Action, "loadSession", parameters);
        }

        public IApiResult NewSession(string apikey, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            return _zapClient.CallApi(Component, ActionTypes.Action, "newSession", parameters);
        }

        public IApiResult RunGarbageCollection(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "runGarbageCollection", parameters);
        }

        public IApiResult SaveSession(string apikey, string name, string overwrite = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("name", name);
            if (overwrite != null) parameters.Add("overwrite", overwrite);
            return _zapClient.CallApi(Component, ActionTypes.Action, "saveSession", parameters);
        }

        public IApiResult SendRequest(string apikey, string request, string followRedirects = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("request", request);
            if (followRedirects != null) parameters.Add("followRedirects", followRedirects);
            return _zapClient.CallApi(Component, ActionTypes.Action, "sendRequest", parameters);
        }

        public IApiResult SetHomeDirectory(string apikey, string dir)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("dir", dir);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setHomeDirectory", parameters);
        }

        public IApiResult SetOptionDefaultUserAgent(string apikey, string defaultUserAgent)
        {
            return _commonActions.ActionWithParameter(apikey, defaultUserAgent, "setOptionDefaultUserAgent");
        }

        public IApiResult SetOptionHttpStateEnabled(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionHttpStateEnabled");
        }

        public IApiResult SetOptionProxyChainName(string apikey, string proxyChainName)
        {
            return _commonActions.ActionWithParameter(apikey, proxyChainName, "setOptionProxyChainName");
        }

        public IApiResult SetOptionProxyChainPassword(string apikey, string proxyChainPassword)
        {
            return _commonActions.ActionWithParameter(apikey, proxyChainPassword, "setOptionProxyChainPassword");
        }

        public IApiResult SetOptionProxyChainPort(string apikey, int port)
        {
            return _commonActions.ActionWithParameter(apikey, port, "setOptionProxyChainPort");
        }

        public IApiResult SetOptionProxyChainPrompt(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionProxyChainPrompt");
        }

        public IApiResult SetOptionProxyChainRealm(string apikey, string proxyChainRealm)
        {
            return _commonActions.ActionWithParameter(apikey, proxyChainRealm, "setOptionProxyChainRealm");
        }

        public IApiResult SetOptionProxyChainSkipName(string apikey, string proxyChainSkipName)
        {
            return _commonActions.ActionWithParameter(apikey, proxyChainSkipName, "setOptionProxyChainSkipName");
        }

        public IApiResult SetOptionProxyChainUserName(string apikey, string proxyChainUserName)
        {
            return _commonActions.ActionWithParameter(apikey, proxyChainUserName, "setOptionProxyChainUserName");
        }

        public IApiResult SetOptionSingleCookieRequestHeader(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionSingleCookieRequestHeader");
        }

        public IApiResult SetOptionTimeoutInSecs(string apikey, int secs)
        {
            return _commonActions.ActionWithParameter(apikey, secs, "setOptionTimeoutInSecs");
        }

        public IApiResult SetOptionUseProxyChain(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionUseProxyChain");
        }

        public IApiResult SetOptionUseProxyChainAuth(string apikey, bool option)
        {
            return _commonActions.ActionWithParameter(apikey, option, "setOptionUseProxyChainAuth");
        }

        public IApiResult Shutdown(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "shutdown", parameters);
        }

        public IApiResult SnapshotSession(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, ActionTypes.Action, "snapshotSession", parameters);
        }

        public IReportResponse GetHtmlReport(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallReportApi(Component, ActionTypes.Other, "htmlreport", parameters);
        }

        public IReportResponse GetXmlReport(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallReportApi(Component, ActionTypes.Other, "xmlreport", parameters);
        }

        private string GetAlertApiResult(string action, IDictionary<string, string> parameters)
        {
            var uri = UriHelper.CreateUriStringFromParameters("core", ActionTypes.View, action);
            var requestUri = UriHelper.BuildZapUri(_zapClient.Host, _zapClient.Port, uri, _zapClient.Protocol, parameters);
            var result = _zapClient.GetApiResult(requestUri);
            return result;
        }
    }
}
