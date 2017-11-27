Public Class Kabelkorrigieren

  <DeclareMenu()> _
 Public Sub MenuFunction()

        Dim oConMenuLoc As New Eplan.EplApi.Gui.ContextMenuLocation("XCCablePrjDataTabTree", "1126")
        Dim oConMenu As New Eplan.EplApi.Gui.ContextMenu()
        OConMenu.Addmenuitem(oConMenuLoc, "Kabel korrigieren...", "XCActionCorrectCable", False, False)

  End Sub
End Class