using Eplan.EplApi.Scripting;

public class MacrosInstallationSpaceContextMenu
{
    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.ContextMenu oMenu =
            new Eplan.EplApi.Gui.ContextMenu();

        Eplan.EplApi.Gui.ContextMenuLocation oLocation =
            new Eplan.EplApi.Gui.ContextMenuLocation(
                "Editor",
                "Cabinet3D"
                );

        oMenu.AddMenuItem(
            oLocation,
            "Fenstermakro erstellen",
            "StoreWindowMacro",
            true,
            false
            );

        oMenu.AddMenuItem(
            oLocation,
            "Symbolmakro erstellen",
            "StoreSymbolMacro",
            false,
            true
            );
    }
}