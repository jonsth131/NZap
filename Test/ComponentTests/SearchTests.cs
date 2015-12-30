using NUnit.Framework;

namespace Tests.ComponentTests
{
    [TestFixture]
    public class SearchTests : TestBase
    {
        #region Views
        [Test]
        public void TestGetMessagesByHeaderRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByHeaderRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetMessagesByRequestRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByRequestRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetMessagesByResponseRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByResponseRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetMessagesByUrlRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetMessagesByUrlRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByHeaderRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByHeaderRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByRequestRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByRequestRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByResponseRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByResponseRegex("^1$");
            ResultAsserts(apiResult, expected);
        }

        [Test]
        public void TestGetUrlsByUrlRegex()
        {
            const int expected = 0;
            var apiResult = ZapClient.Search.GetUrlsByUrlRegex("^1$");
            ResultAsserts(apiResult, expected);
        }
        #endregion
    }
}
