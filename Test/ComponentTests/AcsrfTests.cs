using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class AcsrfTests : TestBase
    {
        [Test]
        public void TestGetOptionTokenNamesShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "TokensNames";
            var apiResult = ZapClient.Acsrf.GetOptionTokenNames();
            SingleResultAsserts(apiResult, expected, expectedKey);
        }

        [Test]
        public void TestAddAndRemoveOptionTokenShouldSucceed()
        {
            const int expected = 0;
            const string expectedKey = "Result";
            const string expectecValue = "OK";
            var apiResult = ZapClient.Acsrf.AddOptionToken(Apikey, "test");
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
            apiResult = ZapClient.Acsrf.RemoveOptionToken(Apikey, "test");
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectecValue);
        }
    }
}
