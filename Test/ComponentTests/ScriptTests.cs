using NUnit.Framework;
using NZap.Exceptions;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class ScriptTests : TestBase
    {
        [Test]
        public void TestListEngines()
        {
            const int expected = 1;
            var apiResult = ZapClient.Script.ListEngines();
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestListScripts()
        {
            const int expected = 0;
            var apiResult = ZapClient.Script.ListScripts();
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestDisable()
        {
            const string expectedExceptionMessage = "No script with name: 1";
            var webException = Assert.Throws<ZapApiException>(() => ZapClient.Script.Disable(Apikey, "1"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void TestEnable()
        {
            const string expectedExceptionMessage = "No script with name: 1";
            var webException = Assert.Throws<ZapApiException>(() => ZapClient.Script.Enable(Apikey, "1"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }
    }
}
