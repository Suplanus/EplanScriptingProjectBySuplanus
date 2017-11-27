Public Class Klemmenkorrigieren

  <DeclareMenu()> _
 Public Sub MenuFunction()

        Dim oConMenuLoc As New Eplan.EplApi.Gui.ContextMenuLocation("TSGViewTree", "1004")
        Dim oConMenu As New Eplan.EplApi.Gui.ContextMenu()
        OConMenu.Addmenuitem(oConMenuLoc, "Klemmen korrigieren...", "XTPCallAutoCorrectionDlgAction", False, False)

  End Sub
End Class