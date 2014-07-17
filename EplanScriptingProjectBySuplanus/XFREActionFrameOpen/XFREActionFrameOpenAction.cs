using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

class XFREActionFrameOpenAction
{
    [Start]
    public void XFREActionFrameOpenActionFunction()
    {
        ActionCallingContext acc = new ActionCallingContext();
        acc.AddParameter("NewFrame", "1");
        acc.SetStrings(new string[] { @"\\Path\To\Frame\NameOfFile.fn1" });
        new CommandLineInterpreter().Execute("XFREActionFrameOpen", acc);
    }
}