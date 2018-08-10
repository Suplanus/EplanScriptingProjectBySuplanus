using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class MultilanguageToolExamples_Set
{
    [Start]
    public void MultilanguageToolExamples_Set_Void()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();

        oCLI.Execute("XTrSettingsDlgAction"); // Settings DEFAULT

        #region SetProjectLanguages
        acc.AddParameter("LANGUAGELIST", "de_DE;en_EN;zh_CN;");
        oCLI.Execute("SetProjectLanguages", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        #region ChangeLanguage
        acc.AddParameter("varLANGUAGE","en_EN");
        acc.AddParameter("dispLANGUAGE", "en_EN;zh_CN;");
        oCLI.Execute("ChangeLanguage", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

    }
}