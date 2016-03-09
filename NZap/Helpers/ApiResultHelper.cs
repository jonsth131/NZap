using System;
using System.Collections.Generic;
using System.Linq;
using NZap.Entities;

namespace NZap.Helpers
{
    internal class ApiResultHelper
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
                    if (dict.Count == 1)
                    {
                        apiResult.Key = obj.Key;
                        apiResult.Value = obj.Value as string;
                    }
                    else {
                        apiResultList.Key = obj.Key;
                        apiResultList.ApiResultElements.Add(CreateApiResultElement(obj));
                    }
                }
                else if (type.BaseType == typeof(Array))
                {
                    var value = (Array)obj.Value;
                    foreach (var element in value)
                    {
                        var elementType = element.GetType();
                        if (elementType == typeof(Dictionary<string, object>)) { 
                            var resultList = CreateApiResultList(obj.Key, element);
                            apiResult.ResultList.Add(resultList);
                        } else if (elementType == typeof (string))
                        {
                            apiResultList.Key = obj.Key;
                            apiResultList.ApiResultElements.Add(CreateApiResultElement(obj.Key, element as string));
                        }
                    }
                }
                if (apiResultList.ApiResultElements.Count != 0) apiResult.ResultList.Add(apiResultList);
            }
            return apiResult;
        }

        private static ApiResultList CreateApiResultList(string key, object element)
        {
            var list = new ApiResultList { Key = key };
            var elementValue = (Dictionary<string, object>)element;
            foreach (var apiResultElement in elementValue.Select(CreateApiResultElement))
            {
                list.ApiResultElements.Add(apiResultElement);
            }
            return list;
        }

        private static ApiResultElement CreateApiResultElement(KeyValuePair<string, object> obj)
        {
            var key = obj.Key;
            var value = obj.Value as string;
            return CreateApiResultElement(key, value);
        }

        private static ApiResultElement CreateApiResultElement(string key, string value)
        {
            return new ApiResultElement
            {
                Key = key,
                Value = value
            };
        }

    }
}
