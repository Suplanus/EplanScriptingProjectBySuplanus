using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class SetUserPaths
{
    [DeclareAction("SetUserPaths")]
    public void Function(string SchemeName)
    {
        Settings oSettings = new Settings();
        oSettings.SetStringSetting("USER.ModalDialogs.PathsScheme.LastUsed", SchemeName, 0);

        SettingNode Sn = new SettingNode("USER.ModalDialogs.PathsScheme." + SchemeName + ".Data");
        System.Collections.Specialized.StringCollection Sc = new System.Collections.Specialized.StringCollection();
        Sn.GetListOfSettings(ref Sc, false);
        foreach (string s in Sc)
        {
            string sValue = oSettings.GetStringSetting("USER.ModalDialogs.PathsScheme." + SchemeName + ".Data." + s, 0);
            switch (s)
            {
                case "ExternalDocuments":
                case "Scheme":
                case "Scripts":
                case "XML":
                    oSettings.SetStringSetting("USER.SYSTEM.Pathnames." + s, sValue, 0);
                    break;

                default:
                    oSettings.SetStringSetting("USER.TrDMProject.Masterdata.Pathnames." + s, sValue, 0);
                    break;
            }
        }
    }
}
