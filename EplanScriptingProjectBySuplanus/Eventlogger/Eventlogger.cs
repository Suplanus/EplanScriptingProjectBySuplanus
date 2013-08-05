using System;
using System.IO;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;
public class SimpleEventHandler
{
    [Start]
    [DeclareEventHandler("onActionEnd.String.*")]
    public long MyEventHandlerFunction2(IEventParameter iEventParameter)
    {
        try
        {
            EventParameterString oEventParameterString = new EventParameterString(iEventParameter);
            String strActionName = oEventParameterString.String;
            StreamWriter sw;
            FileInfo fi = new FileInfo(@"C:\Test\Events.txt");
            sw = fi.AppendText();
            sw.WriteLine("oCLI.Execute(\"onActionEnd.String.{0}\");", strActionName);
            sw.Close();
        }
        catch (InvalidCastException exc)
        {
            System.Windows.Forms.MessageBox.Show("Parameter error: " + exc.Message, "MyEventHandler");
        }
        return 0;
    }
}