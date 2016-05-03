using System;
using NZap.Entities;
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
            return _zapClient.CallApi(Component, "view", "listEngines");
        }

        public IApiResult ListScripts()
        {
            return _zapClient.CallApi(Component, "view", "listScripts");
        }

        public IApiResult Disable(string apikey, string scriptName)
        {
            return SetScriptStatus(apikey, scriptName, "disable");
        }

        public IApiResult Enable(string apikey, string scriptName)
        {
            return SetScriptStatus(apikey, scriptName, "enable");
        }

        public IApiResult Load(string apikey, string scriptName, string scriptType, string scriptEngine, string fileName,
            string scriptDescription = null)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            parameters.Add("scriptType", scriptType);
            parameters.Add("scriptEngine", scriptEngine);
            parameters.Add("fileName", fileName);
            if (scriptDescription != null) parameters.Add("scriptDescription", scriptDescription);
            try
            {
                return _zapClient.CallApi(Component, "action", "load", parameters);
            }
            catch (Exception)
            {
                throw new ZapApiException($"Failed to load script: {scriptName}");
            }
        }

        public IApiResult Remove(string apikey, string scriptName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            try
            {
                return _zapClient.CallApi(Component, "action", "remove", parameters);
            }
            catch (Exception)
            {
                throw new ZapApiException($"No script with name: {scriptName}");
            }
        }

        public IApiResult RunStandAloneScript(string apikey, string scriptName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            try
            {
                return _zapClient.CallApi(Component, "action", "runStandAloneScript", parameters);
            }
            catch (Exception)
            {
                throw new ZapApiException($"No script with name: {scriptName}");
            }
        }

        private IApiResult SetScriptStatus(string apikey, string scriptName, string action)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            try
            {
                return _zapClient.CallApi(Component, "action", action, parameters);
            }
            catch (Exception)
            {
                throw new ZapApiException($"No script with name: {scriptName}");
            }
        }
    }
}
