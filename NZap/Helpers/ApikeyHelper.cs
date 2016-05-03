using System.Collections.Generic;
using NZap.Exceptions;

namespace NZap.Helpers
{
    internal static class ApikeyHelper
    {
        internal static IDictionary<string, string> ReturnParameterDictFromApikey(string apikey, IDictionary<string, string> parameters = null)
        {
            if (apikey == null) throw new ZapApiException("No apikey supplied!");
            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("apikey", apikey);
            return parameters;
        }
    }
}
