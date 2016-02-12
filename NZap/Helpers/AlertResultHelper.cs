using System.Collections.Generic;
using NZap.Entities;

namespace NZap.Helpers
{
    public class AlertResultHelper
    {
        public static IAlertResult CreateAlertResult(IDictionary<string, object> dict)
        {
            const string key = "alert";
            var result = new AlertResult();
            if (!dict.ContainsKey(key)) return result;
            var alert = (Dictionary <string, object>) dict[key];
            foreach (var valuePair in alert)
            {
                result.AddKeyValue(valuePair.Key, valuePair.Value as string);
            }
            return result;
        }

        public static List<IAlertResult> CreateAlertResultList(IDictionary<string, object> dict)
        {
            const string key = "alerts";
            var results = new List<IAlertResult>();
            if (!dict.ContainsKey(key)) return results;
            var alerts = (object[]) dict[key];
            foreach (Dictionary<string, object> alert in alerts)
            {
                var alertResult = new AlertResult();
                foreach (var valuePair in alert)
                {
                    alertResult.AddKeyValue(valuePair.Key, valuePair.Value as string);
                }
                results.Add(alertResult);
            }
            return results;
        }
    }
}
