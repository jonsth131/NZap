﻿using System.Linq;
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
        internal static void ResultAsserts(IApiResult apiResult, int expected, string expectedKey)
        {
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
            var apiResultElement = apiResult.ResultList.ElementAt(actual - 1);
            StringAssert.Contains(expectedKey, apiResultElement.Key);
        }

        internal static void ResultAssertsWithValue(IApiResult apiResult, int expected, string expectedKey, string expectedValue)
        {
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
            var apiResultList = apiResult.ResultList.ElementAt(actual - 1);
            var apiResultElement = apiResultList.ApiResultElements.ElementAt(actual - 1);
            StringAssert.Contains(expectedKey, apiResultElement.Key);
            StringAssert.Contains(expectedValue, apiResultElement.Value);
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