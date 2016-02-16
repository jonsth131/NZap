using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using NZap.Entities;

namespace NZap.Helpers
{
    internal class SerializationHelper
    {
        internal static IApiResult DeserializeJsonToApiResult(string json)
        {
            var dict = GetDictionaryFromJson(json);
            return ApiResultHelper.CreateApiResult(dict);
        }

        internal static IAlertResult DeserializeJsonToAlertResult(string json)
        {
            var dict = GetDictionaryFromJson(json);
            return AlertResultHelper.CreateAlertResult(dict);
        }

        internal static List<IAlertResult> DeserializeJsonToAlertResultList(string json)
        {
            var dict = GetDictionaryFromJson(json);
            return AlertResultHelper.CreateAlertResultList(dict);
        }

        private static Dictionary<string, object> GetDictionaryFromJson(string json)
        {
            var deserializeObject = DeserializeObject(json);
            if (deserializeObject?.GetType() != typeof(Dictionary<string, object>)) return new Dictionary<string, object>();
            return (Dictionary<string, object>)deserializeObject;
        }

        private static object DeserializeObject(string json)
        {
            var javaScriptSerializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            var deserializeObject = javaScriptSerializer.DeserializeObject(json);
            return deserializeObject;
        }
    }
}
