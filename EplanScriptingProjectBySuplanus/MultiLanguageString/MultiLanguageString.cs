using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

class MultiLanguageString
{
    [Start]
    public void Function()
    {
        MultiLangString multiLangString = new MultiLangString();
        multiLangString.AddString(ISOCode.Language.L_en_EN, "My Text in English");
        multiLangString.AddString(ISOCode.Language.L_de_DE, "Mein Text in Deutsch");
        // Sorry there is no Klingon implemented :^)
    }
}