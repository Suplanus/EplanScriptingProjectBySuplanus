' Bookmarks, Version 2.1.0, vom 08.10.2012
'
' Aufruf über einen neuen Menüpunkt "Lesezeichen..."
' im Untermenü "Projekt"
'
' Copyright by Frank Schöneck, 2011-2012
' letzte Änderung: Frank Schöneck, 29.11.2011 V1.0.0, -Projektbeginn
'                  Frank Schöneck, 04.06.2012 V1.1.0, -Eplan Versionsnummer in Bookmarks-Dateiname integriert.
'                  Frank Schöneck, 05.06.2012 V1.1.1, -Eplan Versionsnummer wird nun aus "EPLAN.exe" (ab V2.1) oder "W3U.exe" (bis 2.0) ermittelt.
'                  Frank Schöneck, 21.08.2012 V2.0.0, -Lesezeichen Tooltip zeigt nun den kompletten Pfad des Projektes an.
'                                                     -Es wird nun das vorhanden sein der Projekte getestet und ggf. das Lesezeichen grau dargestellt, das Lesezeichen bleibt aber weiter aktiv (geht im ListView nicht anders)
'                                                     -Neuer Menüpunkt 'Akualisieren (F5)' ins Kontextmenü eingebaut (Taste F5 geht nicht im Scripting)
'                                                     -Menüpunkt "Lesezeichen" ist nun unter "Schließen" im Projekt-Menü gewandert. (Wegen Select-Versionen)
'                  Frank Schöneck, 08.10.2012 V2.1.0, -Lesezeichen können nun nach oben/unten verschoben werden.
'
' für Eplan Electric P8, V2.0 / V2.1 / V2.2
'
Imports System.IO
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class Bookmarks

	'Menüpunkt 'Lesezeichen' erzeugen
    <DeclareMenu()> _
    Public Sub BookmarksMenu()
        Dim oMenu As New Eplan.EplApi.GUI.Menu()

		oMenu.AddMenuItem("Lesezeichen", "DialogLesezeichen", "Lesezeichen-Navigator ein- / ausschalten", 35103, 1, False, False) 'Menüpunkt unter "Verwaltung"
		'oMenu.AddMenuItem("Lese&zeichen", "DialogLesezeichen", "Lesezeichen-Navigator ein- / ausschalten", 35340, 1, False, False)	'Menüpunkt unter "Schließen"

    End Sub

    'Prüft ob Eplan gestartet wurde
    <DeclareEventHandler("Eplan.EplApi.OnMainStart")> _
    Public Function MyEventEplanStart(ByVal iEventParameter As IEventParameter) As Long
        Dim iFormVisible As Integer
        Dim oSettings As New Eplan.EplApi.Base.Settings()

        'War die Form beim letzten mal sichtbar?
		If oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION") Then
			iFormVisible = oSettings.GetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", 2)
		End If

        'wenn ja (1) denn Form anzeigen
        If iFormVisible = 1 Then
            Dim cmdLineItp As New CommandLineInterpreter()
            cmdLineItp.Execute("DialogLesezeichen")
        End If

    End Function

    'Prüft ob Eplan beendet wird
    <DeclareEventHandler("Eplan.EplApi.OnMainEnd")> _
    Public Function MyEventEplanEnd(ByVal iEventParameter As IEventParameter) As Long
        Dim oSettings As New Eplan.EplApi.Base.Settings()

        ' Prüfen, ob Form angezeigt wird, wenn ja merken
        If FormIsLoaded("frmLesezeichen") Then
			oSettings.SetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", 1, 2) '1 = Visible = True
        Else
			oSettings.SetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", 0, 2) '0 = Visible = False
        End If

    End Function

    'Dialog "Lesezeichen" anzeigen
    <DeclareAction("DialogLesezeichen")> _
    Public Sub DialogLesezeichen()

		' Prüfen, ob Form bereits geladen, falls nicht, jetzt laden und anzeigen
        If Not FormIsLoaded("frmLesezeichen") Then
			Dim objForm As New Form1()
			objForm.InitializeComponent()
            objForm.Show()
        Else
			Application.Exit() 'schon geladen deshalb beenden  (für 2 Schirm-Arbeitsplätze!!!)
			'BringFormToFront("frmLesezeichen") 'Form in den Vordergrund bringen (für 1 Schirm-Arbeitsplätze!!!)
		End If

	End Sub

    'Prüft, ob eine bestimmte Form bereits geladen ist und gibt im Erfolgsfall True zurück
    Public Function FormIsLoaded(ByVal sName As String) As Boolean
        Dim bResult As Boolean = False

        ' alle geöffneten Forms durchlauden
        For Each oForm As Form In Application.OpenForms
            If oForm.Name.ToLower = sName.ToLower Then
				bResult = True
				Exit For
            End If
        Next

        Return (bResult)
	End Function

	'Prüft, ob eine bestimmte Form bereits geladen ist und bringt sie in den Vordergrung
	Public Function BringFormToFront(ByVal sName As String)

		' alle geöffneten Forms durchlauden
		For Each oForm As Form In Application.OpenForms
			If oForm.Name.ToLower = sName.ToLower Then
				oForm.BringToFront() 'Form in der Vordergrund bringen
				Exit For
			End If
		Next

	End Function

