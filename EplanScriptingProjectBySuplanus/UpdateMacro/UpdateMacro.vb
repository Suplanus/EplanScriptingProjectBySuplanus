Public Class Makroaktualisieren

  <DeclareMenu()> _
 Public Sub MakroFunction()
	
        
        Dim SPConMenu As New Eplan.EplApi.Gui.ContextMenu()
	Dim SPConMenuLoc2 As New Eplan.EplApi.Gui.ContextMenuLocation("XSeSearchResultsTab1", "1002")

	SPConMenu.Addmenuitem(SPConMenuLoc2, "Makros aktualisieren...", "XGedUpdateMacroAction", False, False)

  End Sub 
End Class
