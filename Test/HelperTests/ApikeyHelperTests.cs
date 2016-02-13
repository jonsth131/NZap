using NUnit.Framework;
using NZap.Exceptions;
using NZap.Helpers;

namespace Tests.HelperTests
{
    [TestFixture]
    public class ApikeyHelperTests
    {
        [Test]
        public void ReturnParameterDictFromApikeyWithNullApikeyShouldThrowException()
        {
            const string expectedExceptionMessage = "No apikey supplied!";
            var zapApiException = Assert.Throws<ZapApiException>(() => ApikeyHelper.ReturnParameterDictFromApikey(null));
            StringAssert.Contains(expectedExceptionMessage, zapApiException.Message);
        }

        [Test]
        public void ReturnParameterDictFromApikeyWithApikeyShouldSucceed()
        {
            const string apikey = "apikey";
            const string expectedValue = "key";
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(expectedValue);
            Assert.IsTrue(parameters.ContainsKey(apikey));
            var value = parameters[apikey];
            StringAssert.IsMatch(expectedValue, value);
        }
    }
}
