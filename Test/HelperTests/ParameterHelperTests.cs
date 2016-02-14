using System.Collections.Generic;
using NUnit.Framework;
using NZap.Helpers;

namespace Tests.HelperTests
{
    [TestFixture]
    public class ParameterHelperTests
    {
        [Test]
        public void GetParameterStringFromDictionaryWithNullDictShouldSucceed()
        {
            var expected = string.Empty;
            var actual = ParameterHelper.GetParameterStringFromDictionary(null);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void GetParameterStringFromDictionaryWithEmptyDictShouldSucceed()
        {
            var expected = string.Empty;
            var dict = new Dictionary<string, string>();
            var actual = ParameterHelper.GetParameterStringFromDictionary(dict);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void GetParameterStringFromDictionaryWithEntryShouldSucceed()
        {
            const string expected = "entry1=value1";
            var dict = new Dictionary<string, string> {{"entry1", "value1"}};
            var actual = ParameterHelper.GetParameterStringFromDictionary(dict);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void GetParameterStringFromDictionaryWithTwoEntriesShouldSucceed()
        {
            const string expected = "entry1=value1&entry2=value2";
            var dict = new Dictionary<string, string> { { "entry1", "value1" }, { "entry2", "value2"} };
            var actual = ParameterHelper.GetParameterStringFromDictionary(dict);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void GetParameterStringFromDictionaryWithTwoEntriesAndSpecialCharactersShouldSucceed()
        {
            const string expected = "entry1%20%2B=value1%26&entry2%25=value2%C3%A4";
            var dict = new Dictionary<string, string> { { "entry1 +", "value1&" }, { "entry2%", "value2ä" } };
            var actual = ParameterHelper.GetParameterStringFromDictionary(dict);
            StringAssert.IsMatch(expected, actual);
        }
    }
}
