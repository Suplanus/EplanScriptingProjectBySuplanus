' RemoveSelection, Version 1.0.0, vom 29.02.2012
'
' Steuert, ob Objekte nach einer Interaktion deselektiert werden sollen.
' Default = 1
'
' Copyright by Frank Schöneck, 2012
'
' für Eplan Electric P8, ab V2.1.6
'
'
Public Class WriteSettings
    <Start()> _
    Public Sub MyFunction()

        Dim bolSetting As Boolean
        Dim oSettings As New Eplan.EplApi.Base.Settings()

        'Einstellung auslesen
		bolSetting = oSettings.getBoolSetting("USER.GedViewer.RemoveSelection", 0)

        'wenn nicht gesetzt, setzen
        If bolSetting = False Then
			oSettings.setBoolSetting("USER.GedViewer.RemoveSelection", True, 0)
			MessageBox.Show("Die Einstellung wurde 'aktiviert'.", "RemoveSelection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'wenn gesetzt, zurücksetzen
        ElseIf bolSetting = True Then
			oSettings.setBoolSetting("USER.GedViewer.RemoveSelection", False, 0)
			MessageBox.Show("Die Einstellung wurde 'deaktiviert'.", "RemoveSelection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub 'MyFunction
		
End Class
	 