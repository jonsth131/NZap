using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NZap.Helpers
{
    internal class ParameterHelper
    {
        internal static string GetParameterStringFromDictionary(IDictionary<string, string> parameters)
        {
            if (parameters == null) return string.Empty;
            if (parameters.Count <= 0) return string.Empty;
            var stringBuilder = new StringBuilder();
            var last = parameters.Last();
            foreach (var parameter in parameters)
            {
                stringBuilder.Append(Uri.EscapeDataString(parameter.Key))
                    .Append("=")
                    .Append(Uri.EscapeDataString(parameter.Value));
                if (!last.Equals(parameter))
                    stringBuilder.Append("&");
            }
            return stringBuilder.ToString();
        }
    }
}
