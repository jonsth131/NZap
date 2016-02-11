﻿using System.Collections.Generic;
using NZap.Entities;

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

    public class SearchComponent : ISearchComponent
    {
        private const string Component = "search";

        private readonly IZapClient _zapClient;

        public SearchComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetMessagesByHeaderRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "messagesByHeaderRegex", parameters);
        }

        public IApiResult GetMessagesByRequestRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "messagesByRequestRegex", parameters);
        }

        public IApiResult GetMessagesByResponseRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "messagesByResponseRegex", parameters);
        }

        public IApiResult GetMessagesByUrlRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "messagesByUrlRegex", parameters);
        }

        public IApiResult GetUrlsByHeaderRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "urlsByHeaderRegex", parameters);
        }

        public IApiResult GetUrlsByRequestRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "urlsByRequestRegex", parameters);
        }

        public IApiResult GetUrlsByResponseRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "urlsByResponseRegex", parameters);
        }

        public IApiResult GetUrlsByUrlRegex(string regex, IDictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "view", "urlsByUrlRegex", parameters);
        }
    }
}
