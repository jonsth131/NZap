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
            const int expected = 0;
            var apiResult = ZapClient.Core.GetAlerts();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetAlertsWithParametersShouldSucceed()
        {
            const int expected = 0;
            var parameters = new Dictionary<string, string> { { "baseurl", "localhost" }, { "start", "1" }, { "count", "1" } };
            var apiResult = ZapClient.Core.GetAlerts(parameters);
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
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
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetHostsShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetHosts();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetMessagesShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetMessages();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
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
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetNumberOfAlertsWithParametersShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfAlerts";
            var parameters = new Dictionary<string, string> { { "baseurl", "localhost" } };
            var apiResult = ZapClient.Core.GetNumberOfAlerts(parameters);
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetNumberOfMessagesShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfMessages";
            var apiResult = ZapClient.Core.GetNumberOfMessages();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetNumberOfMessagesWithParametersShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfMessages";
            var parameters = new Dictionary<string, string> { { "baseurl", "localhost" } };
            var apiResult = ZapClient.Core.GetNumberOfMessages(parameters);
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionDefaultUserAgentShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "DefaultUserAgent";
            var apiResult = ZapClient.Core.GetOptionDefaultUserAgent();
            ResultAsserts(apiResult, expected, expectedKey);
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
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainNameShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainName";
            var apiResult = ZapClient.Core.GetOptionProxyChainName();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainPasswordShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainPassword";
            var apiResult = ZapClient.Core.GetOptionProxyChainPassword();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainPortShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainPort";
            var apiResult = ZapClient.Core.GetOptionProxyChainPort();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainPromptShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainPrompt";
            var apiResult = ZapClient.Core.GetOptionProxyChainPrompt();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainRealmShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainRealm";
            var apiResult = ZapClient.Core.GetOptionProxyChainRealm();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainSkipNameShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainSkipName";
            var apiResult = ZapClient.Core.GetOptionProxyChainSkipName();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionProxyChainUserNameShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ProxyChainUserName";
            var apiResult = ZapClient.Core.GetOptionProxyChainUserName();
            ResultAsserts(apiResult, expected, expectedKey);
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
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionTimeoutInSecsShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "TimeoutInSecs";
            var apiResult = ZapClient.Core.GetOptionTimeoutInSecs();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionUseProxyChainShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "UseProxyChain";
            var apiResult = ZapClient.Core.GetOptionUseProxyChain();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionUseProxyChainAuthShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "UseProxyChain";
            var apiResult = ZapClient.Core.GetOptionUseProxyChainAuth();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetSitesShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Core.GetSites();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
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
            const int expected = 0;
            var apiResult = ZapClient.Core.GetUrls();
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetVersionShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "version";
            var apiResult = ZapClient.Core.GetVersion();
            ResultAsserts(apiResult, expected, expectedKey);
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


    }
}
