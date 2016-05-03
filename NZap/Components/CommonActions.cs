using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    internal class CommonActions
    {
        private readonly IZapClient _zapClient;
        private readonly string _componennt;

        internal CommonActions(IZapClient zapClient, string component)
        {
            _zapClient = zapClient;
            _componennt = component;
        }

        internal IApiResult ActionWithParameterBoolean(string apikey, bool option, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Boolean", option.ToString());
            return _zapClient.CallApi(_componennt, "action", action, parameters);
        }

        internal IApiResult ActionWithParameterString(string apikey, string s, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("String", s);
            return _zapClient.CallApi(_componennt, "action", action, parameters);
        }

        internal IApiResult ActionWithParameterInteger(string apikey, int n, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("Integer", n.ToString());
            return _zapClient.CallApi(_componennt, "action", action, parameters);
        }
    }
}