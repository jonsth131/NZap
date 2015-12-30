using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class AcsrfTests : TestBase
    {
        [Test]
        public void TestGetOptionTokenNamesShouldSucceed()
        {
            const int expected = 1;
            const string expectedKey = "TokensNames";
            var apiResult = ZapClient.Acsrf.GetOptionTokenNames();
            ResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestAddAndRemoveOptionTokenShouldSucceed()
        {
            const int expected = 1;
            var apiResult = ZapClient.Acsrf.AddOptionToken(Apikey, "test");
            ActionResultAsserts(apiResult, expected);
            apiResult = ZapClient.Acsrf.RemoveOptionToken(Apikey, "test");
            ActionResultAsserts(apiResult, expected);
        }
    }
}
