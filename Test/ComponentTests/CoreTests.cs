using System.Collections.Generic;
using System.Linq;
using System.Net;
using NZap.Exceptions;
using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class CoreTests : TestBase
    {
        #region Views
        [Test]
        public void TestGetAlertsShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetAlerts();
            Assert.IsNotNull(apiResult);
        }

        [Test]
        public void TestGetAlertsWithParametersShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetAlerts("localhost", 1, 1);
            Assert.IsNotNull(apiResult);
        }

        [Test]
        public void TestGetExcludedFromProxyShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetExcludedFromProxy();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetHomeDirectoryShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "homeDirectory";
            var apiResult = ZapClient.Core.GetHomeDirectory();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetHostsShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetHosts();
            Assert.IsNull(apiResult.Key);
            Assert.IsNull(apiResult.Value);
        }

        [Test]
        public void TestGetMessagesShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetMessages();
            Assert.IsNull(apiResult.Key);
            Assert.IsNull(apiResult.Value);
        }

        [Test]
        public void TestGetMessagesWithParametersShouldSucceed()
        {
            const int expected = 0;
            var parameters = new Dictionary<string, string> { { "baseurl", "localhost" }, { "start", "1" }, { "count", "1" } };
            var apiResult = ZapClient.Core.GetMessages(parameters);
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetNumberOfAlertsShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfAlerts";
            var apiResult = ZapClient.Core.GetNumberOfAlerts();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetNumberOfAlertsWithParametersShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfAlerts";
            var parameters = new Dictionary<string, string> { { "baseurl", "localhost" } };
            var apiResult = ZapClient.Core.GetNumberOfAlerts(parameters);
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetNumberOfMessagesShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfMessages";
            var apiResult = ZapClient.Core.GetNumberOfMessages();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetNumberOfMessagesWithParametersShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfMessages";
            var parameters = new Dictionary<string, string> { { "baseurl", "localhost" } };
            var apiResult = ZapClient.Core.GetNumberOfMessages(parameters);
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionDefaultUserAgentShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "DefaultUserAgent";
            var apiResult = ZapClient.Core.GetOptionDefaultUserAgent();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionHttpStateShouldThrowException()
        {
            const string expectedExceptionMessage = " (500) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.Core.GetOptionHttpState());
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void TestGetOptionHttpStateEnabledShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "HttpStateEnabled";
            var apiResult = ZapClient.Core.GetOptionHttpStateEnabled();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainNameShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainName";
            var apiResult = ZapClient.Core.GetOptionProxyChainName();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainPasswordShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainPassword";
            var apiResult = ZapClient.Core.GetOptionProxyChainPassword();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainPortShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainPort";
            var apiResult = ZapClient.Core.GetOptionProxyChainPort();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainPromptShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainPrompt";
            var apiResult = ZapClient.Core.GetOptionProxyChainPrompt();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainRealmShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainRealm";
            var apiResult = ZapClient.Core.GetOptionProxyChainRealm();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainSkipNameShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainSkipName";
            var apiResult = ZapClient.Core.GetOptionProxyChainSkipName();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainUserNameShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainUserName";
            var apiResult = ZapClient.Core.GetOptionProxyChainUserName();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyExcludedDomainsShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetOptionProxyExcludedDomains();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetOptionProxyExcludedDomainsEnabledShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetOptionProxyExcludedDomainsEnabled();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetOptionSingleCookieRequestHeaderShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "SingleCookieRequestHeader";
            var apiResult = ZapClient.Core.GetOptionSingleCookieRequestHeader();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionTimeoutInSecsShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "TimeoutInSecs";
            var apiResult = ZapClient.Core.GetOptionTimeoutInSecs();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionUseProxyChainShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "UseProxyChain";
            var apiResult = ZapClient.Core.GetOptionUseProxyChain();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionUseProxyChainAuthShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "UseProxyChain";
            var apiResult = ZapClient.Core.GetOptionUseProxyChainAuth();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetSitesShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetSites();
            Assert.IsNull(apiResult.Key);
            Assert.IsNull(apiResult.Value);
        }

        [Test]
        public void TestGetStatsShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetStats();
            var actual = apiResult.ResultList.Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetStatsWithParametersShouldSucceed()
        {
            const int expected = 0;
            var parameters = new Dictionary<string, string> { { "keyPrefix", "1" } };
            var apiResult = ZapClient.Core.GetNumberOfMessages(parameters);
            var actual = apiResult.ResultList.Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetUrlsShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetUrls();
            Assert.IsNull(apiResult.Key);
            Assert.IsNull(apiResult.Value);
        }

        [Test]
        public void TestGetVersionShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "version";
            var apiResult = ZapClient.Core.GetVersion();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }
        #endregion

        #region Actions
        [Test]
        public void TestClearExcludedFromProxyWithInvalidApikeyShouldThrowException()
        {
            const string expectedExceptionMessage = "No apikey supplied!";
            var webException = Assert.Throws<ZapApiException>(() => ZapClient.Core.ClearExcludedFromProxy(null));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void TestClearExcludedFromProxyShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.ClearExcludedFromProxy(Apikey);
            ActionResultAsserts(apiResult, expected);
        }
        #endregion

        [Test]
        public void GetHtmlReportShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetHtmlReport(Apikey);
            Assert.IsNotNull(apiResult.ReportData);
        }

        [Test]
        public void GetXmlReportShouldSucceed()
        {
            var apiResult = ZapClient.Core.GetXmlReport(Apikey);
            Assert.IsNotNull(apiResult.ReportData);
        }
    }
}
