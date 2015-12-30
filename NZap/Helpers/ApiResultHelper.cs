using System;
using System.Collections.Generic;
using NZap.Entities;

namespace NZap.Helpers
{
    public class ApiResultHelper
    {
        internal static IApiResult CreateApiResult(IDictionary<string, object> dict)
        {
            var apiResult = new ApiResult();
            var apiResultList = new ApiResultList();
            foreach (var o in dict)
            {
                var type = o.Value.GetType();
                if (type == typeof(string))
                {
                    apiResultList.Key = o.Key;
                    apiResultList.ApiResultElements.Add(CreateApiResultElement(o));
                }
                else if (type.BaseType == typeof(Array))
                {
                    var value = (Array)o.Value;
                    foreach (var element in value)
                    {
                        var list = CreateApiResultList(element);
                        list.Key = o.Key;
                        apiResult.ResultList.Add(list);
                    }
                }
            }
            if (apiResultList.ApiResultElements.Count != 0) apiResult.ResultList.Add(apiResultList);
            return apiResult;
        }

        private static ApiResultList CreateApiResultList(object o)
        {
            var apiResultList = new ApiResultList();
            if (o.GetType() != typeof(Dictionary<string, object>)) return apiResultList;
            var dict = (Dictionary<string, object>)o;
            foreach (var pair in dict)
            {
                apiResultList.ApiResultElements.Add(CreateApiResultElement(pair));
            }
            return apiResultList;
        }

        private static ApiResultElement CreateApiResultElement(KeyValuePair<string, object> o)
        {
            var s = o.Value as string;
            return new ApiResultElement
            {
                Key = o.Key,
                Value = s
            };
        }

    }
}
