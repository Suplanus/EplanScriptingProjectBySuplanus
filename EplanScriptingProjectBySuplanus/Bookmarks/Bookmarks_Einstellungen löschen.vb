' BookmarksSettingDelete, Version 1.0.0, vom 29.11.2011
'
' Löscht die Benutzereinstellung aus EPLAN
'
' Copyright by Frank Schöneck, 2011
' letzte Änderung: Frank Schöneck, 29.11.2011 V1.0.0, Projektbeginn
'
' für Eplan Electric P8, ab V2.1.4
'

Public Class Bookmarks
	<Start> _
	Public Sub BookmarksSettingDelete()
		'Settings löschen
       Dim oSettings As New Eplan.EplApi.Base.Settings()
		If oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION") Then
			oSettings.DeleteSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION")
			Messagebox.show("Die Einstellungen 'USER.SCRIPTS.BOOKMARKS.FORMLOCATION' wurden gelöscht.", "Bookmarks Einstellungen löschen", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			Messagebox.show("Die Einstellungen wurden nicht gefunden !", "Bookmarks Einstellungen löschen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
		If oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE") Then
			oSettings.DeleteSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE")
			Messagebox.show("Die Einstellungen 'USER.SCRIPTS.BOOKMARKS.FORMSIZE' wurden gelöscht.", "Bookmarks Einstellungen löschen", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			Messagebox.show("Die Einstellungen wurden nicht gefunden !", "Bookmarks Einstellungen löschen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
	End Sub 
End Class
