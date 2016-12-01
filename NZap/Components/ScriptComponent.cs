using System;
using NZap.Entities;
using NZap.Enums;
using NZap.Exceptions;
using NZap.Helpers;

namespace NZap.Components
{
    public interface IScriptComponent
    {
        /* VIEWS */
        IApiResult ListEngines();
        IApiResult ListScripts();

        /* ACTIONS */
        IApiResult Disable(string apikey, string scriptName);
        IApiResult Enable(string apikey, string scriptName);
        IApiResult Load(string apikey, string scriptName, string scriptType, string scriptEngine, string fileName, string scriptDescription = null);
        IApiResult Remove(string apikey, string scriptName);
        IApiResult RunStandAloneScript(string apikey, string scriptName);
    }

    internal class ScriptComponent : IScriptComponent
    {
        private const string Component = "script";

        private readonly IZapClient _zapClient;

        public ScriptComponent(IZapClient zapClient)
        {
            _zapClient = zapClient;
        }

        public IApiResult ListEngines()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "listEngines");
        }

        public IApiResult ListScripts()
        {
            return _zapClient.CallApi(Component, ActionTypes.View, "listScripts");
        }

        public IApiResult Disable(string apikey, string scriptName)
        {
            return SetScriptStatus(apikey, scriptName, "disable");
        }

        public IApiResult Enable(string apikey, string scriptName)
        {
            return SetScriptStatus(apikey, scriptName, "enable");
        }

        public IApiResult Load(string apikey, string scriptName, string scriptType, string scriptEngine, string fileName, string scriptDescription = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            parameters.Add("scriptType", scriptType);
            parameters.Add("scriptEngine", scriptEngine);
            parameters.Add("fileName", fileName);
            if (scriptDescription != null) parameters.Add("scriptDescription", scriptDescription);
            try
            {
                return _zapClient.CallApi(Component, ActionTypes.Action, "load", parameters);
            }
            catch (Exception)
            {
                throw new ZapApiException($"Failed to load script: {scriptName}");
            }
        }

        public IApiResult Remove(string apikey, string scriptName)
        {
            return SetScriptStatus(apikey, scriptName, "remove");
        }

        public IApiResult RunStandAloneScript(string apikey, string scriptName)
        {
            return SetScriptStatus(apikey, scriptName, "runStandAloneScript");
        }

        private IApiResult SetScriptStatus(string apikey, string scriptName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            try
            {
                return _zapClient.CallApi(Component, ActionTypes.Action, action, parameters);
            }
            catch (Exception)
            {
                throw new ZapApiException($"No script with name: {scriptName}");
            }
        }
    }
}
