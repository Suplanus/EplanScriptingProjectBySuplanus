// PDF-Export Assistent, Version 1.0.0, vom 07.02.2014
//
// Integriert einen Dialog um automatisiert PDF-Dateien in definierte Ordner abzulegen.
// Der Aufruf erfolgt entweder über Menüpunkt (unter Seite > Export > PDF (Assistent)...)
// oder automatisch beim Schließen oder Beenden.
//
// Der Ursprung für diesen Assistenten war das Skript "PDFbyProjectClose"
//
// Copyright by Frank Schöneck, 2014
// letzte Änderung: Frank Schöneck, 27.01.2014 V1.0.0, Projektbeginn
//
// für Eplan Electric P8, ab V2.2
//

using System;
using System.Windows.Forms;
using System.Xml;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public partial class frmPDFAssistent : System.Windows.Forms.Form
{
	private Button btnAbbrechen;
	private Button btnOK;
	private CheckBox chkEinstellungSpeichern;
	private TabControl tabControl1;
	private TabPage tabPage1;
	private Button btnOrdnerAuswahl;
	private TextBox txtSpeicherort;
	private TextBox txtDateiname;
	private CheckBox chkDatumStempel;
	private CheckBox chkZeitStempel;
	private ComboBox cboAusgabeNach;
	private Label label3;
	private Label label2;
	private Label label1;
	private TabPage tabPage2;
	private GroupBox groupBox1;
	private CheckBox chkByEplanEnd;
	private CheckBox chkByProjectClose;
	private Label label4;
	private CheckBox chkOhneNachfrage;
	private Button btnSpeichern;
	private Button button1;
	private GroupBox groupBox2;
	private Button btnProjektOrdnerAuswahl;
	private TextBox txtProjektGespeichertInOrdner;
	private CheckBox chkIstInProjektOrdner;

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
			this.btnAbbrechen = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.chkEinstellungSpeichern = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnOrdnerAuswahl = new System.Windows.Forms.Button();
			this.txtSpeicherort = new System.Windows.Forms.TextBox();
			this.txtDateiname = new System.Windows.Forms.TextBox();
			this.chkDatumStempel = new System.Windows.Forms.CheckBox();
			this.chkZeitStempel = new System.Windows.Forms.CheckBox();
			this.cboAusgabeNach = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnProjektOrdnerAuswahl = new System.Windows.Forms.Button();
			this.txtProjektGespeichertInOrdner = new System.Windows.Forms.TextBox();
			this.chkIstInProjektOrdner = new System.Windows.Forms.CheckBox();
			this.chkOhneNachfrage = new System.Windows.Forms.CheckBox();
			this.btnSpeichern = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkByEplanEnd = new System.Windows.Forms.CheckBox();
			this.chkByProjectClose = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAbbrechen
			// 
			this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAbbrechen.Location = new System.Drawing.Point(408, 273);
			this.btnAbbrechen.Name = "btnAbbrechen";
			this.btnAbbrechen.Size = new System.Drawing.Size(95, 24);
			this.btnAbbrechen.TabIndex = 0;
			this.btnAbbrechen.Text = "Abbrechen";
			this.btnAbbrechen.UseVisualStyleBackColor = true;
			this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(298, 273);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(95, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// chkEinstellungSpeichern
			// 
			this.chkEinstellungSpeichern.AutoSize = true;
			this.chkEinstellungSpeichern.Location = new System.Drawing.Point(9, 278);
			this.chkEinstellungSpeichern.Name = "chkEinstellungSpeichern";
			this.chkEinstellungSpeichern.Size = new System.Drawing.Size(138, 17);
			this.chkEinstellungSpeichern.TabIndex = 3;
			this.chkEinstellungSpeichern.Text = "Einstellungen speichern";
			this.chkEinstellungSpeichern.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(9, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(498, 235);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Transparent;
			this.tabPage1.Controls.Add(this.btnOrdnerAuswahl);
			this.tabPage1.Controls.Add(this.txtSpeicherort);
			this.tabPage1.Controls.Add(this.txtDateiname);
			this.tabPage1.Controls.Add(this.chkDatumStempel);
			this.tabPage1.Controls.Add(this.chkZeitStempel);
			this.tabPage1.Controls.Add(this.cboAusgabeNach);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(490, 209);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Ausgabe";
			// 
			// btnOrdnerAuswahl
			// 
			this.btnOrdnerAuswahl.Location = new System.Drawing.Point(444, 148);
			this.btnOrdnerAuswahl.Name = "btnOrdnerAuswahl";
			this.btnOrdnerAuswahl.Size = new System.Drawing.Size(28, 20);
			this.btnOrdnerAuswahl.TabIndex = 15;
			this.btnOrdnerAuswahl.Text = "...";
			this.btnOrdnerAuswahl.UseVisualStyleBackColor = true;
			this.btnOrdnerAuswahl.Click += new System.EventHandler(this.btnOrdnerAuswahl_Click);
			// 
			// txtSpeicherort
			// 
			this.txtSpeicherort.Location = new System.Drawing.Point(14, 149);
			this.txtSpeicherort.Name = "txtSpeicherort";
			this.txtSpeicherort.ReadOnly = true;
			this.txtSpeicherort.Size = new System.Drawing.Size(424, 20);
			this.txtSpeicherort.TabIndex = 13;
			// 
			// txtDateiname
			// 
			this.txtDateiname.Location = new System.Drawing.Point(14, 110);
			this.txtDateiname.Name = "txtDateiname";
			this.txtDateiname.Size = new System.Drawing.Size(458, 20);
			this.txtDateiname.TabIndex = 14;
			// 
			// chkDatumStempel
			// 
			this.chkDatumStempel.AutoSize = true;
			this.chkDatumStempel.Location = new System.Drawing.Point(174, 54);
			this.chkDatumStempel.Name = "chkDatumStempel";
			this.chkDatumStempel.Size = new System.Drawing.Size(98, 17);
			this.chkDatumStempel.TabIndex = 12;
			this.chkDatumStempel.Text = "Datum-Stempel";
			this.chkDatumStempel.UseVisualStyleBackColor = true;
			this.chkDatumStempel.CheckedChanged += new System.EventHandler(this.chkDatumStempel_CheckedChanged);
			// 
			// chkZeitStempel
			// 
			this.chkZeitStempel.AutoSize = true;
			this.chkZeitStempel.Location = new System.Drawing.Point(278, 54);
			this.chkZeitStempel.Name = "chkZeitStempel";
			this.chkZeitStempel.Size = new System.Drawing.Size(85, 17);
			this.chkZeitStempel.TabIndex = 11;
			this.chkZeitStempel.Text = "Zeit-Stempel";
			this.chkZeitStempel.UseVisualStyleBackColor = true;
			this.chkZeitStempel.CheckedChanged += new System.EventHandler(this.chkZeitStempel_CheckedChanged);
			// 
			// cboAusgabeNach
			// 
			this.cboAusgabeNach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAusgabeNach.Items.AddRange(new object[] {
			"in den Projekt-Ordner",
			"Ausgabeverzeichnis aus Einstellungen: PDF-Export",
			"in den Ordner eine Ebene über dem Projekt-Ordner",
			"in Ordner \"Eigene Dateien\"",
			"auf den Desktop",
			"gleicher Pfad wie Projekt nur auf anderes Laufwerk"});
			this.cboAusgabeNach.Location = new System.Drawing.Point(96, 17);
			this.cboAusgabeNach.Name = "cboAusgabeNach";
			this.cboAusgabeNach.Size = new System.Drawing.Size(376, 21);
			this.cboAusgabeNach.TabIndex = 10;
			this.cboAusgabeNach.SelectedIndexChanged += new System.EventHandler(this.cboAusgabeNach_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(148, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "PDF-Dateiname erweitern um:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(204, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "PDF-Dateiname (ohne Erweiterung (.pdf)):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Speicherort:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Ausgabe nach:";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.Transparent;
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.btnSpeichern);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(490, 209);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Einstellungen";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnProjektOrdnerAuswahl);
			this.groupBox2.Controls.Add(this.txtProjektGespeichertInOrdner);
			this.groupBox2.Controls.Add(this.chkIstInProjektOrdner);
			this.groupBox2.Controls.Add(this.chkOhneNachfrage);
			this.groupBox2.Location = new System.Drawing.Point(6, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(478, 77);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "und zusätzliche Bedingungen erfüllt sind";
			// 
			// btnProjektOrdnerAuswahl
			// 
			this.btnProjektOrdnerAuswahl.Location = new System.Drawing.Point(442, 17);
			this.btnProjektOrdnerAuswahl.Name = "btnProjektOrdnerAuswahl";
			this.btnProjektOrdnerAuswahl.Size = new System.Drawing.Size(28, 20);
			this.btnProjektOrdnerAuswahl.TabIndex = 16;
			this.btnProjektOrdnerAuswahl.Text = "...";
			this.btnProjektOrdnerAuswahl.UseVisualStyleBackColor = true;
			this.btnProjektOrdnerAuswahl.Click += new System.EventHandler(this.btnProjektOrdnerAuswahl_Click);
			// 
			// txtProjektGespeichertInOrdner
			// 
			this.txtProjektGespeichertInOrdner.Location = new System.Drawing.Point(206, 17);
			this.txtProjektGespeichertInOrdner.Name = "txtProjektGespeichertInOrdner";
			this.txtProjektGespeichertInOrdner.Size = new System.Drawing.Size(230, 20);
			this.txtProjektGespeichertInOrdner.TabIndex = 5;
			// 
			// chkIstInProjektOrdner
			// 
			this.chkIstInProjektOrdner.AutoSize = true;
			this.chkIstInProjektOrdner.Location = new System.Drawing.Point(17, 19);
			this.chkIstInProjektOrdner.Name = "chkIstInProjektOrdner";
			this.chkIstInProjektOrdner.Size = new System.Drawing.Size(183, 17);
			this.chkIstInProjektOrdner.TabIndex = 3;
			this.chkIstInProjektOrdner.Text = "wenn Projekt in diesem Ordner ist";
			this.chkIstInProjektOrdner.UseVisualStyleBackColor = true;
			this.chkIstInProjektOrdner.CheckedChanged += new System.EventHandler(this.chkIstInProjektOrdner_CheckedChanged);
			// 
			// chkOhneNachfrage
			// 
			this.chkOhneNachfrage.AutoSize = true;
			this.chkOhneNachfrage.Location = new System.Drawing.Point(17, 54);
			this.chkOhneNachfrage.Name = "chkOhneNachfrage";
			this.chkOhneNachfrage.Size = new System.Drawing.Size(138, 17);
			this.chkOhneNachfrage.TabIndex = 4;
			this.chkOhneNachfrage.Text = "direkt (ohne Nachfrage)";
			this.chkOhneNachfrage.UseVisualStyleBackColor = true;
			// 
			// btnSpeichern
			// 
			this.btnSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSpeichern.Location = new System.Drawing.Point(389, 179);
			this.btnSpeichern.Name = "btnSpeichern";
			this.btnSpeichern.Size = new System.Drawing.Size(95, 24);
			this.btnSpeichern.TabIndex = 2;
			this.btnSpeichern.Text = "Speichern";
			this.btnSpeichern.UseVisualStyleBackColor = true;
			this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.chkByEplanEnd);
			this.groupBox1.Controls.Add(this.chkByProjectClose);
			this.groupBox1.Location = new System.Drawing.Point(6, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(478, 71);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ausführen nur";
			// 
			// chkByEplanEnd
			// 
			this.chkByEplanEnd.AutoSize = true;
			this.chkByEplanEnd.Location = new System.Drawing.Point(17, 43);
			this.chkByEplanEnd.Name = "chkByEplanEnd";
			this.chkByEplanEnd.Size = new System.Drawing.Size(146, 17);
			this.chkByEplanEnd.TabIndex = 2;
			this.chkByEplanEnd.Text = "wenn Eplan beendet wird";
			this.chkByEplanEnd.UseVisualStyleBackColor = true;
			// 
			// chkByProjectClose
			// 
			this.chkByProjectClose.AutoSize = true;
			this.chkByProjectClose.Location = new System.Drawing.Point(17, 20);
			this.chkByProjectClose.Name = "chkByProjectClose";
			this.chkByProjectClose.Size = new System.Drawing.Size(172, 17);
			this.chkByProjectClose.TabIndex = 1;
			this.chkByProjectClose.Text = "wenn Projekt geschlossen wird";
			this.chkByProjectClose.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(166, 260);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(101, 35);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmPDFAssistent
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAbbrechen;
			this.ClientSize = new System.Drawing.Size(519, 309);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.chkEinstellungSpeichern);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnAbbrechen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPDFAssistent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PDF-Export (Assistent)";
			this.Load += new System.EventHandler(this.frmPDFAssistent_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	public frmPDFAssistent()
	{
		InitializeComponent();
	}

	#endregion

	//Menüpunkt anlegen
	[DeclareMenu()]
	public void PDFAssistent_Menu()
	{
		//Menüeintrag
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("PDF (Assistent)...", "PDFAssistent_Start", "PDF Assistent, aktuelles Projekt als PDF-Datei exportieren", 35287, 1, false, false);
	}

	//Event ProjectClose abfangen
	[DeclareEventHandler("onActionStart.String.XPrjActionProjectClose")]
	public void Project_Close_Event()
	{
		//Einstellung einlesen
		Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose"))
		{
			bool bChecked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose", 1);
			if (bChecked) //Bei ProjectClose ausführen
			{
				PDFAssistent_SollStarten();
			}
		}
		return;
	}

	//Event Eplan End abfangen
	[DeclareEventHandler("Eplan.EplApi.OnMainEnd")]
	public void Eplan_End_Event()
	{
		//Einstellung einlesen
		Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd"))
		{
			bool bChecked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd", 1);
			if (bChecked) //Bei EplanEnd ausführen
			{
				PDFAssistent_SollStarten();
			}
		}
		return;
	}

	//Prüfen ob Assistent gestartet werden soll
	public void PDFAssistent_SollStarten()
	{
		Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();

		//Ist Projekt in Projekt-Ordner
		//Wenn angekreuzt dann muß Projekt im Ordner sein für Assistent, sonst kein Assistent
		//Wenn nicht angekreuzt dann Assistent
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage"))
		{
			bool bChecked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdner", 1);
			string sProjektInOrdner = oSettings.GetStringSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdnerName", 0);
			if (bChecked)
			{
				string sProjektOrdner = PathMap.SubstitutePath("$(PROJECTPATH)");
				sProjektOrdner = sProjektOrdner.Substring(0, sProjektOrdner.LastIndexOf(@"\"));
				if (!sProjektOrdner.EndsWith(@"\"))
				{
					sProjektOrdner += @"\";
				}
				if (sProjektInOrdner == sProjektOrdner) //hier vielleicht noch erweitern auf alle Unterordner (InString?)
				{
					PDFAssistent_ausführen();
				}
				else
				{
					Close();
				}
			}
			else
			{
				PDFAssistent_ausführen();
			}
		}
	}

	//Assistent ohne Dialog direkt ausführen (Ohne Nachfrage ausführen)
	public void PDFAssistent_ausführen()
	{
		Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage"))
		{
			bool bChecked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage", 1);
			if (bChecked)
			{
				cboAusgabeNach.SelectedIndex = 0;
				ReadSettings();
				PDFexport(txtSpeicherort.Text + txtDateiname.Text + @".pdf");
				Close();
			}
			else
			{
				PDFAssistent_Start();
			}
		}
	}

	//Assistent Form starten
	[DeclareAction("PDFAssistent_Start")]
	public void PDFAssistent_Start()
	{
		frmPDFAssistent frm = new frmPDFAssistent();
		frm.ShowDialog();
		return;
	}

	//Form wird geladen
	private void frmPDFAssistent_Load(object sender, EventArgs e)
	{
		//Ausgabe Nach einstellen
		cboAusgabeNach.SelectedIndex = 0;
		chkIstInProjektOrdner.CheckState = CheckState.Unchecked;
		txtProjektGespeichertInOrdner.Enabled = false;
		btnProjektOrdnerAuswahl.Enabled = false; 
		ReadSettings();
	}

	//Button: Abbrechen
	private void btnAbbrechen_Click(object sender, System.EventArgs e)
	{
		Close();
	}

	//Button: OK
	private void btnOK_Click(object sender, System.EventArgs e)
	{
		if (txtDateiname.Text != string.Empty)
		{
			PDFexport(txtSpeicherort.Text + txtDateiname.Text + @".pdf");
		}
		WriteSettings();
		Close();
	}

	//Ausgabe Nach hat sich geändert
	private void cboAusgabeNach_SelectedIndexChanged(object sender, EventArgs e)
	{
#if !DEBUG
		string sProjektOrdner = PathMap.SubstitutePath("$(PROJECTPATH)");
		string sDateiName = PathMap.SubstitutePath("$(PROJECTNAME)");
#else
		string sProjektOrdner = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string sDateiName = "TEST";
#endif
		string sAusgabeOrdner = sProjektOrdner;

		switch (cboAusgabeNach.SelectedIndex)
		{
			case 0: //in den Projekt-Ordner
				sAusgabeOrdner = sProjektOrdner;
				break;

			case 1: //Ausgabeverzeichnis aus Einstellungen: PDF-Export
#if !DEBUG
				Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
				string sLastSchema = string.Empty;
				if (oSettings.ExistSetting("USER.PDFExportGUI.SCHEMAS.LastUsed"))
				{
					sLastSchema = oSettings.GetStringSetting("USER.PDFExportGUI.SCHEMAS.LastUsed", 0);
				}
				if (oSettings.ExistSetting("USER.PDFExportGUI.SCHEMAS.Steinert.Data.TargetPath"))
				{
					sAusgabeOrdner = oSettings.GetStringSetting("USER.PDFExportGUI.SCHEMAS." + sLastSchema + ".Data.TargetPath", 0);
				}
#endif
				break;

			case 2: //in den Ordner eine Ebene über dem Projekt-Ordner
				sAusgabeOrdner = sProjektOrdner.Substring(0, sProjektOrdner.LastIndexOf(@"\"));
				break;

			case 3: //in Ordner "Eigene Dateien"
				sAusgabeOrdner = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				break;

			case 4: //auf den Desktop
				sAusgabeOrdner = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				break;

			case 5: //gleicher Pfad wie Projekt nur auf anderes Laufwerk
				sAusgabeOrdner = sProjektOrdner.Substring(0, sProjektOrdner.LastIndexOf(@"\"));	//in den Ordner eine Ebene über dem Projekt-Ordner
				sAusgabeOrdner = sAusgabeOrdner.Replace("C:", "D:");	//Hier anpassen, welche Laufwerksbuchstaben verwendet werden.
				break;

			default:
				MessageBox.Show("Auswahl:default");
				break;
		}

		//Datumsstempel hinzufügen
		if (chkDatumStempel.Checked)
		{
			sDateiName += "_" + DateTime.Now.ToString("yyyyMMdd");
		}

		//Zeitstempel hinzufügen
		if (chkZeitStempel.Checked)
		{
			sDateiName += "-" + DateTime.Now.ToString("HHmmss"); ;
		}

		//Endet mit \ ?
		if (!sAusgabeOrdner.EndsWith(@"\"))
		{
			sAusgabeOrdner += @"\";
		}

		txtDateiname.Text = sDateiName;
		txtSpeicherort.Text = sAusgabeOrdner;
	}

	//Datumstempel zustand hat sich geändert
	private void chkDatumStempel_CheckedChanged(object sender, EventArgs e)
	{
		cboAusgabeNach_SelectedIndexChanged(sender, e);
	}

	//Zeitstempel zustand hat sich geändert
	private void chkZeitStempel_CheckedChanged(object sender, EventArgs e)
	{
		cboAusgabeNach_SelectedIndexChanged(sender, e);
	}

	//Gesamtes Projekt als PDF ausgeben
	public void PDFexport(string sZielDatei)
	{
		//Progressbar ein
		Eplan.EplApi.Base.Progress oProgress = new Eplan.EplApi.Base.Progress("SimpleProgress");
		oProgress.ShowImmediately();

		ActionCallingContext pdfContext = new ActionCallingContext();
		pdfContext.AddParameter("type", "PDFPROJECTSCHEME"); //PDFPROJECTSCHEME = Projekt im PDF-Format exportieren
		//pdfContext.AddParameter("exportscheme", "NAME_SCHEMA"); //verwendetes Schema
		pdfContext.AddParameter("exportfile", sZielDatei); //Name export.Projekt, Vorgabewert: Projektname
		pdfContext.AddParameter("exportmodel", "0"); //0 = keine Modelle ausgeben
		pdfContext.AddParameter("blackwhite", "1"); //1 = PDF wird schwarz-weiss
		pdfContext.AddParameter("useprintmargins", "1"); //1 = Druckränder verwenden
		pdfContext.AddParameter("readonlyexport", "2"); //1 = PDF wird schreibgeschützt
		pdfContext.AddParameter("usesimplelink", "1"); //1 = einfache Sprungfunktion
		pdfContext.AddParameter("usezoomlevel", "1"); //Springen in Navigationsseiten
		pdfContext.AddParameter("fastwebview", "1"); //1 = schnelle Web-Anzeige
		pdfContext.AddParameter("zoomlevel", "1"); //wenn USEZOOMLEVEL auf 1 dann hier Zoomstufe in mm

		CommandLineInterpreter cmdLineItp = new CommandLineInterpreter();
		cmdLineItp.Execute("export", pdfContext);

		//'Progressbar aus
		oProgress.EndPart(true);

		return;
	}

	//Einstellungen speichern
	public void WriteSettings()
	{
		Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();

		//Einstellungen speichern
		if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.SaveSettings"))
		{
			oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.SaveSettings",
				new bool[] { false },
				"SaveSettings Info",
				new bool[] { false },
				ISettings.CreationFlag.Insert);
		}
		oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.SaveSettings", chkEinstellungSpeichern.Checked, 1); //1 = Visible = True

		//Nur Speichern wenn erwünscht
		if (chkEinstellungSpeichern.Checked)
		{

			//PDF bei Projekt schließen
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose"))
			{
				oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose",
					new bool[] { false },
					"Datumsstempel speichern",
					new bool[] { false },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose", chkByProjectClose.Checked, 1); //1 = Visible = True

			//PDF bei Eplan beenden
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd"))
			{
				oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd",
					new bool[] { false },
					"Datumsstempel speichern",
					new bool[] { false },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd", chkByEplanEnd.Checked, 1); //1 = Visible = True

			//Ausgabe Nach
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.AusgabeNach"))
			{
				oSettings.AddNumericSetting("USER.SCRIPTS.PDF_Assistent.AusgabeNach",
					new int[] { 0 },
					new Range[] { new Range { FromValue = 0, ToValue = 32768 } },
					"Default value of test setting",
					new int[] { 0 },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetNumericSetting("USER.SCRIPTS.PDF_Assistent.AusgabeNach", cboAusgabeNach.SelectedIndex, 1); //1 = Visible = True

			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd", chkByEplanEnd.Checked, 1); //1 = Visible = True

			//Ausführen ohne Nachfrage
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage"))
			{
				oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage",
					new bool[] { false },
					"Datumsstempel speichern",
					new bool[] { false },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage", chkOhneNachfrage.Checked, 1); //1 = Visible = True

			//Datumsstempel
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.DateStamp"))
			{
				oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.DateStamp",
					new bool[] { false },
					"Datumsstempel speichern",
					new bool[] { false },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.DateStamp", chkDatumStempel.Checked, 1); //1 = Visible = True

			//Zeitstempel
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.TimeStamp"))
			{
				oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.TimeStamp",
					new bool[] { false },
					"Zeitstempel speichern",
					new bool[] { false },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.TimeStamp", chkZeitStempel.Checked, 1); //1 = Visible = True

			//Projekt in Ordner
			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdner"))
			{
				oSettings.AddBoolSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdner",
					new bool[] { false },
					"Projejt in Ordner speichern",
					new bool[] { false },
					ISettings.CreationFlag.Insert);
			}
			oSettings.SetBoolSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdner", chkIstInProjektOrdner.Checked, 1); //1 = Visible = True

			if (!oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdnerName"))
			{
				oSettings.AddStringSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdnerName",
				new string[] { },
				new string[] { }, "test setting",
				new string[] { "Default value of test setting" },
				ISettings.CreationFlag.Insert);
			}
			oSettings.SetStringSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdnerName", txtProjektGespeichertInOrdner.Text, 0);
		}
	}

	//Einstellungen einlesen
	public void ReadSettings()
	{
		Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();

		//ByProjectClose
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose"))
		{
			chkByProjectClose.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByProjectClose", 1);
		}

		//ByEplanEnd
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd"))
		{
			chkByEplanEnd.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.ByEplanEnd", 1);
		}

		//Ausführen ohne Nachfrage
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage"))
		{
			chkOhneNachfrage.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.OhneNachfrage", 1);
		}

		//Einstellungen speichern
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.SaveSettings"))
		{
			chkEinstellungSpeichern.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.SaveSettings", 1);
		}

		//Datumsstempel 
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.DateStamp"))
		{
			chkDatumStempel.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.DateStamp", 1);
		}

		//Zeitstempel 
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.TimeStamp"))
		{
			chkZeitStempel.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.TimeStamp", 1);
		}

		//Ausgabe Nach
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.AusgabeNach"))
		{
			cboAusgabeNach.SelectedIndex = oSettings.GetNumericSetting("USER.SCRIPTS.PDF_Assistent.AusgabeNach", 1);
		}

		//Projekt in Ordner
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdner"))
		{
			chkIstInProjektOrdner.Checked = oSettings.GetBoolSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdner", 1);
		}
		if (oSettings.ExistSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdnerName"))
		{
			txtProjektGespeichertInOrdner.Text = oSettings.GetStringSetting("USER.SCRIPTS.PDF_Assistent.ProjectInOrdnerName", 0);
		}
	}

	//Button: PDF Ordner auswählen
	private void btnOrdnerAuswahl_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
		folderBrowserDialog1.SelectedPath = txtSpeicherort.Text;
		folderBrowserDialog1.Description = "Wählen Sie den Zielordner aus in dem die PDF-Datei gespeichert werden soll:";
		DialogResult result = folderBrowserDialog1.ShowDialog();
		if (result == DialogResult.OK)
		{
			string sSpeicherort = folderBrowserDialog1.SelectedPath;
			if (!sSpeicherort.EndsWith(@"\"))
			{
				sSpeicherort += @"\";
			}
			txtSpeicherort.Text = sSpeicherort;
		}
	}

	//Button: Speichern
	private void btnSpeichern_Click(object sender, EventArgs e)
	{
		WriteSettings();
	}

	//XML-Reader
	private static string ReadXml(string filename, int ID)
	{
		string strLastVersion = "";
		XmlTextReader reader = new XmlTextReader(filename);
		while (reader.Read())
		{
			if (reader.HasAttributes)
			{
				while (reader.MoveToNextAttribute())
				{
					if (reader.Name == "id")
					{
						if (reader.Value == ID.ToString())
						{
							strLastVersion = reader.ReadString();
							reader.Close();
							return strLastVersion;
						}
					}
				}
			}
		}
		return strLastVersion;
	}

	//Test-Button
	private void button1_Click(object sender, EventArgs e)
	{
		string filename = PathMap.SubstitutePath("$(PROJECTPATH)" + @"\" + "Projectinfo.xml");

		string LastVersion = ReadXml(filename, 10043);

		MessageBox.Show(
			"Zuletzt verwendete EPLAN-Version:\n"
			+ LastVersion,
			"Information",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information
			);

	}

	//Button: Projekt Ordner auswählen
	private void btnProjektOrdnerAuswahl_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
		folderBrowserDialog1.SelectedPath = txtProjektGespeichertInOrdner.Text;
		folderBrowserDialog1.Description = "Wählen Sie den Ordner aus in dem das Projekt gespeichert sein muss:";
		DialogResult result = folderBrowserDialog1.ShowDialog();
		if (result == DialogResult.OK)
		{
			string sSpeicherort = folderBrowserDialog1.SelectedPath;
			if (!sSpeicherort.EndsWith(@"\"))
			{
				sSpeicherort += @"\";
			}
			txtProjektGespeichertInOrdner.Text = sSpeicherort;
		}
	}

	//Ist in Ordner hat sich geändert
	private void chkIstInProjektOrdner_CheckedChanged(object sender, EventArgs e)
	{
		if (chkIstInProjektOrdner.Checked)
		{
			txtProjektGespeichertInOrdner.Enabled = true;
			btnProjektOrdnerAuswahl.Enabled = true;
		}
		else
		{
			txtProjektGespeichertInOrdner.Enabled = false;
			btnProjektOrdnerAuswahl.Enabled = false;
		}
	}
}