using System.Collections.Generic;

namespace NZap.Entities
{
    public interface IAlertResult
    {
        string Other { get; }
        string Evidence { get; }
        string Cweid { get; }
        string Confidence { get; }
        string Wascid { get; }
        string Description { get; }
        string MessageId { get; }
        string Url { get; }
        string Reference { get; }
        string Solution { get; }
        string Alert { get; }
        string Param { get; }
        string Attack { get; }
        string Risk { get; }
        string Id { get; }
        void AddKeyValue(string key, string value);
    }

    public class AlertResult : IAlertResult
    {
        private readonly Dictionary<string, string> _results;

        public string Other => GetValue("other");
        public string Evidence => GetValue("evidence");
        public string Cweid => GetValue("cweid");
        public string Confidence => GetValue("confidence");
        public string Wascid => GetValue("wascid");
        public string Description => GetValue("description");
        public string MessageId => GetValue("messageId");
        public string Url => GetValue("url");
        public string Reference => GetValue("reference");
        public string Solution => GetValue("solution");
        public string Alert => GetValue("alert");
        public string Param => GetValue("param");
        public string Attack => GetValue("attack");
        public string Risk => GetValue("risk");
        public string Id => GetValue("id");

        public AlertResult()
        {
            _results = new Dictionary<string, string>();
        }

        public void AddKeyValue(string key, string value)
        {
            _results.Add(key, value);
        }

        private string GetValue(string key)
        {
            return _results.ContainsKey(key) ? _results[key] : string.Empty;
        }
    }
}
