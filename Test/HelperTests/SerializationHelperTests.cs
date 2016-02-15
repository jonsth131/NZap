using System.Linq;
using NUnit.Framework;
using NZap.Entities;
using NZap.Helpers;

namespace Tests.HelperTests
{
    [TestFixture]
    public class SerializationHelperTests
    {
        [Test]
        public void DeserializeJsonToAlertResultWithEmptyJsonShouldSucceed()
        {
            var json = string.Empty;
            var result = SerializationHelper.DeserializeJsonToAlertResult(json);
            StringAssert.IsMatch("", result.Alert);
            StringAssert.IsMatch("", result.Attack);
            StringAssert.IsMatch("", result.Confidence);
            StringAssert.IsMatch("", result.Cweid);
            StringAssert.IsMatch("", result.Description);
            StringAssert.IsMatch("", result.Evidence);
            StringAssert.IsMatch("", result.Id);
            StringAssert.IsMatch("", result.MessageId);
            StringAssert.IsMatch("", result.Other);
            StringAssert.IsMatch("", result.Param);
            StringAssert.IsMatch("", result.Reference);
            StringAssert.IsMatch("", result.Risk);
            StringAssert.IsMatch("", result.Solution);
            StringAssert.IsMatch("", result.Url);
            StringAssert.IsMatch("", result.Wascid);
        }

        [Test]
        public void DeserializeJsonToAlertResultWithJsonShouldSucceed()
        {
            const string json = "{\"alert\":{\"other\":\"other\",\"evidence\":\"evidence\",\"cweid\":\"cweid\",\"confidence\":\"confidence\",\"wascid\":\"wascid\",\"description\":\"description\",\"messageId\":\"messageId\",\"url\":\"url\",\"reference\":\"reference\",\"solution\":\"solution\",\"alert\":\"alert\",\"param\":\"param\",\"attack\":\"attack\",\"risk\":\"risk\",\"id\":\"id\"}}";
            var result = SerializationHelper.DeserializeJsonToAlertResult(json);
            AlertResultAsserts(result);
        }

        [Test]
        public void DeserializeJsonToAlertResultListWithEmptyJsonShouldSucceed()
        {
            const int expected = 0;
            var json = string.Empty;
            var result = SerializationHelper.DeserializeJsonToAlertResultList(json);
            var actual = result.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeserializeJsonToAlertResultListWithJsonShouldSucceed()
        {
            const int expected = 1;
            const string json = "{\"alerts\":[{\"other\":\"other\",\"evidence\":\"evidence\",\"cweid\":\"cweid\",\"confidence\":\"confidence\",\"wascid\":\"wascid\",\"description\":\"description\",\"messageId\":\"messageId\",\"url\":\"url\",\"reference\":\"reference\",\"solution\":\"solution\",\"alert\":\"alert\",\"param\":\"param\",\"attack\":\"attack\",\"risk\":\"risk\",\"id\":\"id\"}]}";
            var result = SerializationHelper.DeserializeJsonToAlertResultList(json);
            var actual = result.Count;
            Assert.AreEqual(expected, actual);
            var alertResult = result[0];
            AlertResultAsserts(alertResult);
        }

        [Test]
        public void DeserializeJsonToApiResulttWithEmptyJsonShouldSucceed()
        {
            const int expected = 0;
            var json = string.Empty;
            var result = SerializationHelper.DeserializeJsonToApiResult(json);
            var actual = result.ResultList.Count;
            Assert.IsNull(result.Key);
            Assert.IsNull(result.Value);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeserializeJsonToApiResulttWithActionJsonShouldSucceed()
        {
            const int expected = 0;
            const string json = "{\"Result\":\"OK\"}";
            var result = SerializationHelper.DeserializeJsonToApiResult(json);
            var actual = result.ResultList.Count;
            StringAssert.IsMatch("Result", result.Key);
            StringAssert.IsMatch("OK", result.Value);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeserializeJsonToApiResulttWithViewJsonShouldSucceed()
        {
            const int expectedResultLists = 14;
            const int expectedElements = 4;
            const string json = "{\"scanners\":[{\"alertThreshold\":\"OFF\",\"name\":\"Script passive scan rules\",\"id\":\"50001\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Application Error Disclosure\",\"id\":\"90022\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Incomplete or No Cache-control and Pragma HTTP Header Set\",\"id\":\"10015\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Content-Type Header Missing\",\"id\":\"10019\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Cookie No HttpOnly Flag\",\"id\":\"10010\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Cookie Without Secure Flag\",\"id\":\"10011\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Cross-Domain JavaScript Source File Inclusion\",\"id\":\"10017\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Web Browser XSS Protection Not Enabled\",\"id\":\"10016\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Secure Pages Include Mixed Content\",\"id\":\"10040\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Password Autocomplete in Browser\",\"id\":\"10012\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Private IP Disclosure\",\"id\":\"2\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"Session ID in URL Rewrite\",\"id\":\"3\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"X-Content-Type-Options Header Missing\",\"id\":\"10021\",\"enabled\":\"true\"},{\"alertThreshold\":\"MEDIUM\",\"name\":\"X-Frame-Options Header Not Set\",\"id\":\"10020\",\"enabled\":\"true\"}]}";
            var result = SerializationHelper.DeserializeJsonToApiResult(json);
            var actualResultLists = result.ResultList.Count;
            Assert.AreEqual(expectedResultLists, actualResultLists);
            var actualElements = result.ResultList.First().ApiResultElements.Count;
            Assert.AreEqual(expectedElements, actualElements);
            Assert.IsNull(result.Key);
            Assert.IsNull(result.Value);
            StringAssert.IsMatch("scanners", result.ResultList.First().Key);            
        }

        private static void AlertResultAsserts(IAlertResult result)
        {
            StringAssert.IsMatch("alert", result.Alert);
            StringAssert.IsMatch("attack", result.Attack);
            StringAssert.IsMatch("confidence", result.Confidence);
            StringAssert.IsMatch("cweid", result.Cweid);
            StringAssert.IsMatch("description", result.Description);
            StringAssert.IsMatch("evidence", result.Evidence);
            StringAssert.IsMatch("id", result.Id);
            StringAssert.IsMatch("messageId", result.MessageId);
            StringAssert.IsMatch("other", result.Other);
            StringAssert.IsMatch("param", result.Param);
            StringAssert.IsMatch("reference", result.Reference);
            StringAssert.IsMatch("risk", result.Risk);
            StringAssert.IsMatch("solution", result.Solution);
            StringAssert.IsMatch("url", result.Url);
            StringAssert.IsMatch("wascid", result.Wascid);
        }
    }
}