End Class

'Form des Dialog "Lesezeichen"
Public Class Form1
    Inherits System.Windows.Forms.Form

    'Bookmarks Datei festlegen
    Dim sBookmarksDir As String = PathMap.SubstitutePath("$(MD_SCRIPTS)") & "\Bookmarks\"
	Dim sBookmarksFileName As String = sBookmarksDir & SystemInformation.UserName & "_" & GetEplanVersion & ".xml"
	'ToolTip-Objekt
	Dim ToolTip1 As New ToolTip

    'Form definieren
    Private components As System.ComponentModel.IContainer
	Public Sub InitializeComponent()
        Dim icoContextMenu As System.Drawing.Image = System.Drawing.Image.FromFile(PathMap.SubstitutePath("$(MD_SCRIPTS)") & "\Bookmarks\Bookmarks_Icon1.jpg")
		Dim icoListViewItemDown As System.Drawing.Image = System.Drawing.Image.FromFile(PathMap.SubstitutePath("$(MD_SCRIPTS)") & "\Bookmarks\Bookmarks_Icon_Down.png")
		Dim icoListViewItemUp As System.Drawing.Image = System.Drawing.Image.FromFile(PathMap.SubstitutePath("$(MD_SCRIPTS)") & "\Bookmarks\Bookmarks_Icon_Up.png")
        Me.components = New System.ComponentModel.Container()
        Me.ListView = New System.Windows.Forms.ListView()
        Me.Projektname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnContextMenu = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.AktualisierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
   		Me.btnListViewItemDown = New System.Windows.Forms.Button()
		Me.btnListViewItemUp = New System.Windows.Forms.Button()
		Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView
        '
        Me.ListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Projektname})
        Me.ListView.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView.FullRowSelect = True
        Me.ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
		Me.ListView.HideSelection = False
        Me.ListView.Location = New System.Drawing.Point(0, 28)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(192, 384)
        Me.ListView.SmallImageList = Me.ImageList1
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'Projektname
        '
        Me.Projektname.Text = "Projektname"
        Me.Projektname.Width = 176
        '
        'ContextMenuStrip
        '
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem, Me.ÖffnenToolStripMenuItem, Me.ToolStripSeparator1, Me.LöschenToolStripMenuItem, Me.AktualisierenToolStripMenuItem})
        Me.ContextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(201, 120)
        '
        'NeuToolStripMenuItem
        '
        Me.NeuToolStripMenuItem.Name = "NeuToolStripMenuItem"
        Me.NeuToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.NeuToolStripMenuItem.Text = "Lesezeichen hi&nzufügen"
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Projekt &öffnen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.LöschenToolStripMenuItem.Text = "&Lesezeichen löschen"
        '
        'ImageList1
        '
        'Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        'Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        'Me.ImageList1.Images.SetKeyName(0, PathMap.SubstitutePath("$(MD_SCRIPTS)") & "\Bookmarks\Bookmarks_Icon_Prj.jpg")
        '
        'btnContextMenu
        '
        Me.btnContextMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnContextMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContextMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnContextMenu.Image = icoContextMenu
        Me.btnContextMenu.Location = New System.Drawing.Point(170, 2)
        Me.btnContextMenu.Name = "btnContextMenu"
        Me.btnContextMenu.Size = New System.Drawing.Size(19, 19)
        Me.btnContextMenu.TabIndex = 1
		Me.btnContextMenu.TabStop = False
        Me.btnContextMenu.UseVisualStyleBackColor = True
   		'
		'AktualisierenToolStripMenuItem
		'
		Me.AktualisierenToolStripMenuItem.Name = "AktualisierenToolStripMenuItem"
		Me.AktualisierenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
		Me.AktualisierenToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
		Me.AktualisierenToolStripMenuItem.Text = "Aktualisieren"
		'Me.AktualisierenToolStripMenuItem.Visible = False
		'
		'btnListViewItemDown
		'
		Me.btnListViewItemDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnListViewItemDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnListViewItemDown.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.btnListViewItemDown.Image = icoListViewItemDown
		Me.btnListViewItemDown.Location = New System.Drawing.Point(133, 2)
		Me.btnListViewItemDown.Name = "btnListViewItemDown"
		Me.btnListViewItemDown.Size = New System.Drawing.Size(24, 22)
		Me.btnListViewItemDown.TabIndex = 2
		Me.btnListViewItemDown.TabStop = False
		Me.btnListViewItemDown.UseVisualStyleBackColor = True
		'
		'btnListViewItemUp
		'
		Me.btnListViewItemUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnListViewItemUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnListViewItemUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.btnListViewItemUp.Image = icoListViewItemUp
		Me.btnListViewItemUp.Location = New System.Drawing.Point(110, 2)
		Me.btnListViewItemUp.Margin = New System.Windows.Forms.Padding(0)
		Me.btnListViewItemUp.Name = "btnListViewItemUp"
		Me.btnListViewItemUp.Size = New System.Drawing.Size(24, 22)
		Me.btnListViewItemUp.TabIndex = 3
		Me.btnListViewItemUp.TabStop = False
		Me.btnListViewItemUp.UseVisualStyleBackColor = True
		'
        'frmLesezeichen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(192, 411)
		Me.ContextMenuStrip = Me.ContextMenuStrip1
		Me.Controls.Add(Me.btnListViewItemUp)
		Me.Controls.Add(Me.btnListViewItemDown)
		Me.Controls.Add(Me.ListView)
        Me.Controls.Add(Me.btnContextMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(150, 200)
        Me.Name = "frmLesezeichen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lesezeichen"
        Me.TopMost = False
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents Projektname As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnContextMenu As System.Windows.Forms.Button
    Friend WithEvents ÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
	Friend WithEvents AktualisierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents btnListViewItemDown As System.Windows.Forms.Button
	Friend WithEvents btnListViewItemUp As System.Windows.Forms.Button

	
    'Doppelclick: Projekt öffnen
    Private Sub ListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.DoubleClick
		'Projekt öffnen
		ProjektÖffnen()
    End Sub

	'Enter-Taste: Projekt öffnen
    Private Sub ListView_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ListView.KeyUp
        If e.KeyData = Keys.Enter Then
			'Projekt öffnen
			ProjektÖffnen()
        End If
    End Sub
    
	'Maus-Taste gedrückt
	Private Sub ListView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseDown
        ' Bei Rechtsklick, Eintrag selektieren ContextMenü konfigurieren

        ' Rechtsklick!
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Item As ListViewItem
            With ListView
                ' Eintrag ermitteln...
                Item = .GetItemAt(e.Location.X, e.Location.Y)
                If Not Item Is Nothing Then
                    ÖffnenToolStripMenuItem.Enabled = True
                    LöschenToolStripMenuItem.Enabled = True
                Else
                    ÖffnenToolStripMenuItem.Enabled = False
                    LöschenToolStripMenuItem.Enabled = False
                End If
            End With
        End If
	End Sub

	'Maus über Listview = Tooltip anzeigen
	Private Sub ListView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseMove
		Dim sToolTip As String = ""
		' ListItem unter dem Mauszeiger ermitteln
		Dim hInfo As ListViewHitTestInfo = CType(sender, ListView).HitTest(e.Location)
		If Not IsNothing(hInfo.Item) Then
			' 2. Spalte als ToolTip anzeigen
			With hInfo.Item
				sToolTip = .SubItems(1).Text
			End With
		End If
		' ToolTip aktualisieren
		With ToolTip1
			If .GetToolTip(sender) <> sToolTip Then
				.AutoPopDelay = 5000 'Zeit die Tooltip sichtbar bleibt (in Millisekunden)
				.InitialDelay = 1000 'Verzögerung (in Millisekunden)
				.ShowAlways = True	 'Tooltip auch anzeigen wenn Form nicht aktiv ist
				.SetToolTip(sender, sToolTip)
			End If
		End With
	End Sub

	'Größenänderung mitmachen
    Private Sub ListView_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.SizeChanged
        ListView.Columns.Item(0).Width = ListView.Width - 5
    End Sub

    'Form wird geladen
    Private Sub Bookmarks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Position und Größe aus Settings lesen
        Dim oSettings As New Eplan.EplApi.Base.Settings()
		If oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION") Then
			Me.Top = oSettings.GetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", 0)
			Me.Left = oSettings.GetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", 1)
		Else
			Me.Top = 100
			Me.Left = 500
		End If
		If oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE") Then
			Me.Height = oSettings.GetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE", 0)
			Me.Width = oSettings.GetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE", 1)
		Else
			Me.Height = 411
			Me.Width = 192
		End If

        'Icon für projekt in ImageList laden
        Dim icoProject As System.Drawing.Image = System.Drawing.Image.FromFile(PathMap.SubstitutePath("$(MD_SCRIPTS)") & "\Bookmarks\Bookmarks_Icon_Prj.jpg")
        Me.ImageList1.Images.Add(icoProject)

        'Bookmarks einlesen
        BookmarksLesen()

    End Sub

    'Form wird geschlossen
    Private Sub Bookmarks_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'Position und Größe speichern
        Dim oSettings As New Eplan.EplApi.Base.Settings()

		If Not oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION") Then
			oSettings.AddNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", New Integer() {0}, New Range() {New Range() With {.FromValue = 0, .ToValue = 32768}}, "Default value of test setting", New Integer() {0}, ISettings.CreationFlag.Insert)
		End If
		oSettings.SetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", Me.Top, 0)
		oSettings.SetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMLOCATION", Me.Left, 1)

		If Not oSettings.ExistSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE") Then
			oSettings.AddNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE", New Integer() {0}, New Range() {New Range() With {.FromValue = 0, .ToValue = 32768}}, "Default value of test setting", New Integer() {0}, ISettings.CreationFlag.Insert)
		End If
		oSettings.SetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE", Me.Height, 0)
		oSettings.SetNumericSetting("USER.SCRIPTS.BOOKMARKS.FORMSIZE", Me.Width, 1)

        'Speichern auslösen
        BookmarksSpeichern()

    End Sub

	'Kontextmenü 'Projekt öffnen'
    Private Sub ÖffnenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ÖffnenToolStripMenuItem.Click
		'Projekt öffnen
		ProjektÖffnen()
	End Sub

	'Kontextmenü 'Aktualisieren (F5)'
	Private Sub AktualisierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AktualisierenToolStripMenuItem.Click
		'Bookmarks neu einlesen
		BookmarksLesen()
	End Sub

    'Bookmark hinzufügen
    Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
        Dim sProjectname As String
        Dim sProjectpath As String
        Dim objListViewItem As ListViewItem = Nothing
        sProjectname = PathMap.SubstitutePath("$(PROJECTNAME)")
        sProjectpath = PathMap.SubstitutePath("$(PROJECTPATH)").Replace(".edb", ".elk")
        objListViewItem = New ListViewItem
        objListViewItem.Text = sProjectname
        objListViewItem.ImageIndex = 0
        objListViewItem.SubItems.Add(sProjectpath)

        'Eintrag in Listview
        ListView.Items.Add(objListViewItem)

        'Speichern auslösen
        BookmarksSpeichern()
    End Sub

    'Bookmark entfernen
    Private Sub LöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        ListView.SelectedItems(0).Remove()
    End Sub

	'Eintrag eine Position nach oben schieben
	Private Sub btnListViewItemUp_Click(sender As System.Object, e As System.EventArgs) Handles btnListViewItemUp.Click
		lvItem_Up(ListView)
	End Sub

	'Tooltip für Lesezeichen nach oben verschieben
	Private Sub btnListViewItemUp_MouseHover(sender As Object, e As System.EventArgs) Handles btnListViewItemUp.MouseHover
		Dim myToolTip As New ToolTip()
		myToolTip.SetToolTip(btnListViewItemUp, "Lesezeichen nach oben verschieben")
	End Sub

	'Eintrag um eine Position nach unten schieben
	Private Sub btnListViewItemDown_Click(sender As System.Object, e As System.EventArgs) Handles btnListViewItemDown.Click

		lvItem_Down(ListView)
	End Sub

	'Tooltip für Lesezeichen nach unten verschieben
	Private Sub btnListViewItemDown_MouseHover(sender As Object, e As System.EventArgs) Handles btnListViewItemDown.MouseHover
		Dim myToolTip As New ToolTip()
		myToolTip.SetToolTip(btnListViewItemDown, "Lesezeichen nach unten verschieben")
	End Sub

	'Bookmarks speichern
    Private Sub BookmarksSpeichern()
        'Ordner ggf. anlegen
        If Not Directory.Exists(sBookmarksDir) Then
            Directory.CreateDirectory(sBookmarksDir)
        End If
        'XML-Datei schreiben
        XMLWriter(sBookmarksFileName)
    End Sub

    'Bookmarks lesen
    Private Sub BookmarksLesen()
        'Überprüfen ob Datei existiert, wenn nicht dann zurück
        If Not File.Exists(sBookmarksFileName) Then
            Exit Sub
        Else
            'XML-Datei einlesen
            ListView.Items.Clear()
            XMLReader(sBookmarksFileName)
        End If
	End Sub

	'Projekt öffnen
	Private Sub ProjektÖffnen()
		Dim sProjectName As String
		Dim sProjectPath As String
		sProjectName = ListView.SelectedItems(0).Text
		sProjectPath = ListView.SelectedItems(0).SubItems(1).Text

		Dim cmdLineItp As New CommandLineInterpreter()
		Dim ACC As New ActionCallingContext
		ACC.AddParameter("Project", sProjectPath)
		cmdLineItp.Execute("ProjectOpen", ACC)
	End Sub

    'Kontextmenü anzeigen
    Private Sub btnContextMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContextMenu.Click
        If ListView.SelectedItems.Count <> 0 Then
            ÖffnenToolStripMenuItem.Enabled = True
            LöschenToolStripMenuItem.Enabled = True
        Else
            ÖffnenToolStripMenuItem.Enabled = False
            LöschenToolStripMenuItem.Enabled = False
        End If
        ContextMenuStrip1.Show(Control.MousePosition)
    End Sub

	'Eplan Version ermitteln
	Private Function GetEplanVersion()
		Dim sBINPath As String = PathMap.SubstitutePath("$(BIN)")
		Dim Info As FileVersionInfo

		'Überprüfen ob EPLAN.exe existiert, sonst W3U.exe benutzen
		If File.Exists(sBINPath & "\EPLAN.exe") Then
			Info = FileVersionInfo.GetVersionInfo(sBINPath & "\EPLAN.exe") 'neu ab Eplan V2.1
		ElseIf File.Exists(sBINPath & "\W3U.exe") Then
			Info = FileVersionInfo.GetVersionInfo(sBINPath & "\W3U.exe") 'veraltet bis Eplan V2.0
		Else
			MessageBox.Show("Fehler!, Eplan Version konnte nicht ermittelt werden.")
		End If

		Return Info.ProductMajorPart & "." & Info.ProductMinorPart & "." & Info.ProductBuildPart
	End Function

    'XML Datei einlesen
    Private Sub XMLReader(ByVal sFileName As String)
        Dim objListViewItem As ListViewItem = Nothing

        ' Wir benötigen einen XmlReader für das Auslesen der XML-Datei 
        Dim XMLReader As Xml.XmlReader = New Xml.XmlTextReader(sFileName)

        ' Es folgt das Auslesen der XML-Datei 
        With XMLReader
            Do While .Read ' Es sind noch Daten vorhanden 
                ' Welche Art von Daten liegt an? 
                Select Case .NodeType
                    ' Ein Element 
                    Case Xml.XmlNodeType.Element
                        'wenn Lesezeichen
                        If .Name = "Lesezeichen" Then
							' Alle Attribute (Name-Wert-Paare) abarbeiten 
                            If .AttributeCount > 0 Then
                                ' Es sind noch weitere Attribute vorhanden 
                                objListViewItem = New ListViewItem
                                While .MoveToNextAttribute ' nächstes 
                                    If .Name = "Projektname" Then
                                        objListViewItem.Text = .Value
                                        objListViewItem.ImageIndex = 0
                                    End If
                                    If .Name = "Projektpfad" Then
										objListViewItem.SubItems.Add(.Value)
										'Prüfen ob Datei vorhanden, sonst ausgrauen
										If Not File.Exists(.Value) Then objListViewItem.ForeColor = System.Drawing.Color.Gray
										'End If
									End If
                                End While
                                'Eintrag in Listview
                                ListView.Items.Add(objListViewItem)
                            End If
                        End If
                        ' Ein Text 
                    Case Xml.XmlNodeType.Text
                        MessageBox.Show("Es folgt ein Text: " & .Value)
                        ' Ein Kommentar 
                    Case Xml.XmlNodeType.Comment
                        MessageBox.Show("Es folgt ein Kommentar: " & .Value)
                End Select
            Loop  ' Weiter nach Daten schauen 
            .Close()  ' XMLTextReader schließen 
        End With

    End Sub

    'XML Datei schreiben
    Private Sub XMLWriter(ByVal sFileName As String)
        ' Auswahl einer Kodierungsart für die Zeichenablage 
        Dim enc As New System.Text.UnicodeEncoding
        ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
        Dim XMLobj As Xml.XmlTextWriter = New Xml.XmlTextWriter(sFileName, enc)

        With XMLobj
            ' Formatierung: 4er-Einzüge verwenden 
            .Formatting = Xml.Formatting.Indented
            .Indentation = 4
            ' Dann fangen wir mal an: 
            .WriteStartDocument()
            ' Beginn eines Elements "LesezeichenListe". Darin werden wir mehrere 
            ' Elemente "Lesezeichen" unterbringen. 
            .WriteStartElement("LesezeichenListe")
            'Listview abarbeiten
            For Each lvi As ListViewItem In ListView.Items
				' Hier kommt das erste Element "Lesezeichen". Ein Lesezeichen hat einen Eintragtext und einen Odnernamen. 
                .WriteStartElement("Lesezeichen") ' <Lesezeichen
                .WriteAttributeString("Projektname", lvi.Text)
                .WriteAttributeString("Projektpfad", lvi.SubItems(1).Text)
                .WriteEndElement() ' Lesezeichen /> 
            Next
            ' Nachdem das Element "LesezeichenListe" zwei Elemente "Lesezeichen" 
            ' erhalten hat, beenden wir die Ausgabe für "LesezeichenListe"... 
            .WriteEndElement() ' </Lesezeichen> 
            ' ... und schließen das XML-Dokument (und die Datei) 
            .Close() ' Document 
        End With
    End Sub

	'Verschiebt den aktuell selektierten Eintrag um eine Position nach oben
	Public Function lvItem_Up(ByVal sender As ListView) As Boolean
		With sender
			If .SelectedItems.Count = 1 Then
				' aktuellen Eintrag und Position merken
				Dim oItem As ListViewItem = .SelectedItems(0)
				Dim index = oItem.Index
				If index > 0 Then
					' jetzt den markierten Eintrag löschen
					.SelectedItems(0).Remove()

					' und den "gemerkten" Eintrag eine Position weiter oben einfügen
					.Items.Insert(index - 1, oItem)

					' Eintrag wieder selektieren
					oItem.Selected = True
					oItem.EnsureVisible()
					oItem.Focused = True

					Return True
				End If
			End If
		End With
	End Function

	'Verschiebt den aktuell selektierten Eintrag um eine Position nach unten
	Public Function lvItem_Down(ByVal sender As ListView) As Boolean
		With sender
			If .SelectedItems.Count = 1 Then
				' aktuellen Eintrag und Position merken
				Dim oItem As ListViewItem = .SelectedItems(0)
				Dim index = oItem.Index
				If index < .Items.Count - 1 Then
					' jetzt den markierten Eintrag löschen
					.SelectedItems(0).Remove()

					' und den "gemerkten" Eintrag eine Position weiter oben einfügen
					.Items.Insert(index + 1, oItem)

					' Eintrag wieder selektieren
					oItem.Selected = True
					oItem.EnsureVisible()
					oItem.Focused = True

					Return True
				End If
			End If
		End With
	End Function
	
End Class
