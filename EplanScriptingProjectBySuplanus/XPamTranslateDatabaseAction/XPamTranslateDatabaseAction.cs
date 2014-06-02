using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

class XPamTranslateDatabaseActionScript
{
    [Start]
    public void XPamTranslateDatabaseActionFunction()
    {
        CommandLineInterpreter oCli = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();
        acc.AddParameter("_cmdline", "XPamTranslateDatabaseAction");
        oCli.Execute("XPamTranslateDatabaseAction", acc);
    }
}