using System;
using System.Collections;
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
                    apiResultList = CreateApiResultList(obj, value);
                }
                if (apiResultList.ApiResultElements.Count != 0) apiResult.ResultList.Add(apiResultList);
            }
            return apiResult;
        }

        private static ApiResultList CreateApiResultList(KeyValuePair<string, object> obj, IEnumerable value)
        {
            var list = new ApiResultList {Key = obj.Key};
            foreach (var element in value)
            {
                var apiResultElement = new ApiResultElement();
                if (element.GetType() == typeof (Dictionary<string, object>))
                {
                    apiResultElement = CreateApiResultElement(obj);
                }
                else if (element is string)
                {
                    var elementValue = (string) element;
                    apiResultElement = CreateApiResultElement(string.Empty, elementValue);
                }
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
