using System.Collections.Generic;
using NZap.Entities;
using NZap.Enums;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IForcedUserComponent
    {
        /* VIEWS */
        IApiResult GetForcesUser(string contextId);
        IApiResult GetIsForcedUserModeEnabled();

        /* ACTIONS */
        IApiResult SetForcedUser(string apikey, string contextId, string userId);
        IApiResult SetForcedUserModeEnabled(string apikey, bool option);
    }

    internal class ForcedUserComponent : IForcedUserComponent
    {
        private const string Component = "forcedUser";

        private readonly IZapClient _zapClient;

        public ForcedUserComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetForcesUser(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, ActionTypes.View, "getForcesUser", parameters);
        }

        public IApiResult GetIsForcedUserModeEnabled()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "isForcedUserModeEnabled");
        }

        public IApiResult SetForcedUser(string apikey, string contextId, string userId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            return _zapClient.CallApi(Component, ActionTypes.Action, "setForcedUser", parameters);
        }

        public IApiResult SetForcedUserModeEnabled(string apikey, bool option)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("boolean", option.ToString());
            return _zapClient.CallApi(Component, ActionTypes.Action, "setForcedUserModeEnabled", parameters);
        }
    }
}
