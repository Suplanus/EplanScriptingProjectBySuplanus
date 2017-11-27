using System.Diagnostics;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class PagePdf
{
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
            "PDF erstellen",
            "PagePdf",
            true,
            false
            );
    }

    [DeclareAction("PagePdf")]
    public void PagePdfVoid()
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();
        
        if (fbd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        Progress oProgress = new Progress("SimpleProgress");
        oProgress.SetAllowCancel(true);
        oProgress.SetAskOnCancel(true);
        oProgress.BeginPart(100, "");
        oProgress.ShowImmediately();

        try
        {
            string strPages = string.Empty;
            acc.AddParameter("TYPE", "PAGES");
            oCLI.Execute("selectionset", acc);
            acc.GetParameter("PAGES", ref strPages);

            foreach (string CurrentPage in strPages.Split(';'))
            {
                if (!oProgress.Canceled())
                {
                    acc.AddParameter("TYPE", "PDFPAGESSCHEME");
                    acc.AddParameter("PAGENAME", CurrentPage);
                    acc.AddParameter("EXPORTFILE", fbd.SelectedPath + @"\" + CurrentPage);
                    acc.AddParameter("EXPORTSCHEME", "EPLAN_default_value");
                    oCLI.Execute("export", acc);
                }
                else
                {
                    oProgress.EndPart(true);
                    return;
                }
            }
            Process.Start(fbd.SelectedPath);
            oProgress.EndPart(true);
        }
        catch (System.Exception ex)
        {
            oProgress.EndPart(true);
            MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

}