// InsertComment, Version 1.2.0, vom 16.04.2013
//
// Erweitert Eplan Electric P8 um die Möglichkeit Kommentare einzufügen,
// diese können dann mit dem Kommentare-Navigator verwaltet werden.
//
// Copyright by Frank Schöneck, 2013
// letzte Änderung: Frank Schöneck, 28.02.2013 V1.0.0, Projektbeginn
//					Frank Schöneck, 01.03.2013 V1.1.0, Ebene, Linientyp und Musterlänge als Variable eingesetzt
//					Frank Schöneck, 16.04.2013 V1.2.0, Neuer Reiter "Einstellungen" mit der Möglichkeit zum gruppieren,
//                                                     Name geändert von "InsertPDFComment" in "InsertComment"
//
// für Eplan Electric P8, ab V2.2
//
using System.Windows.Forms;
using Eplan.EplApi.Scripting;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using System;
using System.Xml;

public partial class frmInsertKommentar : System.Windows.Forms.Form
{
	private Button btnOK;
	private Button btnAbbrechen;
	private TabControl tabControl1;
	private Label label1;
	private Label label2;
	private TextBox txtVerfasser;
	private TextBox txtKommentartext;
	private Label label4;
	private TabPage tabKommentar;
	private DateTimePicker dTPErstellungsdatum;
	private ComboBox cBStatus;
	private Label label3;
	private TabPage tabEinstellungen;
	private CheckBox chkKommentartextGruppieren;

	#region Vom Windows Form-Designer generierter Code

