using System.Collections.Generic;
using NZap.Entities;

namespace NZap.Components
{
    public interface IParamsComponent
    {
        /* VIEWS */
        IApiResult GetParams(string site = null);
    }

    internal class ParamsComponent : IParamsComponent
    {
        private const string Component = "params";

        private readonly IZapClient _zapClient;

        public ParamsComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetParams(string site = null)
        {
            var parameters = new Dictionary<string, string>();
            if (site != null) parameters.Add("site", site);
            return _zapClient.CallApi(Component, "view", "params", parameters);
        }
    }
}
