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
            foreach (var obj in dict)
            {
                var type = obj.Value.GetType();
                if (type == typeof(string))
                {
                    apiResultList.Key = obj.Key;
                    apiResultList.ApiResultElements.Add(CreateApiResultElement(obj));
                }
                else if (type.BaseType == typeof(Array))
                {
                    var value = (Array)obj.Value;
                    foreach (var element in value)
                    {
                        var list = CreateApiResultList(element);
                        list.Key = obj.Key;
                        apiResult.ResultList.Add(list);
                    }
                }
            }
            if (apiResultList.ApiResultElements.Count != 0) apiResult.ResultList.Add(apiResultList);
            return apiResult;
        }

        private static ApiResultList CreateApiResultList(object obj)
        {
            var apiResultList = new ApiResultList();
            if (obj.GetType() != typeof(Dictionary<string, object>)) return apiResultList;
            var dict = (Dictionary<string, object>)obj;
            foreach (var pair in dict)
            {
                apiResultList.ApiResultElements.Add(CreateApiResultElement(pair));
            }
            return apiResultList;
        }

        private static ApiResultElement CreateApiResultElement(KeyValuePair<string, object> obj)
        {
            var value = obj.Value as string;
            return new ApiResultElement
            {
                Key = obj.Key,
                Value = value
            };
        }

    }
}
