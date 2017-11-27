using Eplan.EplApi.Gui;
using Eplan.EplApi.Scripting;

public class EnableMacroChange
{
    [DeclareMenu]
    public void CreateMenu()
    {
        ContextMenuLocation oCtxLoc = new ContextMenuLocation();
        oCtxLoc.DialogName = "Editor";
        oCtxLoc.ContextMenuName = "Ged";
        Eplan.EplApi.Gui.ContextMenu oCTXMnu = new Eplan.EplApi.Gui.ContextMenu();
        oCTXMnu.AddMenuItem(oCtxLoc, "Makro tauschen...", "XMSwapMacroFromMacroBoxAction", true, false);
    }
}