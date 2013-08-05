using System.Windows.Forms;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class SetStringSetting
{
    [Start]
    public void SetStringSettingVoid()
    {
        const string SettingPath = "USER.SCRIPTS.SUPLANUS";
        Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();

        // Check if setting exists
        if (oSettings.ExistSetting(SettingPath))
        {
            oSettings.DeleteSetting(SettingPath);
            MessageBox.Show("Setting removed.", SettingPath);
        }

        // Add setting
        oSettings.AddStringSetting(
            SettingPath,
            new string[] {},
            new string[] {},
            "My setting from Suplanus",
            new string[] {@"Default value of test setting"},
            ISettings.CreationFlag.Insert
            );

        // Add setting values
        oSettings.SetStringSetting(SettingPath, "Message 0", 0);
        oSettings.SetStringSetting(SettingPath, "Message 1", 1);
        oSettings.SetStringSetting(SettingPath, "Message 2", 2);
        MessageBox.Show("Setting OK.", SettingPath);

        // Show setting values
        string value = oSettings.GetStringSetting(SettingPath, 1);
        MessageBox.Show("Value of Index " + 1 + ":\n" + value, SettingPath);
    }
}