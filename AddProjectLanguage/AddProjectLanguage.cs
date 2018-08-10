using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

internal class AddProjectLanguageClass
{
    [Start]
    public void XAfActionSettingProject_Start()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext oACC = new ActionCallingContext();
        oACC.AddParameter("set", "TRANSLATEGUI.TRANSLATE_LANGUAGES");
        oACC.AddParameter("value", "de_DE;en_EN;zh_CN;");

        oCLI.Execute("XAfActionSettingProject", oACC);
        return;
    }
}

