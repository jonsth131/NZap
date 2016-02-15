using System;
using System.Collections.Generic;
using System.Linq;
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
                    foreach (var resultList in from object element in value select CreateApiResultList(obj.Key, element))
                    {
                        apiResult.ResultList.Add(resultList);
                    }
                }
                if (apiResultList.ApiResultElements.Count != 0) apiResult.ResultList.Add(apiResultList);
            }
            return apiResult;
        }

        private static ApiResultList CreateApiResultList(string key, object element)
        {
            var list = new ApiResultList { Key = key };
            if (element.GetType() == typeof(Dictionary<string, object>))
            {
                var elementValue = (Dictionary<string, object>)element;
                foreach (var apiResultElement in elementValue.Select(CreateApiResultElement))
                {
                    list.ApiResultElements.Add(apiResultElement);
                }
            }
            else if (element is string)
            {
                var elementValue = (string)element;
                var apiResultElement = CreateApiResultElement(string.Empty, elementValue);
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
