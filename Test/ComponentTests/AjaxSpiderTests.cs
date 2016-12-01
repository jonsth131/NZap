using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class AjaxSpiderTests : TestBase
    {
        [Test]
        public void TestGetNumberOfResultsShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "numberOfResults";
            var apiResult = ZapClient.AjaxSpider.GetNumberOfResults();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionBrowserIdShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "BrowserId";
            var apiResult = ZapClient.AjaxSpider.GetOptionBrowserId();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionClickDefaultElemsShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ClickDefaultElems";
            var apiResult = ZapClient.AjaxSpider.GetOptionClickDefaultElems();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionClickElemsOnceShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ClickElemsOnce";
            var apiResult = ZapClient.AjaxSpider.GetOptionClickElemsOnce();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionEventWaitShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "EventWait";
            var apiResult = ZapClient.AjaxSpider.GetOptionEventWait();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionMaxCrawlDepthShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "MaxCrawlDepth";
            var apiResult = ZapClient.AjaxSpider.GetOptionMaxCrawlDepth();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionMaxCrawlStatesShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "MaxCrawlStates";
            var apiResult = ZapClient.AjaxSpider.GetOptionMaxCrawlStates();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionMaxDurationShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "MaxDuration";
            var apiResult = ZapClient.AjaxSpider.GetOptionMaxDuration();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionNumberOfBrowsersShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "NumberOfBrowsers";
            var apiResult = ZapClient.AjaxSpider.GetOptionNumberOfBrowsers();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionRandomInputsShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "RandomInputs";
            var apiResult = ZapClient.AjaxSpider.GetOptionRandomInputs();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionReloadWaitShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ReloadWait";
            var apiResult = ZapClient.AjaxSpider.GetOptionReloadWait();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestSetOptionClickDefaultElems()
        {
            const int expected = 0;
            var apiResult = ZapClient.AjaxSpider.SetOptionClickDefaultElems(Apikey, true);
            ActionResultAsserts(apiResult, expected);
        }
    }
}
