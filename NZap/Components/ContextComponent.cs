using System.Collections.Generic;
using NZap.Entities;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IContextComponent
    {
        /* VIEWS */
        IApiResult GetContext(string contextName);
        IApiResult GetContextList();
        IApiResult GetExcludeRegexs(string contextName);
        IApiResult GetExcludedTechnologyList(string contextName);
        IApiResult GetIncludeRegexs(string contextName);
        IApiResult GetIncludedTechnologyList(string contextName);
        IApiResult GetTechnologyList();

        /* ACTIONS */
        IApiResult ExcludeAllContextTechnologies(string apikey, string contextName);
        IApiResult ExcludeContextTechnologies(string apikey, string contextName, string technologyNames);
        IApiResult ExcludeFromContext(string apikey, string contextName, string regex);
        IApiResult ExportContext(string apikey, string contextName, string contextFile);
        IApiResult ImportContext(string apikey, string contextFile);
        IApiResult IncludeAllContextTechnologies(string apikey, string contextName);
        IApiResult IncludeContextTechnologies(string apikey, string contextName, string technologyNames);
        IApiResult IncludeInContext(string apikey, string contextName, string regex);
        IApiResult NewContext(string apikey, string contextName);
        IApiResult RemoveContext(string apikey, string contextName);
        IApiResult SetContextInScope(string apikey, string contextName, bool inScope);
    }

    internal class ContextComponent : IContextComponent
    {
        private const string Component = "context";

        private readonly IZapClient _zapClient;

        public ContextComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult GetContext(string contextName)
        {
            var parameters = new Dictionary<string, string> { { "contextName", contextName } };
            return _zapClient.CallApi(Component, "view", "context", parameters);
        }

        public IApiResult GetContextList()
        {
            return _zapClient.CallApi(Component, "view", "contextList");
        }

        public IApiResult GetExcludeRegexs(string contextName)
        {
            var parameters = new Dictionary<string, string> { { "contextName", contextName } };
            return _zapClient.CallApi(Component, "view", "excludeRegexs", parameters);
        }

        public IApiResult GetExcludedTechnologyList(string contextName)
        {
            var parameters = new Dictionary<string, string> { { "contextName", contextName } };
            return _zapClient.CallApi(Component, "view", "excludedTechnologyList", parameters);
        }

        public IApiResult GetIncludeRegexs(string contextName)
        {
            var parameters = new Dictionary<string, string> { { "contextName", contextName } };
            return _zapClient.CallApi(Component, "view", "includeRegexs", parameters);
        }

        public IApiResult GetIncludedTechnologyList(string contextName)
        {
            var parameters = new Dictionary<string, string> { { "contextName", contextName } };
            return _zapClient.CallApi(Component, "view", "includedTechnologyList", parameters);
        }

        public IApiResult GetTechnologyList()
        {
            return _zapClient.CallApi(Component, "view", "technologyList");
        }

        public IApiResult ExcludeAllContextTechnologies(string apikey, string contextName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            return _zapClient.CallApi(Component, "action", "excludeAllContextTechnologies", parameters);
        }

        public IApiResult ExcludeContextTechnologies(string apikey, string contextName, string technologyNames)
        {
            return SetContextTechnologies(apikey, contextName, technologyNames, "excludeContextTechnologies");
        }

        public IApiResult ExcludeFromContext(string apikey, string contextName, string regex)
        {
            return SetContext(apikey, contextName, regex, "excludeFromContext");
        }

        public IApiResult ExportContext(string apikey, string contextName, string contextFile)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            parameters.Add("contextFile", contextFile);
            return _zapClient.CallApi(Component, "action", "exportContext", parameters);
        }

        public IApiResult ImportContext(string apikey, string contextFile)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextFile", contextFile);
            return _zapClient.CallApi(Component, "action", "importContext", parameters);
        }

        public IApiResult IncludeAllContextTechnologies(string apikey, string contextName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            return _zapClient.CallApi(Component, "action", "includeAllContextTechnologies", parameters);
        }

        public IApiResult IncludeContextTechnologies(string apikey, string contextName, string technologyNames)
        {
            return SetContextTechnologies(apikey, contextName, technologyNames, "includeContextTechnologies");
        }

        public IApiResult IncludeInContext(string apikey, string contextName, string regex)
        {
            return SetContext(apikey, contextName, regex, "includeInContext");
        }

        public IApiResult NewContext(string apikey, string contextName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            return _zapClient.CallApi(Component, "action", "newContext", parameters);
        }

        public IApiResult RemoveContext(string apikey, string contextName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            return _zapClient.CallApi(Component, "action", "removeContext", parameters);
        }

        public IApiResult SetContextInScope(string apikey, string contextName, bool inScope)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            parameters.Add("booleanInScope", inScope.ToString());
            return _zapClient.CallApi(Component, "action", "setContextInScope", parameters);
        }

        private IApiResult SetContextTechnologies(string apikey, string contextName, string technologyNames, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            parameters.Add("technologyNames", technologyNames);
            return _zapClient.CallApi(Component, "action", action, parameters);
        }

        private IApiResult SetContext(string apikey, string contextName, string regex, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("contextName", contextName);
            parameters.Add("regex", regex);
            return _zapClient.CallApi(Component, "action", action, parameters);
        }
    }
}
