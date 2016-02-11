using System.Linq;
using NZap;
using NZap.Entities;
using NUnit.Framework;

namespace Tests
{
    public class TestBase
    {
        internal const string Apikey = "b56i96opec68mts9ob05pdpigg";

        internal IZapClient ZapClient;

        public TestBase()
        {
            ZapClient = new ZapClient("localhost", 8080);
        }

        #region Helper methods

        internal static void ResultAsserts(IApiResult apiResult, int expected)
        {
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
        }

        internal static void SingleResultAsserts(IApiResult apiResult, int expected, string expectedKey)
        {
            ResultAsserts(apiResult, expected);
            StringAssert.Contains(expectedKey, apiResult.Key);
        }

        internal static void ResultAsserts(IApiResult apiResult, int expected, string expectedKey)
        {
            ResultAsserts(apiResult, expected);
            var actual = apiResult.ResultList.Count;
            var apiResultElement = apiResult.ResultList.ElementAt(actual - 1);
            StringAssert.Contains(expectedKey, apiResultElement.Key);
        }

        internal static void ResultAssertsWithValue(IApiResult apiResult, int expected, string expectedKey, string expectedValue)
        {
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
            StringAssert.Contains(expectedKey, apiResult.Key);
            StringAssert.Contains(expectedValue, apiResult.Value);
        }

        internal static void ActionResultAsserts(IApiResult apiResult, int expected)
        {
            const string expectedKey = "Result";
            const string expectedValue = "OK";
            ResultAssertsWithValue(apiResult, expected, expectedKey, expectedValue);
        }
        #endregion
    }
}
