using System;
using System.Collections.Generic;
using System.Text;

namespace NZap.Helpers
{
    internal class UriHelper
    {
        private static string _scheme = "http";
        private static string _responseType = "JSON";

        internal static string CreateUriStringFromParameters(string component, string type, string action, string uri)
        {
            return new StringBuilder()
                .Append(_responseType)
                .Append("/")
                .Append(component)
                .Append("/")
                .Append(type)
                .Append("/")
                .Append(action)
                .Append("/")
                .ToString();
        }

        internal static Uri BuildZapUri(string host, int port, string uri, IDictionary<string, string> parameters)
        {
            return new UriBuilder
            {
                Host = host,
                Port = port,
                Scheme = _scheme,
                Path = uri,
                Query = ParameterHelper.GetParameterStringFromDictionary(parameters)
            }.Uri;
        }
    }
}
