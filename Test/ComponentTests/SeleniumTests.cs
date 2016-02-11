using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class SeleniumTests : TestBase
    {
        #region Views
        [Test]
        public void TestGetOptionChromeDriverPathShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "ChromeDriverPath";
            var apiResult = ZapClient.Selenium.GetOptionChromeDriverPath();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionIeDriverPathShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "IeDriverPath";
            var apiResult = ZapClient.Selenium.GetOptionIeDriverPath();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetOptionPhantomJsBinaryPathShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "PhantomJsBinaryPath";
            var apiResult = ZapClient.Selenium.GetOptionPhantomJsBinaryPath();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }
        #endregion

        #region Actions
        [Test]
        public void TestSetOptionChromeDriverPathShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "Result";
            const string expectecValue = "OK";
            var apiResult = ZapClient.Selenium.SetOptionChromeDriverPath(Apikey, "1");
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }

        [Test]
        public void TestSetOptionIeDriverPathShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "Result";
            const string expectecValue = "OK";
            var apiResult = ZapClient.Selenium.SetOptionIeDriverPath(Apikey, "1");
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }

        [Test]
        public void TestSetOptionPhantomJsBinaryPathShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "Result";
            const string expectecValue = "OK";
            var apiResult = ZapClient.Selenium.SetOptionPhantomJsBinaryPath(Apikey, "1");
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }
        #endregion
    }
}
