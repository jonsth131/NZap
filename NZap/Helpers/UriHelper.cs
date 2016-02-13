using System;
using System.Collections.Generic;
using System.Text;

namespace NZap.Helpers
{
    internal class UriHelper
    {
        private const string Scheme = "http";
        private const string ResponseType = "JSON";

        internal static string CreateUriStringFromParameters(string component, string type, string action)
        {
            return new StringBuilder()
                .Append(ResponseType)
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
                Scheme = Scheme,
                Path = uri,
                Query = ParameterHelper.GetParameterStringFromDictionary(parameters)
            }.Uri;
        }
    }
}
