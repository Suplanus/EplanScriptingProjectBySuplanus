/* Usage
	private static string GetProjectProperty(string id, string index)
	{
		string value = null;
		ActionCallingContext actionCallingContext = new ActionCallingContext();
		actionCallingContext.AddParameter("id", id);
		actionCallingContext.AddParameter("index", index);
		new CommandLineInterpreter().Execute("GetProjectProperty", actionCallingContext);
		actionCallingContext.GetParameter("value", ref value);
		return value;
	}
*/

using System;
using System.IO;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.GetProjectProperty
{
  class GetProjectProperty
  {
    private string GetProjectPropertyAction(string id, string index)
    {
      string value = null;
      ActionCallingContext actionCallingContext = new ActionCallingContext();
      actionCallingContext.AddParameter("id", id);
      actionCallingContext.AddParameter("index", index);
      new CommandLineInterpreter().Execute("GetProjectProperty", actionCallingContext);
      actionCallingContext.GetParameter("value", ref value);
      return value;
    }

    [DeclareAction("GetProjectProperty")]
    public void Action(string id, string index, out string value)
    {
      string pathTemplate = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
          "GetProjectProperty", "GetProjectProperty_Template.xml");
      string pathScheme = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
          "GetProjectProperty", "GetProjectProperty_Scheme.xml");

      bool isUserDefinied = string.IsNullOrEmpty(index) || index.ToUpper().Equals("NULL");

      try
      {
        // Set scheme
        const string QUOTE = "\"";
        string content = File.ReadAllText(pathTemplate);

        if (isUserDefinied)
        {
          string isSelectedPropertyUserDef =
            @"<Setting name=" + QUOTE + "SelectedPropertyIdUserDef" + QUOTE + " type=" + QUOTE + "string" + QUOTE + ">" +
            "<Val>" + id + "</Val>" +
            "</Setting>";

          content = content.Replace("GetProjectProperty_ID_SelectedPropertyId", "0");
          content = content.Replace("IsSelectedPropertyIdUserDef", isSelectedPropertyUserDef);
          content = content.Replace("GetProjectProperty_INDEX", "0");
          content = content.Replace("GetProjectProperty_ID", id);
        }
        else
        {
          content = content.Replace("GetProjectProperty_ID_SelectedPropertyId", id);
          content = content.Replace("IsSelectedPropertyIdUserDef", "");
          content = content.Replace("GetProjectProperty_INDEX", index);
          content = content.Replace("GetProjectProperty_ID", id);

        }

        File.WriteAllText(pathScheme, content);

        new Settings().ReadSettings(pathScheme);

        string pathOutput = Path.Combine(
            PathMap.SubstitutePath("$(MD_SCRIPTS)"), "GetProjectProperty",
            "GetProjectProperty_Output.txt");

        // Export
        ActionCallingContext actionCallingContext = new ActionCallingContext();
        actionCallingContext.AddParameter("configscheme", "GetProjectProperty");
        actionCallingContext.AddParameter("destinationfile", pathOutput);
        actionCallingContext.AddParameter("language", "de_DE");
        new CommandLineInterpreter().Execute("label", actionCallingContext);

        // Read
        value = File.ReadAllLines(pathOutput)[0];
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message, "GetProjectProperty", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        value = "[Error]";
      }

    }

    [Start]
    public void Test()
    {
      string projectProperty;

      // No index
      projectProperty = GetProjectPropertyAction("10000", "0");
      MessageBox.Show("No index: " + Environment.NewLine +  projectProperty);

      // Index
      projectProperty = GetProjectPropertyAction("10901", "1");
      MessageBox.Show("Index: " + Environment.NewLine + projectProperty);

      // UserDefinied
      projectProperty = GetProjectPropertyAction("ibKastl.Project.Test", null);
      MessageBox.Show("UserDefinied: " + Environment.NewLine + projectProperty);
    }
  }
}
