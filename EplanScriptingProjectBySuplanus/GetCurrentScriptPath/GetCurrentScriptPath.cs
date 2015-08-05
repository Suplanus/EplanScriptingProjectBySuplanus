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

using System.IO;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.GetCurrentScriptPath
{
    class GetCurrentScriptPath
    {
        [DeclareAction("GetCurrentScriptPath")]
        public void Action(string scriptName, out string value)
        {
            Settings settings = new Settings();
            string scriptPath = string.Empty;

            // If script is loaded
            var settingsUrlScripts = "STATION.EplanEplApiScriptGui.Scripts";
            int countOfScripts = settings.GetCountOfValues(settingsUrlScripts);
            for (int i = 0; i < countOfScripts; i++)
            {
                scriptPath = settings.GetStringSetting(settingsUrlScripts, i);
                if (scriptPath.EndsWith(@"\" + scriptName))
                {
                    value = Path.GetDirectoryName(scriptPath);
                    return;
                }
            }

            // If script is executed
            if (settings.GetStringSetting("USER.FileSelection.1.PermamentSelection.Files.file1", 0) == scriptName)
            {
                value = settings.GetStringSetting("USER.FileSelection.1.PermamentSelection.FolderName", 0);
                return;
            }

            // Not found
            value = null;
            return;
        }
    }
}