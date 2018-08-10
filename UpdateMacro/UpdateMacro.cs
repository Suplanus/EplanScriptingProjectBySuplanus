using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.UpdateMacro
{
    class XGedUpdateMacroAction_Overload
    {
        [DeclareAction("XGedUpdateMacroAction", 50)] // Overwrite with ordinal
        public void Action()
        {
            ActionCallingContext actionCallingContext = new ActionCallingContext();
            actionCallingContext.AddParameter("AutoAssignLastUsedRecord", "1");
            // ReSharper disable once RedundantNameQualifier
            // Eplan needs name qualifiier
            Eplan.EplApi.ApplicationFramework.Action action = new ActionManager().FindBaseActionFromFunctionAction(false); // Full Namespace, couse of compiler warning in EPLAN
            action.Execute(actionCallingContext);
        }
    }
}