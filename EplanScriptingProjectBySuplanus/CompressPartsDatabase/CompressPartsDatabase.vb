' CompressPartsDatabase, Version 2.0.0, vom 01.06.2012
'
' Führt eine Komprimierung der aktuell eingestellten Artikeldatenbank durch.
' Es wird eine Sicherheitskopie mit der Dateiendung '.Backup' angelegt.
'
' Copyright by Frank Schöneck, 2009
' letzte Änderung: Frank Schöneck, 31.08.2009 V1.0.0
'                  Frank Schöneck, 01.06.2012 V2.0.0, -Eplan eigene Action für CompressDataBase verwendet.
'                                                     -Script kann geladen oder ausgeführt werden.
'
' für Eplan Electric P8, ab V2.1.6
'

Imports System.IO

Public Class CompressPartsDatabase
	<Start()> _
	Public Sub MyFunction()
		CompressPartsDatabase()
	End Sub

	<DeclareMenu()> _
	Public Sub CompressPartsDatabase_Menu()
		Dim oMenu As New Eplan.EplApi.GUI.Menu()
		oMenu.AddMenuItem("Artikeldatenbank komprimieren...", "CompressPartsDatabase", "Es wird die aktuell eingestellte Artikeldatenbank komprimiert", 35177, 1, True, False)
	End Sub

	<DeclareAction("CompressPartsDatabase")> _
	Public Sub CompressPartsDatabase()

		Dim oSettings As New Eplan.EplApi.Base.Settings()
		Dim DatabaseName As String
		Dim DatabaseNameBackup As String
		Dim Result As DialogResult
		Dim boReturn As Boolean
		Dim NewLine As String = Environment.NewLine
		Dim Meldung As String

		'Einstellung 'Artikeldatenbank' auslesen
		DatabaseName = oSettings.getStringSetting("USER.PartsManagementGui.Database", 0)

		'Variablen auslesen und ersetzen
		DatabaseName = PathMap.SubstitutePath(DatabaseName)

		'Namen der Backup-Datei festlegen
		DatabaseNameBackup = DatabaseName & ".Backup"

		'Sicherheitsabfrage
		Meldung = "Soll die folgende Artikeldatenbank komprimiert werden?" & NewLine
		Meldung &= NewLine
		Meldung &= "'" & DatabaseName & "'" & NewLine
		Meldung &= NewLine
		Meldung &= "(Es wird im gleichen Ordner eine Sicherheitskopie mit der Dateiendung 'Backup' angelegt.)" & NewLine
		Result = MessageBox.Show(Meldung, "CompressPartsDatabase", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

		If Result = System.Windows.Forms.DialogResult.Yes Then
			'Cursur Warten anzeigen
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

			'Artikeldatenbank komprimieren
			boReturn = CompressParts(DatabaseName, DatabaseNameBackup)

			'Cursor wieder Standard
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

			'Ergebnismeldung anzeigen
			If boReturn = True Then
				Meldung = "Das komprimieren der Artikeldatenbank wurde erfolgreich durchgeführt." & NewLine
				Meldung &= NewLine
				Meldung &= "Dateigröße vorher: " & GetFileSize(DatabaseNameBackup) & NewLine
				Meldung &= "Dateigröße nachher: " & GetFileSize(DatabaseName) & NewLine
				MessageBox.Show(Meldung, "CompressPartsDatabase, Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			ElseIf boReturn = False Then
				MessageBox.Show("Das komprimieren der Artikeldatenbank konnte nicht erfolgreich durchgeführt werden!", "CompressPartsDatabase, Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		End If

	End Sub

	'Artikeldatenbank komprimieren
	Private Function CompressParts(ByVal DatabaseFilename As String, ByVal DatabaseFilenameBackup As String) As Boolean
		Try
			Dim cmdLineItp As New CommandLineInterpreter()
			Dim ACC As New ActionCallingContext
			Dim overwrite As Boolean = True

			'Backup anlegen
			File.Copy(DatabaseFilename, DatabaseFilenameBackup, overwrite)

			'PartsDatabase komprimieren
			ACC.AddParameter("Database", DatabaseFilename)
			cmdLineItp.Execute("XPamCompactDatabase", ACC)

			Return True
		Catch ex As Exception
			MessageBox.Show(ex.InnerException.ToString(), "CompressParts, Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False
		End Try
		Return False
	End Function

	'Anzeige der Dateigröße formatieren
	Private Function GetFileSize(ByVal path As String) As String
		Dim myFile As FileInfo
		Dim mySize As Single

		Try
			myFile = New FileInfo(path)
			If Not myFile.Exists Then
				mySize = 0
			Else
				mySize = myFile.Length
			End If
			Select Case mySize
				Case 0 To 1023
					Return Microsoft.VisualBasic.Format(mySize, "#,###") & " Bytes"
				Case 1024 To 1048575
					Return Microsoft.VisualBasic.Format(mySize / 1024, "#,###0.00") & " KB  (" & Microsoft.VisualBasic.Format(mySize, "#,###") & " Bytes)"
				Case 1048576 To 1043741823
					Return Microsoft.VisualBasic.Format(mySize / 1024 ^ 2, "#,###0.00") & " MB  (" & Microsoft.VisualBasic.Format(mySize, "#,###") & " Bytes)"
				Case Is > 1043741824
					Return Microsoft.VisualBasic.Format(mySize / 1024 ^ 3, "#,###0.00") & " GB  (" & Microsoft.VisualBasic.Format(mySize, "#,###") & " Bytes)"
			End Select
			Return "0 bytes"
		Catch ex As Exception
			Return "0 bytes"
		End Try

	End Function

End Class
	 