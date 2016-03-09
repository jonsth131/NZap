using System;
using System.Collections.Generic;
using NUnit.Framework;
using NZap.Enums;
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
        public void CreateUriStringFromParametersWithJsonpTypeShouldSucceed()
        {
            const string expected = "JSONP/component/type/action/";
            var actual = UriHelper.CreateUriStringFromParameters("component", "type", "action", ResponseType.JSONP);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void CreateUriStringFromParametersWithHtmlTypeShouldSucceed()
        {
            const string expected = "HTML/component/type/action/";
            var actual = UriHelper.CreateUriStringFromParameters("component", "type", "action", ResponseType.HTML);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void CreateUriStringFromParametersWithXmlTypeShouldSucceed()
        {
            const string expected = "XML/component/type/action/";
            var actual = UriHelper.CreateUriStringFromParameters("component", "type", "action", ResponseType.XML);
            StringAssert.IsMatch(expected, actual);
        }

        [Test]
        public void CreateUriStringFromParametersWithOtherTypeShouldSucceed()
        {
            const string expected = "OTHER/component/type/action/";
            var actual = UriHelper.CreateUriStringFromParameters("component", "type", "action", ResponseType.OTHER);
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

            var actual = UriHelper.BuildZapUri("host", 42, "uri", Protocols.http, null);
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
            var actual = UriHelper.BuildZapUri("host", 42, "uri", Protocols.http, dict);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BuildZapUriWithSpecialCharParametersShouldSucceed()
        {
            var expected = new UriBuilder
            {
                Host = "host",
                Port = 42,
                Scheme = "http",
                Path = "uri",
                Query = "entry1%2B%2B=value1%2B%2B"
            }.Uri;

            var dict = new Dictionary<string, string> { { "entry1++", "value1++" } };
            var actual = UriHelper.BuildZapUri("host", 42, "uri", Protocols.http, dict);
            Assert.AreEqual(expected, actual);
        }
    }
}
