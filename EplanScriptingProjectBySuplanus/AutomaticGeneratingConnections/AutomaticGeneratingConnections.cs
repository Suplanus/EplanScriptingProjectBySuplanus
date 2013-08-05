using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class AutomaticGeneratingConnections
{
    [DeclareEventHandler("onActionStart.String.PrnPrintDialogShow")]
    public void ehPrint()
    {
        GenerateConnections();
    }

    [DeclareEventHandler("onActionStart.String.XPdfExportAction")]
    public void ehPdf()
    {
        GenerateConnections();
    }

    private static void GenerateConnections()
    {
        ActionCallingContext acc = new ActionCallingContext();
        acc.AddParameter("TYPE", "CONNECTIONS");
        new CommandLineInterpreter().Execute("generate",acc);
    }
}