using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class PrintPages
{
    [DeclareAction("PrintPages")]
    public void PrintPagesVoid()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();

        string strPages = string.Empty;
        acc.AddParameter("TYPE", "PAGES");
        oCLI.Execute("selectionset", acc);
        acc.GetParameter("PAGES", ref strPages);

        Progress oProgress = new Progress("SimpleProgress");
        oProgress.SetAllowCancel(true);
        oProgress.SetAskOnCancel(true);
        oProgress.SetNeededSteps(3);
        oProgress.SetTitle("Drucken");
        oProgress.ShowImmediately();


        foreach (string Page in strPages.Split(';'))
        {
            if (!oProgress.Canceled())
            {
                acc.AddParameter("PAGENAME", Page);
                oCLI.Execute("print", acc);
            }
            else
            {
                break;
            }
        }
        oProgress.EndPart(true);

        return;
    }

    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.ContextMenu oMenu =
            new Eplan.EplApi.Gui.ContextMenu();

        Eplan.EplApi.Gui.ContextMenuLocation oLocation =
            new Eplan.EplApi.Gui.ContextMenuLocation(
                "PmPageObjectTreeDialog",
                "1007"
                );

        oMenu.AddMenuItem(
            oLocation,
            "Seite(n) drucken",
            "PrintPages",
            true,
            false
            );

        return;
    }

}




