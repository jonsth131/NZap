using System;
using System.Collections.Generic;
using System.Text;

namespace NZap.Helpers
{
    internal class ParameterHelper
    {
        internal static string GetParameterStringFromDictionary(IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count <= 0) return string.Empty;
            var stringBuilder = new StringBuilder();
            foreach (var parameter in parameters)
            {
                if (stringBuilder.Length != 0)
                    stringBuilder.Append("&");

                stringBuilder.Append(Uri.EscapeDataString(parameter.Key))
                    .Append("=")
                    .Append(Uri.EscapeDataString(parameter.Value));
            }
            return stringBuilder.ToString();
        }
    }
}
