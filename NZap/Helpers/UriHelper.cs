using System;
using System.Collections.Generic;
using System.Text;

namespace NZap.Helpers
{
    internal class UriHelper
    {
        internal static string CreateUriStringFromParameters(string component, string type, string action, string uri)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("JSON/")
                .Append(component)
                .Append("/")
                .Append(type)
                .Append("/")
                .Append(action)
                .Append("/");
            return stringBuilder.ToString();
        }

        internal static Uri BuildZapUri(string host, int port, string uri, IDictionary<string, string> parameters)
        {
            var uriBuilder = new UriBuilder
            {
                Host = host,
                Port = port,
                Scheme = "http",
                Path = uri,
                Query = ParameterHelper.GetParameterStringFromDictionary(parameters)
            };
            return uriBuilder.Uri;
        }
    }
}
