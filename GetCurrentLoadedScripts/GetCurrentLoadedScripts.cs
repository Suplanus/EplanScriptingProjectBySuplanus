/* Usage
    private static string GetCurrentLoadedScripts()
    {
        string value = null;
        ActionCallingContext actionCallingContext = new ActionCallingContext();
        new CommandLineInterpreter().Execute("GetCurrentLoadedScripts", actionCallingContext);
        actionCallingContext.GetParameter("value", ref value);
        return value;
    }
*/

using System.Text;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.GetCurrentLoadedScripts
{
    public class GetCurrentLoadedScripts
    {
        [DeclareAction("GetCurrentLoadedScripts")]
        public void Action(out string value)
        {
            Settings settings = new Settings();
            var settingsUrlScripts = "STATION.EplanEplApiScriptGui.Scripts";
            int countOfScripts = settings.GetCountOfValues(settingsUrlScripts);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < countOfScripts; i++)
            {
                string scriptPath = settings.GetStringSetting(settingsUrlScripts, i);
                stringBuilder.Append(scriptPath);

                // not last one
                if (i != countOfScripts - 1)
                {
                    stringBuilder.Append("|");
                }
            }

            // returns list: "\\path\script1.cs|\\path\script2.vb"
            value = stringBuilder.ToString();
        }
    }
}