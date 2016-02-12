using System.Collections.Generic;
using System.Web.Script.Serialization;
using NZap.Entities;

namespace NZap.Helpers
{
    internal class SerializationHelper
    {
        internal static IApiResult DeserializeJsonToApiResult(string json)
        {
            var deserializeObject = DeserializeObject(json);
            if (deserializeObject.GetType() != typeof(Dictionary<string, object>)) return new ApiResult();
            var dict = (Dictionary<string, object>)deserializeObject;
            return ApiResultHelper.CreateApiResult(dict);
        }

        internal static IAlertResult DeserializeJsonToAlertResult(string json)
        {
            var deserializeObject = DeserializeObject(json);
            if (deserializeObject.GetType() != typeof(Dictionary<string, object>)) return new AlertResult();
            var dict = (Dictionary<string, object>)deserializeObject;
            return AlertResultHelper.CreateAlertResult(dict);
        }

        internal static List<IAlertResult> DeserializeJsonToAlertResultList(string json)
        {
            var deserializeObject = DeserializeObject(json);
            if (deserializeObject.GetType() != typeof(Dictionary<string, object>)) return new List<IAlertResult>();
            var dict = (Dictionary<string, object>)deserializeObject;
            return AlertResultHelper.CreateAlertResultList(dict);
        }

        private static object DeserializeObject(string json)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            var deserializeObject = javaScriptSerializer.DeserializeObject(json);
            return deserializeObject;
        }
    }
}
