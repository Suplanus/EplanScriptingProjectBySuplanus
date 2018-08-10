using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class GetProjectnameOnPostOpen
{
    [DeclareEventHandler("Eplan.EplApi.OnPostOpenProject")]
    public void MyEventHandlerFunction(IEventParameter iEventParameter)
    {
        try
        {
            EventParameterString oEventParameterString = new EventParameterString(iEventParameter);
            MessageBox.Show("Projekt öffnen:\n" + oEventParameterString.String, "OnPostOpenProject");

        }
        catch (System.InvalidCastException exc)
        {
            MessageBox.Show(exc.Message, "Fehler");
        }
    }
}