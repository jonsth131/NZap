using NZap.Entities;
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

    public class ScriptComponent : IScriptComponent
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
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            return _zapClient.CallApi(Component, "action", "disable", parameters);
        }

        public IApiResult Enable(string apikey, string scriptName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            return _zapClient.CallApi(Component, "action", "enable", parameters);
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
            return _zapClient.CallApi(Component, "action", "load", parameters);
        }

        public IApiResult Remove(string apikey, string scriptName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            return _zapClient.CallApi(Component, "action", "remove", parameters);
        }

        public IApiResult RunStandAloneScript(string apikey, string scriptName)
        {
            var parameters = ApikeyHelper.ReturnParameterDictFromApikey(apikey);
            parameters.Add("scriptName", scriptName);
            return _zapClient.CallApi(Component, "action", "runStandAloneScript", parameters);
        }
    }
}
