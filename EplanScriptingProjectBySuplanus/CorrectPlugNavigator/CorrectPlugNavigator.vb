Public Class Steckerkorrigieren

  <DeclareMenu()> _
 Public Sub MenuFunction()

        Dim oConMenuLoc As New Eplan.EplApi.Gui.ContextMenuLocation("XpluGVTree", "1004")
        Dim oConMenu As New Eplan.EplApi.Gui.ContextMenu()
        OConMenu.Addmenuitem(oConMenuLoc, "Stecker korrigieren...", "XplugCallAutoCorrectionDlgAction", False, False)

  End Sub
End Class