using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;
using System;
using System.Windows.Forms;

public class TranslateLanguages
{
    [Start]
    public void Execute()
    {
        Settings setting = new Settings();
        string stringSetting = setting.GetStringSetting("USER.TRANSLATE.TRANSLATE_LANGUAGES", 0);
        MessageBox.Show(stringSetting.Replace(";", Environment.NewLine));
    }
}