using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using NZap.Enums;

namespace Tests
{
    [TestFixture]
    public class ZapClientTests : TestBase
    {
        [Test]
        public void InvalidPathShouldThrowException()
        {
            const string expectedExceptionMessage = " (400) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.CallApi("test", "test", "test"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void InvalidTypeAndActionShouldThrowException()
        {
            const string expectedExceptionMessage = " (400) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.CallApi("core", "test", "test"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void InvalidComponendAndActionShouldThrowException()
        {
            const string expectedExceptionMessage = " (400) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.CallApi("test", ActionTypes.View, "test"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void InvalidComponendAndTypeShouldThrowException()
        {
            const string expectedExceptionMessage = " (400) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.CallApi("test", "test", "version"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void InvalidTypeShouldThrowException()
        {
            const string expectedExceptionMessage = " (400) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.CallApi("core", "test", "version"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void InvalidActionShouldThrowException()
        {
            const string expectedExceptionMessage = " (400) ";
            var webException = Assert.Throws<WebException>(() => ZapClient.CallApi("core", ActionTypes.View, "test"));
            StringAssert.Contains(expectedExceptionMessage, webException.Message);
        }

        [Test]
        public void CorrectPathShouldSucceed()
        {
            const int expectedCount = 0;
            const string expectedKey = "version";
            var result = ZapClient.CallApi("core", ActionTypes.View, "version");
            SingleResultAsserts(result, expectedCount, expectedKey);
        }

        [Test]
        public void NullParameterDictShouldSucceed()
        {
            const int expectedCount = 0;
            const string expectedKey = "version";
            var result = ZapClient.CallApi("core", ActionTypes.View, "version", null);
            SingleResultAsserts(result, expectedCount, expectedKey);
        }

        [Test]
        public void EmptyParameterDictShouldSucceed()
        {
            const int expectedCount = 0;
            const string expectedKey = "version";
            var result = ZapClient.CallApi("core", ActionTypes.View, "version", new Dictionary<string, string>());
            SingleResultAsserts(result, expectedCount, expectedKey);
        }
    }
}
