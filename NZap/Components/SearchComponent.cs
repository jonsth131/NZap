using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;

namespace NZap.Components
{
    public interface ISearchComponent
    {
        /* VIEWS */
        IApiResult GetMessagesByHeaderRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetMessagesByRequestRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetMessagesByResponseRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetMessagesByUrlRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetUrlsByHeaderRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetUrlsByRequestRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetUrlsByResponseRegex(string regex, IDictionary<string, string> parameters = null);
        IApiResult GetUrlsByUrlRegex(string regex, IDictionary<string, string> parameters = null);
        /*
        TODO:
        Others

        harByHeaderRegex (regex* baseurl start count )	
        harByRequestRegex (regex* baseurl start count )	
        harByResponseRegex (regex* baseurl start count )	
        harByUrlRegex (regex* baseurl start count )	
        */
    }

    internal class SearchComponent : ISearchComponent
    {
        private const string Component = "search";

        private readonly IZapClient _zapClient;

        public SearchComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetMessagesByHeaderRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "messagesByHeaderRegex");
        }

        public IApiResult GetMessagesByRequestRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "messagesByRequestRegex");
        }

        public IApiResult GetMessagesByResponseRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "messagesByResponseRegex");
        }

        public IApiResult GetMessagesByUrlRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "messagesByUrlRegex");
        }

        public IApiResult GetUrlsByHeaderRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "urlsByHeaderRegex");
        }

        public IApiResult GetUrlsByRequestRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "urlsByRequestRegex");
        }

        public IApiResult GetUrlsByResponseRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "urlsByResponseRegex");
        }

        public IApiResult GetUrlsByUrlRegex(string regex, IDictionary<string, string> parameters = null)
        {
            return GetRegexAction(regex, parameters, "urlsByUrlRegex");
        }

        private IApiResult GetRegexAction(string regex, IDictionary<string, string> parameters, string action)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, ActionTypes.View, action, parameters);
        }

    }
}
