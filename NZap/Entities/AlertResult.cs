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
        void AddResult(string key, string value);
    }

    public class AlertResult : IAlertResult
    {
        private readonly Dictionary<string, string> _results;

        public string Other => GetResultValue("other");
        public string Evidence => GetResultValue("evidence");
        public string Cweid => GetResultValue("cweid");
        public string Confidence => GetResultValue("confidence");
        public string Wascid => GetResultValue("wascid");
        public string Description => GetResultValue("description");
        public string MessageId => GetResultValue("messageId");
        public string Url => GetResultValue("url");
        public string Reference => GetResultValue("reference");
        public string Solution => GetResultValue("solution");
        public string Alert => GetResultValue("alert");
        public string Param => GetResultValue("param");
        public string Attack => GetResultValue("attack");
        public string Risk => GetResultValue("risk");
        public string Id => GetResultValue("id");

        public AlertResult()
        {
            _results = new Dictionary<string, string>();
        }

        public void AddResult(string key, string value)
        {
            _results.Add(key, value);
        }

        private string GetResultValue(string key)
        {
            return _results.ContainsKey(key) ? _results[key] : string.Empty;
        }
    }
}
