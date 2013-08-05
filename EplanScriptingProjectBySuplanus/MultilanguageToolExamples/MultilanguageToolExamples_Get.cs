using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class MultilanguageToolExamples_Get
{
    [Start]
    public void MultilanguageToolExamples_Get_Void()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();
        string ActionReturnParameterValue = string.Empty;
        string strMessage = string.Empty;

        #region GetProjectLanguages
        oCLI.Execute("GetProjectLanguages", acc);
        acc.GetParameter("LANGUAGELIST", ref ActionReturnParameterValue);
        string[] ProjectLanguages = ActionReturnParameterValue.Split(';');

        foreach (string s in ProjectLanguages)
        {
            strMessage = strMessage + s + "\n";
        }
        MessageBox.Show(strMessage, "GetProjectLanguages");
        strMessage = string.Empty;
        #endregion

        #region GetDisplayLanguages
        oCLI.Execute("GetDisplayLanguages", acc);
        acc.GetParameter("LANGUAGELIST", ref ActionReturnParameterValue);
        string[] DisplayLanguages = ActionReturnParameterValue.Split(';');

        foreach(string s in DisplayLanguages)
        {
            strMessage = strMessage + s + "\n";
        }
        MessageBox.Show(strMessage, "GetDisplayLanguages");
        strMessage = string.Empty;
        #endregion

        #region GetVariableLanguage
        oCLI.Execute("GetVariableLanguage", acc);
        acc.GetParameter("LANGUAGELIST", ref ActionReturnParameterValue);
        string VariableLanguage = ActionReturnParameterValue;
        strMessage = strMessage + VariableLanguage + "\n";
        MessageBox.Show(strMessage, "GetVariableLanguage");
        strMessage = string.Empty;
        #endregion

    }
}