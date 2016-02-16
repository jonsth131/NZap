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
        IApiResult GetStats(IDictionary<string, string> parameters = null);
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

    public class CoreComponent : ICoreComponent
    {
        private const string Component = "core";

        private readonly IZapClient _zapClient;

        public CoreComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IAlertResult GetAlert(int id)
        {
            var parameters = new Dictionary<string, string>
            {
                {"id", id.ToString()}
            };
            var uri = UriHelper.CreateUriStringFromParameters("core", "view", "alert");
            var requestUri = UriHelper.BuildZapUri(_zapClient.Host, _zapClient.Port, uri, _zapClient.Protocol,  parameters);
            var result = _zapClient.GetApiResult(requestUri);
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
            var uri = UriHelper.CreateUriStringFromParameters("core", "view", "alerts");
            var requestUri = UriHelper.BuildZapUri(_zapClient.Host, _zapClient.Port, uri, _zapClient.Protocol, parameters);
            var result = _zapClient.GetApiResult(requestUri);
            return SerializationHelper.DeserializeJsonToAlertResultList(result);
        }

        public IApiResult GetExcludedFromProxy()
        {
            return _zapClient.CallApi(Component, "view", "excludedFromProxy");
        }

        public IApiResult GetHomeDirectory()
        {
            return _zapClient.CallApi(Component, "view", "homeDirectory");
        }

        public IApiResult GetHosts()
        {
            return _zapClient.CallApi(Component, "view", "hosts");
        }

        public IApiResult GetMessage(string id)
        {
            var parameters = new Dictionary<string, string> { { "id", id } };
            return _zapClient.CallApi(Component, "view", "message", parameters);
        }

        public IApiResult GetMessages(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "messages", parameters);
        }

        public IApiResult GetNumberOfAlerts(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "numberOfAlerts", parameters);
        }

        public IApiResult GetNumberOfMessages(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "numberOfMessages", parameters);
        }

        public IApiResult GetOptionDefaultUserAgent()
        {
            return _zapClient.CallApi(Component, "view", "optionDefaultUserAgent");
        }

        public IApiResult GetOptionHttpState()
        {
            return _zapClient.CallApi(Component, "view", "optionHttpState");
        }

        public IApiResult GetOptionHttpStateEnabled()
        {
            return _zapClient.CallApi(Component, "view", "optionHttpStateEnabled");
        }

        public IApiResult GetOptionProxyChainName()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainName");
        }

        public IApiResult GetOptionProxyChainPassword()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainPassword");
        }

        public IApiResult GetOptionProxyChainPort()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainPort");
        }

        public IApiResult GetOptionProxyChainPrompt()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainPrompt");
        }

        public IApiResult GetOptionProxyChainRealm()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainRealm");
        }

        public IApiResult GetOptionProxyChainSkipName()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainSkipName");
        }

        public IApiResult GetOptionProxyChainUserName()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyChainUserName");
        }

        public IApiResult GetOptionProxyExcludedDomains()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyExcludedDomains");
        }

        public IApiResult GetOptionProxyExcludedDomainsEnabled()
        {
            return _zapClient.CallApi(Component, "view", "optionProxyExcludedDomainsEnabled");
        }

        public IApiResult GetOptionSingleCookieRequestHeader()
        {
            return _zapClient.CallApi(Component, "view", "optionSingleCookieRequestHeader");
        }

        public IApiResult GetOptionTimeoutInSecs()
        {
            return _zapClient.CallApi(Component, "view", "optionTimeoutInSecs");
        }

        public IApiResult GetOptionUseProxyChain()
        {
            return _zapClient.CallApi(Component, "view", "optionUseProxyChain");
        }

        public IApiResult GetOptionUseProxyChainAuth()
        {
            return _zapClient.CallApi(Component, "view", "optionUseProxyChainAuth");
        }

        public IApiResult GetSites()
        {
            return _zapClient.CallApi(Component, "view", "sites");
        }

        public IApiResult GetStats(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "stats", parameters);
        }

        public IApiResult GetUrls()
        {
            return _zapClient.CallApi(Component, "view", "urls");
        }

        public IApiResult GetVersion()
        {
            return _zapClient.CallApi(Component, "view", "version");
        }

        public IApiResult ClearExcludedFromProxy(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "clearExcludedFromProxy", parameters);
        }

        public IApiResult ClearStats(string apikey, string keyPrefix)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("keyPrefix", keyPrefix);
            return _zapClient.CallApi(Component, "action", "clearStats", parameters);
        }

        public IApiResult DeleteAllAlerts(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "deleteAllAlerts", parameters);
        }

        public IApiResult ExcludeFromProxy(string apikey, string regex)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "action", "excludeFromProxy", parameters);
        }

        public IApiResult GenerateRootCa(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "GenerateRootCA", parameters);
        }

        public IApiResult LoadSession(string apikey, string name)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("name", name);
            return _zapClient.CallApi(Component, "action", "loadSession", parameters);
        }

        public IApiResult NewSession(string apikey, IDictionary<string, string> parameters = null)
        {
            parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey, parameters);
            return _zapClient.CallApi(Component, "action", "newSession", parameters);
        }

        public IApiResult RunGarbageCollection(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "runGarbageCollection", parameters);
        }

        public IApiResult SaveSession(string apikey, string name, string overwrite = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("name", name);
            if (overwrite != null) parameters.Add("overwrite", overwrite);
            return _zapClient.CallApi(Component, "action", "saveSession", parameters);
        }

        public IApiResult SendRequest(string apikey, string request, string followRedirects = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("request", request);
            if (followRedirects != null) parameters.Add("followRedirects", followRedirects);
            return _zapClient.CallApi(Component, "action", "sendRequest", parameters);
        }

        public IApiResult SetHomeDirectory(string apikey, string dir)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("dir", dir);
            return _zapClient.CallApi(Component, "action", "setHomeDirectory", parameters);
        }

        public IApiResult SetOptionDefaultUserAgent(string apikey, string defaultUserAgent)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", defaultUserAgent);
            return _zapClient.CallApi(Component, "action", "setOptionDefaultUserAgent", parameters);
        }

        public IApiResult SetOptionHttpStateEnabled(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionHttpStateEnabled", parameters);
        }

        public IApiResult SetOptionProxyChainName(string apikey, string proxyChainName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", proxyChainName);
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainName", parameters);
        }

        public IApiResult SetOptionProxyChainPassword(string apikey, string proxyChainPassword)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", proxyChainPassword);
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainPassword", parameters);
        }

        public IApiResult SetOptionProxyChainPort(string apikey, int port)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", port.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainPort", parameters);
        }

        public IApiResult SetOptionProxyChainPrompt(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainPrompt", parameters);
        }

        public IApiResult SetOptionProxyChainRealm(string apikey, string proxyChainRealm)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", proxyChainRealm);
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainRealm", parameters);
        }

        public IApiResult SetOptionProxyChainSkipName(string apikey, string proxyChainSkipName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", proxyChainSkipName);
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainSkipName", parameters);
        }

        public IApiResult SetOptionProxyChainUserName(string apikey, string proxyChainUserName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", proxyChainUserName);
            return _zapClient.CallApi(Component, "action", "setOptionProxyChainUserName", parameters);
        }

        public IApiResult SetOptionSingleCookieRequestHeader(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionSingleCookieRequestHeader", parameters);
        }

        public IApiResult SetOptionTimeoutInSecs(string apikey, int secs)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", secs.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionTimeoutInSecs", parameters);
        }

        public IApiResult SetOptionUseProxyChain(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionUseProxyChain", parameters);
        }

        public IApiResult SetOptionUseProxyChainAuth(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(Component, "action", "setOptionUseProxyChainAuth", parameters);
        }

        public IApiResult Shutdown(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "shutdown", parameters);
        }

        public IApiResult SnapshotSession(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallApi(Component, "action", "snapshotSession", parameters);
        }

        public IReportResponse GetHtmlReport(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallReportApi(Component, "other", "htmlreport", parameters);
        }

        public IReportResponse GetXmlReport(string apikey)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            return _zapClient.CallReportApi(Component, "other", "xmlreport", parameters);
        }
    }
}
