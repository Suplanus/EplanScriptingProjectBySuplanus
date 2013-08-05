using System.Windows.Forms;
using System.Xml;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class Class
{
    [DeclareAction("GetProjectProperty")]
    public void Function(int ID)
    {
        string filename =
            PathMap.SubstitutePath("$(PROJECTPATH)" + @"\"
            + "Projectinfo.xml");

        string PropertyValue = ReadXml(filename,ID);

        MessageBox.Show(
            "Eigenschaftwert von " + ID + ":\n" +
            PropertyValue,
            "Information",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );

        return;
    }

    private static string ReadXml(string filename, int id)
    {
        string lastVersion = string.Empty;
        XmlTextReader reader = new XmlTextReader(filename);
        while (reader.Read())
        {
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    if (reader.Name == "id")
                    {
                        if (reader.Value == id.ToString())
                        {
                            return lastVersion = reader.ReadString();
                        }
                    }
                }
            }
        }

        return lastVersion;
    }

}



