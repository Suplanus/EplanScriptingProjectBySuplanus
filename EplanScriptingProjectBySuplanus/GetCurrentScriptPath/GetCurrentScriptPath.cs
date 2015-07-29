using System;
using System.Windows.Forms;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.GetCurrentScriptPath
{
    public class GetCurrentScriptPath
    {
        [Start]
        public void GetActualScriptPathAbfragen()
        {
            MessageBox.Show("Current script-path:" + Environment.NewLine + GetPath(),
                "GetCurrentScriptPath", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string GetPath()
        {
            Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
            string path= oSettings.GetExpandedStringSetting(
                "USER.FileSelection.1.PermamentSelection.FolderName", 0);
            return path;
        }
    }
}