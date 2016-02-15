using NUnit.Framework;
using NZap.Enums;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class AuthenticationTests : TestBase
    {
        [Test]
        public void TestGetAuthenticationMethodShouldSucced()
        {
            const string expected = "manualAuthentication";
            var apiResult = ZapClient.Authentication.GetAuthenticationMethod("1");
            var actual = apiResult.Value;
            StringAssert.IsMatch(expected, actual);
        }
    }
}