	/// <summary>
	/// Erforderliche Designervariable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Verwendete Ressourcen bereinigen.
	/// </summary>
	/// <param name="disposing">True, wenn verwaltete Ressourcen
	/// gelöscht werden sollen; andernfalls False.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// Erforderliche Methode für die Designerunterstützung.
	/// Der Inhalt der Methode darf nicht mit dem Code-Editor
	/// geändert werden.
	/// </summary>
	private void InitializeComponent()
	{
		this.btnOK = new System.Windows.Forms.Button();
		this.btnAbbrechen = new System.Windows.Forms.Button();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabKommentar = new System.Windows.Forms.TabPage();
		this.cBStatus = new System.Windows.Forms.ComboBox();
		this.dTPErstellungsdatum = new System.Windows.Forms.DateTimePicker();
		this.txtKommentartext = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.txtVerfasser = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.tabEinstellungen = new System.Windows.Forms.TabPage();
		this.chkKommentartextGruppieren = new System.Windows.Forms.CheckBox();
		this.tabControl1.SuspendLayout();
		this.tabKommentar.SuspendLayout();
		this.tabEinstellungen.SuspendLayout();
		this.SuspendLayout();
		// 
		// btnOK
		// 
		this.btnOK.Location = new System.Drawing.Point(199, 382);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(110, 25);
		this.btnOK.TabIndex = 0;
		this.btnOK.Text = "OK";
		this.btnOK.UseVisualStyleBackColor = true;
		this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
		// 
		// btnAbbrechen
		// 
		this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnAbbrechen.Location = new System.Drawing.Point(328, 382);
		this.btnAbbrechen.Name = "btnAbbrechen";
		this.btnAbbrechen.Size = new System.Drawing.Size(110, 25);
		this.btnAbbrechen.TabIndex = 1;
		this.btnAbbrechen.Text = "Abbrechen";
		this.btnAbbrechen.UseVisualStyleBackColor = true;
		this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
		// 
		// tabControl1
		// 
		this.tabControl1.Controls.Add(this.tabKommentar);
		this.tabControl1.Controls.Add(this.tabEinstellungen);
		this.tabControl1.Location = new System.Drawing.Point(12, 12);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(426, 357);
		this.tabControl1.TabIndex = 2;
		this.tabControl1.TabStop = false;
		// 
		// tabKommentar
		// 
		this.tabKommentar.BackColor = System.Drawing.Color.Transparent;
		this.tabKommentar.Controls.Add(this.cBStatus);
		this.tabKommentar.Controls.Add(this.dTPErstellungsdatum);
		this.tabKommentar.Controls.Add(this.txtKommentartext);
		this.tabKommentar.Controls.Add(this.label4);
		this.tabKommentar.Controls.Add(this.label3);
		this.tabKommentar.Controls.Add(this.label2);
		this.tabKommentar.Controls.Add(this.txtVerfasser);
		this.tabKommentar.Controls.Add(this.label1);
		this.tabKommentar.Location = new System.Drawing.Point(4, 22);
		this.tabKommentar.Name = "tabKommentar";
		this.tabKommentar.Padding = new System.Windows.Forms.Padding(3);
		this.tabKommentar.Size = new System.Drawing.Size(418, 331);
		this.tabKommentar.TabIndex = 0;
		this.tabKommentar.Text = "Kommentar";
		// 
		// cBStatus
		// 
		this.cBStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cBStatus.Items.AddRange(new object[] {
            "kein Status",
            "Akzeptiert",
            "Abgelehnt",
            "Abgebrochen",
            "Beendet"});
		this.cBStatus.Location = new System.Drawing.Point(201, 94);
		this.cBStatus.MaxDropDownItems = 5;
		this.cBStatus.Name = "cBStatus";
		this.cBStatus.Size = new System.Drawing.Size(211, 21);
		this.cBStatus.TabIndex = 2;
		// 
		// dTPErstellungsdatum
		// 
		this.dTPErstellungsdatum.CustomFormat = "dd.MM.yyyy HH:mm:ss";
		this.dTPErstellungsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dTPErstellungsdatum.Location = new System.Drawing.Point(9, 94);
		this.dTPErstellungsdatum.Name = "dTPErstellungsdatum";
		this.dTPErstellungsdatum.ShowUpDown = true;
		this.dTPErstellungsdatum.Size = new System.Drawing.Size(155, 20);
		this.dTPErstellungsdatum.TabIndex = 1;
		// 
		// txtKommentartext
		// 
		this.txtKommentartext.Location = new System.Drawing.Point(6, 145);
		this.txtKommentartext.Multiline = true;
		this.txtKommentartext.Name = "txtKommentartext";
		this.txtKommentartext.Size = new System.Drawing.Size(406, 175);
		this.txtKommentartext.TabIndex = 3;
		// 
		// label4
		// 
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(6, 129);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(80, 13);
		this.label4.TabIndex = 6;
		this.label4.Text = "Kommentartext:";
		// 
		// label3
		// 
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(198, 78);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(40, 13);
		this.label3.TabIndex = 2;
		this.label3.Text = "Status:";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 78);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(90, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Erstellungsdatum:";
		// 
		// txtVerfasser
		// 
		this.txtVerfasser.Location = new System.Drawing.Point(6, 44);
		this.txtVerfasser.Name = "txtVerfasser";
		this.txtVerfasser.Size = new System.Drawing.Size(406, 20);
		this.txtVerfasser.TabIndex = 0;
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 28);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(54, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Verfasser:";
		// 
		// tabEinstellungen
		// 
		this.tabEinstellungen.BackColor = System.Drawing.Color.Transparent;
		this.tabEinstellungen.Controls.Add(this.chkKommentartextGruppieren);
		this.tabEinstellungen.Location = new System.Drawing.Point(4, 22);
		this.tabEinstellungen.Name = "tabEinstellungen";
		this.tabEinstellungen.Padding = new System.Windows.Forms.Padding(3);
		this.tabEinstellungen.Size = new System.Drawing.Size(418, 331);
		this.tabEinstellungen.TabIndex = 1;
		this.tabEinstellungen.Text = "Einstellungen";
		// 
		// chkKommentartextGruppieren
		// 
		this.chkKommentartextGruppieren.AutoSize = true;
		this.chkKommentartextGruppieren.Checked = true;
		this.chkKommentartextGruppieren.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkKommentartextGruppieren.Location = new System.Drawing.Point(23, 35);
		this.chkKommentartextGruppieren.Name = "chkKommentartextGruppieren";
		this.chkKommentartextGruppieren.Size = new System.Drawing.Size(246, 17);
		this.chkKommentartextGruppieren.TabIndex = 0;
		this.chkKommentartextGruppieren.Text = "Symbol und Kommentartext gruppiert platzieren";
		this.chkKommentartextGruppieren.UseVisualStyleBackColor = true;
		// 
		// frmInsertKommentar
		// 
		this.AcceptButton = this.btnOK;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.btnAbbrechen;
		this.ClientSize = new System.Drawing.Size(450, 419);
		this.Controls.Add(this.tabControl1);
		this.Controls.Add(this.btnAbbrechen);
		this.Controls.Add(this.btnOK);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmInsertKommentar";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "InsertComment";
		this.Load += new System.EventHandler(this.frmInsertKommentar_Load);
		this.tabControl1.ResumeLayout(false);
		this.tabKommentar.ResumeLayout(false);
		this.tabKommentar.PerformLayout();
		this.tabEinstellungen.ResumeLayout(false);
		this.tabEinstellungen.PerformLayout();
		this.ResumeLayout(false);

	}

