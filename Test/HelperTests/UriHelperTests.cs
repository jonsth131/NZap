using System;
using System.Collections.Generic;
using NUnit.Framework;
using NZap.Helpers;

namespace Tests.HelperTests
{
    [TestFixture]
    public class UriHelperTests
    {
        [Test]
        public void CreateUriStringFromParametersShouldSucceed()
        {
            const string expected = "JSON/component/type/action/";
            var actual = UriHelper.CreateUriStringFromParameters("component", "type", "action");
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void BuildZapUriWithNullParametersShouldSucceed()
        {
            var expected = new UriBuilder
            {
                Host = "host",
                Port = 42,
                Scheme = "http",
                Path = "uri",
                Query = string.Empty
            }.Uri;

            var actual = UriHelper.BuildZapUri("host", 42, "uri", null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BuildZapUriWithParametersShouldSucceed()
        {
            var expected = new UriBuilder
            {
                Host = "host",
                Port = 42,
                Scheme = "http",
                Path = "uri",
                Query = "entry1=value1"
            }.Uri;

            var dict = new Dictionary<string, string> {{"entry1", "value1"}};
            var actual = UriHelper.BuildZapUri("host", 42, "uri", dict);
            Assert.AreEqual(expected, actual);
        }
    }
}
