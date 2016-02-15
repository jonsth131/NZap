using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NZap.Helpers;

namespace Tests.HelperTests
{
    [TestFixture]
    public class ApiResultHelperTests
    {
        [Test]
        public void CreateApiResultWithArrayShouldSucceed()
        {
            const int expected = 10;
            var dict = CreateTestDictionary();
            var apiResult = ApiResultHelper.CreateApiResult(dict);
            var actual = apiResult.ResultList.Count;
            Assert.AreEqual(expected, actual);
            var i = 1;
            foreach (var apiResultElement in apiResult.ResultList.SelectMany(apiResultList => apiResultList.ApiResultElements))
            {
                StringAssert.IsMatch("key" + i, apiResultElement.Key);
                StringAssert.IsMatch("value" + i, apiResultElement.Value);
                i++;
            }
        }

        private static Dictionary<string, object> CreateTestDictionary()
        {
            var list = new object[10];
            list[0] = new Dictionary<string, object> { { "key1", "value1" } };
            list[1] = new Dictionary<string, object> { { "key2", "value2" } };
            list[2] = new Dictionary<string, object> { { "key3", "value3" } };
            list[3] = new Dictionary<string, object> { { "key4", "value4" } };
            list[4] = new Dictionary<string, object> { { "key5", "value5" } };
            list[5] = new Dictionary<string, object> { { "key6", "value6" } };
            list[6] = new Dictionary<string, object> { { "key7", "value7" } };
            list[7] = new Dictionary<string, object> { { "key8", "value8" } };
            list[8] = new Dictionary<string, object> { { "key9", "value9" } };
            list[9] = new Dictionary<string, object> { { "key10", "value10" } };
            return new Dictionary<string, object> { { "test", list } }; ;
        }
    }
}