	public frmInsertKommentar()
	{
		InitializeComponent();
	}

	#endregion

	//Menüpunkt anlegen
	[DeclareMenu()]
	public void Comment_Menu()
	{
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("Kommentar einfügen", "DialogInsertComment", "Kommentar einfügen wird ausgeführt", 35381, 0, false, false);
	}

	//Action um die Form aufzurufen
	[DeclareAction("DialogInsertComment")]
	public void DialogInsertComment_action()
	{
		frmInsertKommentar frm = new frmInsertKommentar();
		frm.ShowDialog();
		return;
	}

	//Form_Load
	private void frmInsertKommentar_Load(object sender, System.EventArgs e)
	{
		Text = "Einfügen";

		//Verfasser voreinstellen
#if DEBUG
		txtVerfasser.Text = "FrankS";
#else

		UserRights oUserRights = new UserRights();
		txtVerfasser.Text = oUserRights.GetUser();
#endif
		//Status voreinstellen
		cBStatus.Text = "kein Status";

		//Eingabe auf Kommentartext stellen
		txtKommentartext.Select();
	}

	//Button Abbrechen Click
	private void btnAbbrechen_Click(object sender, System.EventArgs e)
	{
		Close();
	}

	//Button OK Click
	private void btnOK_Click(object sender, System.EventArgs e)
	{
		//Ebene des Kommentar (A411 = 519(EPLAN519, Grafik.Kommentare))
		string sEbene = "519";

		//Linientyp des Kommentar (A412 = L(Layer) / 0(durchgezogen) / 41(~~~~~))
		string sLinientyp = "41";

		//Musterlänge des Kommentar (A415 = L(Layer) / -1.5(1,50 mm) / -32(32,00 mm))
		string sMusterlänge = "-1.5";

		//Farbe des Kommentar (A413 = 0(schwarz) / 1(rot) / 2(gelb) / 3(hellgrün) / 4(hellblau) / 5(dunkelblau) / 6(violett) / 8(weiss) / 40(orange))
		string sFarbe = "40";

		//Verfasser (A2521)
		string sVerfasser = txtVerfasser.Text;

		//Erstellungsdatum (A2524)
		string sErstellungsdatum = DateTimeToUnixTimestamp(dTPErstellungsdatum.Value).ToString(); // DateTime Wert nach Unix Timestamp Format wandeln

		//Kommentartext (A511)
		string sKommentartext = txtKommentartext.Text;
		if (sKommentartext.EndsWith(Environment.NewLine)) //Kommentar darf nicht mit Zeilenumbruch enden
		{ sKommentartext = sKommentartext.Substring(0, sKommentartext.Length - 2); }
		sKommentartext = sKommentartext.Replace(Environment.NewLine, "&#10;"); //Kommentar Zeilenumbruch umwandeln
		sKommentartext = "??_??@" + sKommentartext; //Kommentar MultiLanguage String
		if (!sKommentartext.EndsWith(";")) //Kommentar muss mit ";" enden
		{ sKommentartext += ";"; }

		//Status, (A2527 = 0(kein Status) / 1(Akzeptiert) / 2(Abgelehnt) / 3(Abgebrochen) / 4(Beendet))
		string sStatus = cBStatus.SelectedIndex.ToString();

		//Pfad und Dateiname der Temp.datei
		string sTempFile;
#if DEBUG
		sTempFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\tmpInsertComment.ema";
#else
		sTempFile = PathMap.SubstitutePath(@"$(TMP)") + @"\tmpInsertComment.ema";
#endif
		XmlWriterSettings settings = new XmlWriterSettings();
		settings.Indent = true;
		XmlWriter writer = XmlWriter.Create(sTempFile, settings);

		//Makrodatei Inhalt
		writer.WriteRaw("\n<EplanPxfRoot Name=\"#Kommentar\" Type=\"WindowMacro\" Version=\"2.2.6360\" PxfVersion=\"1.23\" SchemaVersion=\"1.7.6360\" Source=\"\" SourceProject=\"\" Description=\"\" ConfigurationFlags=\"0\" NumMainObjects=\"0\" NumProjectSteps=\"0\" NumMDSteps=\"0\" Custompagescaleused=\"true\" StreamSchema=\"EBitmap,BaseTypes,2,1,2;EPosition3D,BaseTypes,0,3,2;ERay3D,BaseTypes,0,4,2;EStreamableVector,BaseTypes,0,5,2;DMNCDataSet,TrDMProject,1,20,2;DMNCDataSetVector,TrDMProject,1,21,2;DMPlaceHolderRuleData,TrDMProject,0,22,2;Arc3d@W3D,W3dBaseGeometry,0,36,2;Box3d@W3D,W3dBaseGeometry,0,37,2;Circle3d@W3D,W3dBaseGeometry,0,38,2;Color@W3D,W3dBaseGeometry,0,39,2;ContourPlane3d@W3D,W3dBaseGeometry,0,40,2;CTexture@W3D,W3dBaseGeometry,0,41,2;CTextureMap@W3D,W3dBaseGeometry,0,42,2;Line3d@W3D,W3dBaseGeometry,0,43,2;Linetype@W3D,W3dBaseGeometry,0,44,2;Material@W3D,W3dBaseGeometry,3,45,2;Path3d@W3D,W3dBaseGeometry,0,46,2;Mesh3dX@W3D,W3dMeshModeller,2,47,2;MeshBox@W3D,W3dMeshModeller,5,48,2;MeshMate@W3D,W3dMeshModeller,7,49,2;MeshMateFace@W3D,W3dMeshModeller,1,50,2;MeshMateGrid@W3D,W3dMeshModeller,8,51,2;MeshMateGridLine@W3D,W3dMeshModeller,1,52,2;MeshMateLine@W3D,W3dMeshModeller,1,53,2;MeshText3dX@W3D,W3dMeshModeller,0,55,2;BaseTextLine@W3D,W3dMeshModeller,2,56,2;Mesh3d@W3D,W3dMeshModeller,8,57,2;MeshEdge3d@W3D,W3dMeshModeller,0,58,2;MeshFace3d@W3D,W3dMeshModeller,2,59,2;MeshPoint3d@W3D,W3dMeshModeller,1,60,2;MeshPolygon3d@W3D,W3dMeshModeller,1,61,2;MeshSimpleTextureTriangle3d@W3D,W3dMeshModeller,2,62,2;MeshSimpleTriangle3d@W3D,W3dMeshModeller,1,63,2;MeshTriangle3d@W3D,W3dMeshModeller,2,64,2;MeshTriangleFace3d@W3D,W3dMeshModeller,0,65,2;MeshTriangleFaceEdge3D@W3D,W3dMeshModeller,0,66,2\">");
		writer.WriteRaw("\n <MacroVariant MacroFuncType=\"1\" VariantId=\"0\" ReferencePoint=\"64/248/0\" Version=\"2.2.6360\" PxfVersion=\"1.23\" SchemaVersion=\"1.7.6360\" Source=\"\" SourceProject=\"\" Description=\"\" ConfigurationFlags=\"0\" DocumentType=\"1\" Customgost=\"0\">");
		writer.WriteRaw("\n  <O4 Build=\"6360\" A1=\"4/18\" A3=\"0\" A13=\"0\" A14=\"0\" A47=\"1\" A48=\"1362057551\" A50=\"1\" A59=\"1\" A404=\"1\" A405=\"64\" A406=\"0\" A407=\"0\" A431=\"1\" A1101=\"17\" A1102=\"\" A1103=\"\">");

		//wenn gruppiert sein soll
		if (chkKommentartextGruppieren.Checked == true)
		{
			writer.WriteRaw("\n  <O26 Build=\"6360\" A1=\"26/128740\" A3=\"0\" A13=\"0\" A14=\"0\" A404=\"1\" A405=\"64\" A406=\"0\" A407=\"0\" A431=\"1\">");
		}
		//Eigenschaften Kommentar
		writer.WriteRaw("\n  <O165 Build=\"6360\" A1=\"165/128741\" A3=\"0\" A13=\"0\" A14=\"0\" A404=\"1\" A405=\"64\" A406=\"0\" A407=\"0\" A411=\"" + sEbene + "\" A412=\"" + sLinientyp + "\" A413=\"" + sFarbe + "\" A414=\"0.352777238812552\" A415=\"" + sMusterlänge + "\" A416=\"0\" A501=\"64/248\" A503=\"0\" A504=\"0\" A506=\"22\" A511=\"" + sKommentartext + "\" A2521=\"" + sVerfasser + "\" A2522=\"\" A2523=\"\" A2524=\"" + sErstellungsdatum + "\" A2525=\"" + sErstellungsdatum + "\" A2526=\"2\" A2527=\"" + sStatus + "\" A2528=\"0\" A2529=\"0\" A2531=\"0\" A2532=\"0\" A2533=\"64/248;70.349110320284/254.349110320285\" A2534=\"2\" A2539=\"0\" A2540=\"0\">");
		writer.WriteRaw("\n  <S54x505 A961=\"L\" A962=\"L\" A963=\"0\" A964=\"L\" A965=\"0\" A966=\"0\" A967=\"0\" A968=\"0\" A969=\"0\" A4000=\"L\" A4001=\"L\" A4013=\"0\"/>");
		writer.WriteRaw("\n  </O165>");

		//Eigenschaften Text
		writer.WriteRaw("\n  <O30 Build=\"6360\" A1=\"30/128742\" A3=\"0\" A13=\"0\" A14=\"0\" A404=\"1\" A405=\"64\" A406=\"0\" A407=\"0\" A411=\"" + sEbene + "\" A412=\"L\" A413=\"L\" A414=\"L\" A415=\"L\" A416=\"0\" A501=\"72/248\" A503=\"0\" A504=\"0\" A506=\"0\" A511=\"" + sKommentartext + "\">");
		writer.WriteRaw("\n  <S54x505 A961=\"L\" A962=\"L\" A963=\"0\" A964=\"L\" A965=\"0\" A966=\"0\" A967=\"0\" A968=\"0\" A969=\"0\" A4000=\"L\" A4001=\"L\" A4013=\"0\"/>");
		writer.WriteRaw("\n  </O30>");

		//wenn gruppiert sein soll
		if (chkKommentartextGruppieren.Checked == true)
		{
			writer.WriteRaw("\n  </O26>");
		}
		writer.WriteRaw("\n  <O37 Build=\"6360\" A1=\"37/128743\" A3=\"1\" A13=\"0\" A14=\"0\" A404=\"1\" A405=\"64\" A406=\"0\" A407=\"0\" A682=\"1\" A683=\"26/128740\" A684=\"0\" A687=\"8\" A688=\"2\" A689=\"-1\" A690=\"-1\" A691=\"0\" A693=\"1\" A792=\"0\" A793=\"0\" A794=\"0\" A1261=\"0\" A1262=\"44\" A1263=\"0\" A1631=\"0/-6.34911032028501\" A1632=\"8/0\">");
		writer.WriteRaw("\n  <S109x692 Build=\"6360\" A3=\"0\" A13=\"0\" A14=\"0\" R1906=\"165/128741\"/>");
		writer.WriteRaw("\n  <S109x692 Build=\"6360\" A3=\"0\" A13=\"0\" A14=\"0\" R1906=\"30/128742\"/>");
		writer.WriteRaw("\n  <S40x1201 A762=\"64/254.349110320285\">");
		writer.WriteRaw("\n  <S39x761 A751=\"1\" A752=\"0\" A753=\"0\" A754=\"1\"/>");
		writer.WriteRaw("\n  </S40x1201>");
		writer.WriteRaw("\n  <S89x5 Build=\"6360\" A3=\"0\" A4=\"1\" R7=\"37/128743\" A13=\"0\" A14=\"0\" A404=\"9\" A405=\"64\" A406=\"0\" A407=\"0\" A411=\"308\" A412=\"L\" A413=\"L\" A414=\"L\" A415=\"L\" A416=\"0\" A1651=\"0/-6.34911032028501\" A1652=\"8/0\" A1653=\"0\" A1654=\"0\" A1655=\"0\" A1656=\"0\" A1657=\"0\"/>");
		writer.WriteRaw("\n  </O37>");
		writer.WriteRaw("\n  </O4>");
		writer.WriteRaw("\n </MacroVariant>");
		writer.WriteRaw("\n</EplanPxfRoot>");

		// Write the XML to file and close the writer.
		writer.Flush();
		writer.Close();

		//Makro einfügen
#if DEBUG
		MessageBox.Show(sTempFile);
#else
		CommandLineInterpreter oCli = new CommandLineInterpreter();
		ActionCallingContext oAcc = new ActionCallingContext();
		oAcc.AddParameter("Name", "XMIaInsertMacro");
		oAcc.AddParameter("filename", sTempFile);
		oAcc.AddParameter("variant", "0");
		oCli.Execute("XGedStartInteractionAction", oAcc);
#endif

		//Beenden
		Close();
		return;
	}

	/// <summary>
	/// Methods to convert Unix time stamp to DateTime
	/// </summary>
	/// <param name="_UnixTimeStamp">Unix time stamp to convert</param>
	/// <returns>Return DateTime</returns>
	///
	/// Beispiel:
	/// convert given Unix time stamp to DateTime and update dateTimePicker value
	///	dateTimePicker1.Value = UnixTimestampToDateTime(181913235);
	public DateTime UnixTimestampToDateTime(long _UnixTimeStamp)
	{
		return (new DateTime(1970, 1, 1, 1, 0, 0)).AddSeconds(_UnixTimeStamp);

	}

	/// <summary>
	/// Methods to convert DateTime to Unix time stamp
	/// </summary>
	/// <param name="_UnixTimeStamp">Unix time stamp to convert</param>
	/// <returns>Return Unix time stamp as long type</returns>
	/// 
	/// Beispiel:
	/// Convert current DateTime in Unix time stamp
	///	Console.WriteLine("Current unix time stamp is : " + DateTimeToUnixTimestamp(DateTime.Now).ToString());
	public long DateTimeToUnixTimestamp(DateTime _DateTime)
	{
		TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 1, 0, 0));
		return (long)_UnixTimeSpan.TotalSeconds;
	}

}