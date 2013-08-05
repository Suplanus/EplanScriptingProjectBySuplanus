using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class InsertPageMacro
{
    [Start]
    public void InsertPageMacroVoid()
    {
        string strFilename = @"C:\test.emp";

        ActionCallingContext oAcc = new ActionCallingContext();
        CommandLineInterpreter oCLI = new CommandLineInterpreter();

        oAcc.AddParameter("filename", strFilename);
        oCLI.Execute("XMInsertPageMacro", oAcc);
    }
}