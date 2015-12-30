﻿using System.Collections.Generic;
using System.Web.Script.Serialization;
using NZap.Entities;

namespace NZap.Helpers
{
    internal class SerializationHelper
    {
        internal static IApiResult DeserializeJsonToApiResult(string json)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            var deserializeObject = javaScriptSerializer.DeserializeObject(json);
            if (deserializeObject.GetType() != typeof(Dictionary<string, object>)) return new ApiResult();
            var dict = (Dictionary<string, object>)deserializeObject;
            return ApiResultHelper.CreateApiResult(dict);
        }

    }
}