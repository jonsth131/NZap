using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class RevealTests : TestBase
    {
        #region Views
        [Test]
        public void TestGetRevealShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "reveal";
            const string expectecValue = "true";
            var apiResult = ZapClient.Reveal.GetReveal();
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }
        #endregion

        #region Actions
        [Test]
        public void TestSetRevealToTrueShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "Result";
            const string expectecValue = "OK";
            var apiResult = ZapClient.Reveal.SetReveal(Apikey, true);
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }

        [Test]
        public void TestSetRevealToFalseShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "Result";
            const string expectecValue = "OK";
            var apiResult = ZapClient.Reveal.SetReveal(Apikey, false);
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }
        #endregion
    }
}
