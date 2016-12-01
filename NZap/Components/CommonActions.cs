using System;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    internal class CommonActions
    {
        private readonly IZapClient _zapClient;
        private readonly string _component;

        internal CommonActions(IZapClient zapClient, string component)
        {
            _zapClient = zapClient;
            _component = component;
        }

        internal IApiResult ActionWithParameter<T>(string apikey, T option, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            var parameter = GetParameterName(typeof(T));
            parameters.Add(parameter, option.ToString());
            return _zapClient.CallApi(_component, ActionTypes.Action, action, parameters);
        }

        private static string GetParameterName(Type type)
        {
            var parameter = string.Empty;
            if (type == typeof(int))
            {
                parameter = "Integer";
            }
            else if (type == typeof(bool))
            {
                parameter = "Boolean";
            }
            else if (type == typeof(string))
            {
                parameter = "String";
            }
            return parameter;
        }
    }
}