using NUnit.Framework;
using NZap.Enums;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class PscanTests : TestBase
    {
        #region Views
        [Test]
        public void TestGetRecordsToScanShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "recordsToScan";
            var apiResult = ZapClient.Pscan.GetRecordsToScan();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestGetScannersShouldSucceed()
        {
            const int expected = 1;
            const string expectedKey = "scanners";
            var apiResult = ZapClient.Pscan.GetScanners();
            ResultAsserts(apiResult, expected, expectedKey);
        }
        #endregion

        #region Actions
        [Test]
        public void TestDisableAllScannersShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.DisableAllScanners(Apikey);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestDisableScannersShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.DisableScanners(Apikey, "1");
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestEnableAllScannersShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.EnableAllScanners(Apikey);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestEnableScannersShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.EnableScanners(Apikey, "1");
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetEnabledFalseShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetEnabled(Apikey, false);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetEnabledTrueShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetEnabled(Apikey, true);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetScannerAlertThresholdToDefaultShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetScannerAlertThreshold(Apikey, "50001", AlertThreshold.DEFAULT);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetScannerAlertThresholdToHighShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetScannerAlertThreshold(Apikey, "50001", AlertThreshold.HIGH);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetScannerAlertThresholdToLowShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetScannerAlertThreshold(Apikey, "50001", AlertThreshold.LOW);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetScannerAlertThresholdToMediumShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetScannerAlertThreshold(Apikey, "50001", AlertThreshold.MEDIUM);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetScannerAlertThresholdToOffShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Pscan.SetScannerAlertThreshold(Apikey, "50001", AlertThreshold.OFF);
            ActionResultAsserts(apiResult, expected);
        }
        #endregion
    }
}
