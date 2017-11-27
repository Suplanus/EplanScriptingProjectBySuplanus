Public Class SPSAdressieren

  <DeclareMenu()> _
 Public Sub MenuFunction()
	
        Dim oConMenuLoc As New Eplan.EplApi.Gui.ContextMenuLocation("XPlcPrjDataTreeTab", "1012")
        Dim oConMenu As New Eplan.EplApi.Gui.ContextMenu()
        OConMenu.Addmenuitem(oConMenuLoc, "SPS Adressieren...", "XPlcReAddressDlgShow", False, False)

  End Sub 
End Class
