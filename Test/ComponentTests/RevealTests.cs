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
            var apiResult = ZapClient.Reveal.GetReveal();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }
        #endregion

        #region Actions
        [Test]
        public void TestSetRevealToTrueShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Reveal.SetReveal(Apikey, true);
            ActionResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestSetRevealToFalseShouldSucceed()
        {
            const int expected = 0;
            var apiResult = ZapClient.Reveal.SetReveal(Apikey, false);
            ActionResultAsserts(apiResult, expected);
        }
        #endregion
    }
}
