Public Class Verbindungenkorrigieren

  <DeclareMenu()> _
 Public Sub MenuFunction()

        Dim oConMenuLoc As New Eplan.EplApi.Gui.ContextMenuLocation("XCmPrjDataTreeDialog", "1017")
        Dim oConMenu As New Eplan.EplApi.Gui.ContextMenu()
        OConMenu.Addmenuitem(oConMenuLoc, "Verbindungen korrigieren...", "XCMCorrectionChoiceAction", False, False)

  End Sub
End Class