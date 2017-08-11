using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.ShowNavigators
{
    class ShowNavigators
    {
        [DeclareAction("ShowNavigators")]
        public bool Action(string actionNavigatorVisible)
        {
            // Objects
            var commandLineInterpreter = new CommandLineInterpreter();
            SchemeSetting schemeSetting = new SchemeSetting();
            Settings settings = new Settings();
            string schemePath = "USER.WORKSPACE.NAMED";
            string schemeName = "dummy";

            // SaveWorkspace
            commandLineInterpreter.Execute("SaveWorkspaceAction /Workspacename:dummy");

            // Parse parameter
            var splitGroups = actionNavigatorVisible.Split('|');
            foreach (var splitGroup in splitGroups)
            {
                // Get values
                var splitNavigators = splitGroup.Split(';');
                if (splitNavigators.Length != 3)
                {
                    MessageBox.Show("Invalid parameter", "ShowNavigators - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string action = splitNavigators[0];
                string navigatorName = splitNavigators[1];
                string visibleText = splitNavigators[2].ToUpper();
                bool visible = visibleText == "TRUE" || visibleText == "1";

                // Settings path e.g.: USER.WORKSPACE.NAMED.dummy.Data.Visibility.XMacroPdd
                string settingsPath = schemePath + "." + schemeName + ".Data.Visibility." + navigatorName;

                // Hide & Seek :^)
                if (visible)
                {
                    // Show
                    if (!settings.ExistSetting(settingsPath))
                    {
                        commandLineInterpreter.Execute(action);
                    }
                }
                else
                {
                    // Hide
                    if (settings.ExistSetting(settingsPath))
                    {
                        commandLineInterpreter.Execute(action);
                    }
                }
            }

            // RemoveWorkspace            
            schemeSetting.Init(schemePath);
            if (schemeSetting.CheckIfSchemeExists(schemeName))
            {
                schemeSetting.RemoveScheme(schemeName);
            }
            

            return false;
        }
    }
}
