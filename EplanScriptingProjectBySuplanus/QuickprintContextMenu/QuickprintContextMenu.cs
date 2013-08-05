//
//  Dieses Skript fügt einen Menüpunkt "Seite drucken" im Kontextmenü des 
//  grafischen Editors hinzu. Die Seite wird über den vom Benutzer als
//  Standard definierten Drucker ausgegeben.
//
//  Christian Klasen  
//
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class Class
{
    [DeclareRegister]
    public void Register()
    {
        MessageBox.Show("Script geladen.");

        return;
    }

    [DeclareUnregister]
    public void UnRegister()
    {
        MessageBox.Show("Script entladen.");

        return;
    }


    [DeclareAction("MenuAction")]
    public void ActionFunction()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();

        string strPages = string.Empty;

        acc.AddParameter("TYPE", "PAGES");

        oCLI.Execute("selectionset", acc);

        acc.GetParameter("PAGES", ref strPages);
    
        acc.AddParameter("PAGENAME", strPages);

        oCLI.Execute("print", acc);

        //MessageBox.Show("Seite gedruckt");
        return;
    }

    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.ContextMenu oMenu =
            new Eplan.EplApi.Gui.ContextMenu();

        Eplan.EplApi.Gui.ContextMenuLocation oLocation =
            new Eplan.EplApi.Gui.ContextMenuLocation(
                "Editor",
                "Ged"
                );

        oMenu.AddMenuItem(
            oLocation,
            "Seite drucken",
            "MenuAction",
            true,
            false
            );

        return;
    }

}




