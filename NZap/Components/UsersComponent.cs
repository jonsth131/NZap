using System.Collections.Generic;
using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IUsersComponent
    {
        /* VIEWS */
        IApiResult GetAuthenticationCredentials(string contextId, string userId);
        IApiResult GetAuthenticationCredentialsConfigParams(string contextId);
        IApiResult GetUserById(IDictionary<string, string> parameters = null);
        IApiResult GetUserLists(string contextId = null);

        /* ACTIONS */
        IApiResult NewUser(string apikey, string contextId, string name);
        IApiResult RemoveUser(string apikey, string contextId, string userId);
        IApiResult SetAuthenticationCredentials(string apikey, string contextId, string userId, string authCredentialsConfigParams = null);
        IApiResult SetUserEnabled(string apikey, string contextId, string userId, bool enabled);
        IApiResult SetUserName(string apikey, string contextId, string userId, string name);
    }

    internal class UsersComponent : IUsersComponent
    {
        private const string Component = "users";

        private readonly IZapClient _zapClient;

        public UsersComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetAuthenticationCredentials(string contextId, string userId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId }, { "userId", userId } };
            return _zapClient.CallApi(Component, "view", "getAuthenticationCredentials", parameters);
        }

        public IApiResult GetAuthenticationCredentialsConfigParams(string contextId)
        {
            var parameters = new Dictionary<string, string> { { "contextId", contextId } };
            return _zapClient.CallApi(Component, "view", "getAuthenticationCredentialsConfigParams", parameters);
        }

        public IApiResult GetUserById(IDictionary<string, string> parameters = null)
        {
            return _zapClient.CallApi(Component, "view", "getUserById", parameters);
        }

        public IApiResult GetUserLists(string contextId = null)
        {
            var parameters = new Dictionary<string, string>();
            if (contextId != null) parameters.Add("contextId", contextId);
            return _zapClient.CallApi(Component, "view", "getUserLists", parameters);
        }

        public IApiResult NewUser(string apikey, string contextId, string name)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("name", name);
            return _zapClient.CallApi(Component, "action", "newUser", parameters);
        }

        public IApiResult RemoveUser(string apikey, string contextId, string userId)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            return _zapClient.CallApi(Component, "action", "removeUser", parameters);
        }

        public IApiResult SetAuthenticationCredentials(string apikey, string contextId, string userId,
            string authCredentialsConfigParams = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            if (authCredentialsConfigParams != null) parameters.Add("authCredentialsConfigParams", authCredentialsConfigParams);
            return _zapClient.CallApi(Component, "action", "setAuthenticationCredentials", parameters);
        }

        public IApiResult SetUserEnabled(string apikey, string contextId, string userId, bool enabled)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            parameters.Add("enabled", enabled.ToString());
            return _zapClient.CallApi(Component, "action", "setUserEnabled", parameters);
        }

        public IApiResult SetUserName(string apikey, string contextId, string userId, string name)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextId", contextId);
            parameters.Add("userId", userId);
            parameters.Add("name", name);
            return _zapClient.CallApi(Component, "action", "setUserName", parameters);
        }
    }
}
