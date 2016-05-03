using System.Collections.Generic;
using System.Linq;
using NZap.Entities;

namespace NZap.Helpers
{
    internal static class AlertResultHelper
    {
        internal static IAlertResult CreateAlertResult(IDictionary<string, object> dict)
        {
            const string key = "alert";
            if (!dict.ContainsKey(key)) return new AlertResult();
            var alert = (Dictionary <string, object>) dict[key];
            return SetKeyValuePairsInAlertResult(alert);
        }

        internal static List<IAlertResult> CreateAlertResultList(IDictionary<string, object> dict)
        {
            const string key = "alerts";
            var results = new List<IAlertResult>();
            if (!dict.ContainsKey(key)) return results;
            var alerts = (object[]) dict[key];
            results.AddRange(from Dictionary<string, object> alert in alerts select SetKeyValuePairsInAlertResult(alert));
            return results;
        }

        private static IAlertResult SetKeyValuePairsInAlertResult(Dictionary<string, object> alert)
        {
            var result = new AlertResult();
            foreach (var valuePair in alert)
            {
                result.AddResult(valuePair.Key, valuePair.Value as string);
            }
            return result;
        }
    }
}
