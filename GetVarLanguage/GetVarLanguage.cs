/* Usage
    private static string GetVarLanguage()
    {
        string value = null;
        ActionCallingContext actionCallingContext = new ActionCallingContext();
        new CommandLineInterpreter().Execute("GetVarLanguage", actionCallingContext);
        actionCallingContext.GetParameter("value", ref value);
        return value;
    }
*/

using System.IO;
using System.Xml;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.GetVarLanguage
{
    public class GetVarLanguage
    {
        [DeclareAction("GetVarLanguage")]
        public void Action(out string value)
        {
            // Get language from settings
            string tempFile = Path.Combine(PathMap.SubstitutePath("$(TMP)"), "GetVarLanguage.xml");

            ActionCallingContext actionCallingContext = new ActionCallingContext();
            actionCallingContext.AddParameter("prj", FullProjectPath());
            actionCallingContext.AddParameter("node", "TRANSLATEGUI");
            actionCallingContext.AddParameter("XMLFile", tempFile);
            new CommandLineInterpreter().Execute("XSettingsExport", actionCallingContext);

            // Needed because there is no direct access to setting
            string language = GetValueSettingsXml(tempFile, "/Settings/CAT/MOD/Setting[@name='VAR_LANGUAGE']/Val");

            // If setting is GUI language, return the GUI language
            if (language == "##_##")
            {
                language = new Languages().GuiLanguage.GetString();
            }

            value = language;
        }

        private static string GetValueSettingsXml(string filename, string url)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList rankListSchemaName = xmlDocument.SelectNodes(url);
            if (rankListSchemaName != null && rankListSchemaName.Count > 0)
            {
                string value = rankListSchemaName[0].InnerText;
                return value;
            }
            return null;
        }

        private static string FullProjectPath()
        {
            ActionCallingContext acc = new ActionCallingContext();
            acc.AddParameter("TYPE", "PROJECT");

            string projectPath = string.Empty;
            new CommandLineInterpreter().Execute("selectionset", acc);
            acc.GetParameter("PROJECT", ref projectPath);

            return projectPath;
        }
    }
}