using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class SearchTests : TestBase
    {
        private const string Regex = "^1$";

        #region Views
        [Test]
        public void TestGetMessagesByHeaderRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByHeaderRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetMessagesByRequestRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByRequestRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetMessagesByResponseRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByResponseRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetMessagesByUrlRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByUrlRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByHeaderRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByHeaderRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByRequestRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByRequestRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByResponseRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByResponseRegex(Regex);
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByUrlRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByUrlRegex(Regex);
            ResultAsserts(apiResult, expected);
        }
        #endregion
    }
}
