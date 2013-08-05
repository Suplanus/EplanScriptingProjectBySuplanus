using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class SelectLanguage_UsingExample
{
    [Start]
    public void Execute()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();
        string ActionReturnParameterValue = string.Empty;

        acc.AddParameter("Language", "Project"); // parameters: "Project" or "Display"
        acc.AddParameter("DialogName", "MyDialogName");
        oCLI.Execute("SelectLanguage", acc);
        acc.GetParameter("Language", ref ActionReturnParameterValue);

        MessageBox.Show("Language from SelectLanguage:\n\n---> " + ActionReturnParameterValue);

    }
}
