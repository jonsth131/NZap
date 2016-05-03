using System;
using System.Collections.Generic;
using System.Text;
using NZap.Enums;

namespace NZap.Helpers
{
    internal static class UriHelper
    {
        internal static string CreateUriStringFromParameters(string component, string type, string action, ResponseType responseType = ResponseType.JSON)
        {
            return new StringBuilder()
                .Append(responseType)
                .Append("/")
                .Append(component)
                .Append("/")
                .Append(type)
                .Append("/")
                .Append(action)
                .Append("/")
                .ToString();
        }

        internal static Uri BuildZapUri(string host, int port, string uri, Protocols scheme, IDictionary<string, string> parameters)
        {
            return new UriBuilder
            {
                Host = host,
                Port = port,
                Scheme = scheme.ToString(),
                Path = uri,
                Query = ParameterHelper.GetParameterStringFromDictionary(parameters)
            }.Uri;
        }
    }
}
