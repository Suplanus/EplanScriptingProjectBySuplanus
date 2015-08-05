/* Usage
    private static string GetCurrentScriptPath(string scriptName)
    {
        string value = null;
        ActionCallingContext actionCallingContext = new ActionCallingContext();
        actionCallingContext.AddParameter("scriptName", scriptName);
        new CommandLineInterpreter().Execute("GetCurrentScriptPath", actionCallingContext);
        actionCallingContext.GetParameter("value", ref value);
        return value;
    }
*/

using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.GetCurrentScriptPath
{
    public class GetCurrentScriptPath
    {
        [DeclareAction("GetCurrentScriptPath")]
        public void Action(string scriptName, out string value)
        {
            Settings settings = new Settings();
            var settingsUrlScripts = "STATION.EplanEplApiScriptGui.Scripts";
            int countOfScripts = settings.GetCountOfValues(settingsUrlScripts);
            for (int i = 0; i < countOfScripts; i++)
            {
                string scriptPath = settings.GetStringSetting(settingsUrlScripts, i);
                if (scriptPath.EndsWith(@"\" + scriptName))
                {
                    // found
                    value = scriptPath;
                    return;
                }
            }

            // not found
            value = null;
            return;
        }
    }
}