//////////////////////////////////////////////////////////////////////////////////
//                    Abbruchstellen
//////////////////////////////////////////////////////////////////////////////////
//  Ersteller:  Weiher Johann
//  Datum:      2010-03-03
//////////////////////////////////////////////////////////////////////////////////
//
//	Installation:
//	(- Pfade für Tempdatei/Makros kann im Script Zeile 1989+1990 angepasst werden)
//	- Den Inhalt des Ordners "Makros" in das Makroverzeichnis (Firma) kopieren
//	- Script laden...
//	- Spaß haben :)
//
//////////////////////////////////////////////////////////////////////////////////
//	ePlanus.de - Scripting in Eplan ist einfach (toll)
//////////////////////////////////////////////////////////////////////////////////

using System.IO;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class FrmAbbruchstellen : System.Windows.Forms.Form

{
    #region Form
    public FrmAbbruchstellen()
    {
        InitializeComponent();
    }
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus2;
    private System.Windows.Forms.TextBox txtV1;
    private System.Windows.Forms.ListBox lbV13;
    private System.Windows.Forms.ListBox lbV12;
    private System.Windows.Forms.ListBox lbV11;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label lblManInput;
    private System.Windows.Forms.ComboBox cbMakro;
    private System.Windows.Forms.GroupBox grpV1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox lbV14;
    private System.Windows.Forms.GroupBox grpV2;
    private System.Windows.Forms.ListBox lbV24;
    private System.Windows.Forms.ListBox lbV21;
    private System.Windows.Forms.ListBox lbV23;
    private System.Windows.Forms.ListBox lbV22;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtV2;
    private System.Windows.Forms.GroupBox grpV3;
    private System.Windows.Forms.ListBox lbV34;
    private System.Windows.Forms.ListBox lbV31;
    private System.Windows.Forms.ListBox lbV33;
    private System.Windows.Forms.ListBox lbV32;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtV3;
    private System.Windows.Forms.Label lblVariante;
    private System.Windows.Forms.ComboBox cbVariant;
    private System.Windows.Forms.GroupBox grpV5;
    private System.Windows.Forms.ListBox lbV54;
    private System.Windows.Forms.ListBox lbV51;
    private System.Windows.Forms.ListBox lbV53;
    private System.Windows.Forms.ListBox lbV52;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtV5;
    private System.Windows.Forms.GroupBox grpV4;
    private System.Windows.Forms.ListBox lbV44;
    private System.Windows.Forms.ListBox lbV41;
    private System.Windows.Forms.ListBox lbV43;
    private System.Windows.Forms.ListBox lbV42;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtV4;
    private System.Windows.Forms.Label lblV11;
    private System.Windows.Forms.Label lblV21;
    private System.Windows.Forms.Label lblV31;
    private System.Windows.Forms.Label lblV41;
    private System.Windows.Forms.Label lblV51;
    private System.Windows.Forms.Label lblV52;
    private System.Windows.Forms.Label lblV42;
    private System.Windows.Forms.Label lblV32;
    private System.Windows.Forms.Label lblV22;
    private System.Windows.Forms.Label lblV12;
    private System.Windows.Forms.Label lblV13;
    private System.Windows.Forms.Label lblV23;
    private System.Windows.Forms.Label lblV33;
    private System.Windows.Forms.Label lblV43;
    private System.Windows.Forms.Label lblV53;


    ///
    /// Erforderliche Designervariable.
    ///
    private System.ComponentModel.IContainer components = null;

    ///
    /// Verwendete Ressourcen bereinigen.
    ///
    /// True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    ///
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    ///
    private void InitializeComponent()
    {
        this.btnCancel = new System.Windows.Forms.Button();
        this.lblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
        this.txtV1 = new System.Windows.Forms.TextBox();
        this.lbV13 = new System.Windows.Forms.ListBox();
        this.lbV12 = new System.Windows.Forms.ListBox();
        this.lbV11 = new System.Windows.Forms.ListBox();
        this.btnOK = new System.Windows.Forms.Button();
        this.lblManInput = new System.Windows.Forms.Label();
        this.cbMakro = new System.Windows.Forms.ComboBox();
        this.grpV1 = new System.Windows.Forms.GroupBox();
        this.lbV14 = new System.Windows.Forms.ListBox();
        this.label1 = new System.Windows.Forms.Label();
        this.grpV2 = new System.Windows.Forms.GroupBox();
        this.lbV24 = new System.Windows.Forms.ListBox();
        this.lbV21 = new System.Windows.Forms.ListBox();
        this.lbV23 = new System.Windows.Forms.ListBox();
        this.lbV22 = new System.Windows.Forms.ListBox();
        this.label3 = new System.Windows.Forms.Label();
        this.txtV2 = new System.Windows.Forms.TextBox();
        this.grpV3 = new System.Windows.Forms.GroupBox();
        this.lbV34 = new System.Windows.Forms.ListBox();
        this.lbV31 = new System.Windows.Forms.ListBox();
        this.lbV33 = new System.Windows.Forms.ListBox();
        this.lbV32 = new System.Windows.Forms.ListBox();
        this.label4 = new System.Windows.Forms.Label();
        this.txtV3 = new System.Windows.Forms.TextBox();
        this.lblVariante = new System.Windows.Forms.Label();
        this.cbVariant = new System.Windows.Forms.ComboBox();
        this.grpV5 = new System.Windows.Forms.GroupBox();
        this.lbV54 = new System.Windows.Forms.ListBox();
        this.lbV51 = new System.Windows.Forms.ListBox();
        this.lbV53 = new System.Windows.Forms.ListBox();
        this.lbV52 = new System.Windows.Forms.ListBox();
        this.label6 = new System.Windows.Forms.Label();
        this.txtV5 = new System.Windows.Forms.TextBox();
        this.grpV4 = new System.Windows.Forms.GroupBox();
        this.lbV44 = new System.Windows.Forms.ListBox();
        this.lbV41 = new System.Windows.Forms.ListBox();
        this.lbV43 = new System.Windows.Forms.ListBox();
        this.lbV42 = new System.Windows.Forms.ListBox();
        this.label7 = new System.Windows.Forms.Label();
        this.txtV4 = new System.Windows.Forms.TextBox();
        this.lblV11 = new System.Windows.Forms.Label();
        this.lblV21 = new System.Windows.Forms.Label();
        this.lblV31 = new System.Windows.Forms.Label();
        this.lblV41 = new System.Windows.Forms.Label();
        this.lblV51 = new System.Windows.Forms.Label();
        this.lblV52 = new System.Windows.Forms.Label();
        this.lblV42 = new System.Windows.Forms.Label();
        this.lblV32 = new System.Windows.Forms.Label();
        this.lblV22 = new System.Windows.Forms.Label();
        this.lblV12 = new System.Windows.Forms.Label();
        this.lblV13 = new System.Windows.Forms.Label();
        this.lblV23 = new System.Windows.Forms.Label();
        this.lblV33 = new System.Windows.Forms.Label();
        this.lblV43 = new System.Windows.Forms.Label();
        this.lblV53 = new System.Windows.Forms.Label();
        this.grpV1.SuspendLayout();
        this.grpV2.SuspendLayout();
        this.grpV3.SuspendLayout();
        this.grpV5.SuspendLayout();
        this.grpV4.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(820, 647);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(72, 24);
        this.btnCancel.TabIndex = 9;
        this.btnCancel.Text = "Abbrechen";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnAbbrechen_Click);
        // 
        // lblStatus2
        // 
        this.lblStatus2.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
        this.lblStatus2.Name = "lblStatus2";
        this.lblStatus2.Size = new System.Drawing.Size(235, 17);
        this.lblStatus2.Text = "Letzte Änderung: 2009-10-23  - Johann Weiher";
        // 
        // txtV1
        // 
        this.txtV1.Location = new System.Drawing.Point(107, 172);
        this.txtV1.MaxLength = 10;
        this.txtV1.Name = "txtV1";
        this.txtV1.Size = new System.Drawing.Size(317, 20);
        this.txtV1.TabIndex = 1;
        this.txtV1.TextChanged += new System.EventHandler(this.txtV1_TextChanged);
        // 
        // lbV13
        // 
        this.lbV13.FormattingEnabled = true;
        this.lbV13.Items.AddRange(new object[] {
            "",
            "L1",
            "L2",
            "L3",
            "N",
            "PE",
            "XN",
            "XPE",
            "",
            "U",
            "V"});
        this.lbV13.Location = new System.Drawing.Point(218, 19);
        this.lbV13.Name = "lbV13";
        this.lbV13.Size = new System.Drawing.Size(100, 147);
        this.lbV13.TabIndex = 44;
        this.lbV13.TabStop = false;
        this.lbV13.SelectedIndexChanged += new System.EventHandler(this.lbV3_SelectedIndexChanged);
        // 
        // lbV12
        // 
        this.lbV12.FormattingEnabled = true;
        this.lbV12.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV12.Location = new System.Drawing.Point(112, 19);
        this.lbV12.Name = "lbV12";
        this.lbV12.Size = new System.Drawing.Size(100, 147);
        this.lbV12.TabIndex = 45;
        this.lbV12.TabStop = false;
        this.lbV12.SelectedIndexChanged += new System.EventHandler(this.lbV2_SelectedIndexChanged);
        // 
        // lbV11
        // 
        this.lbV11.FormattingEnabled = true;
        this.lbV11.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV11.Location = new System.Drawing.Point(6, 19);
        this.lbV11.Name = "lbV11";
        this.lbV11.Size = new System.Drawing.Size(100, 147);
        this.lbV11.TabIndex = 46;
        this.lbV11.TabStop = false;
        this.lbV11.SelectedIndexChanged += new System.EventHandler(this.lbV1_SelectedIndexChanged);
        // 
        // btnOK
        // 
        this.btnOK.Location = new System.Drawing.Point(729, 648);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(75, 23);
        this.btnOK.TabIndex = 8;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        this.btnOK.Click += new System.EventHandler(this.btn_OK);
        // 
        // lblManInput
        // 
        this.lblManInput.AutoSize = true;
        this.lblManInput.Location = new System.Drawing.Point(6, 175);
        this.lblManInput.Name = "lblManInput";
        this.lblManInput.Size = new System.Drawing.Size(95, 13);
        this.lblManInput.TabIndex = 52;
        this.lblManInput.Text = "Manuelle Eingabe:";
        // 
        // cbMakro
        // 
        this.cbMakro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbMakro.FormattingEnabled = true;
        this.cbMakro.Items.AddRange(new object[] {
            "1pol",
            "1pol (links)",
            "1pol (rechts)",
            "1pol (ganz)",
            "",
            "2pol",
            "2pol (links)",
            "2pol (rechts)",
            "2pol (ganz)",
            "",
            "3pol",
            "3pol (links)",
            "3pol (rechts)",
            "3pol (ganz)",
            "",
            "4pol",
            "4pol (links)",
            "4pol (rechts)",
            "4pol (ganz)",
            "",
            "5pol",
            "5pol (links)",
            "5pol (rechts)",
            "5pol (ganz)"});
        this.cbMakro.Location = new System.Drawing.Point(119, 650);
        this.cbMakro.MaxDropDownItems = 100;
        this.cbMakro.Name = "cbMakro";
        this.cbMakro.Size = new System.Drawing.Size(325, 21);
        this.cbMakro.TabIndex = 6;
        this.cbMakro.SelectedIndexChanged += new System.EventHandler(this.cbMakro_SelectedIndexChanged);
        // 
        // grpV1
        // 
        this.grpV1.Controls.Add(this.lbV14);
        this.grpV1.Controls.Add(this.lbV11);
        this.grpV1.Controls.Add(this.lbV13);
        this.grpV1.Controls.Add(this.lbV12);
        this.grpV1.Controls.Add(this.lblManInput);
        this.grpV1.Controls.Add(this.txtV1);
        this.grpV1.Location = new System.Drawing.Point(12, 12);
        this.grpV1.Name = "grpV1";
        this.grpV1.Size = new System.Drawing.Size(432, 202);
        this.grpV1.TabIndex = 58;
        this.grpV1.TabStop = false;
        this.grpV1.Text = "Variable 1";
        // 
        // lbV14
        // 
        this.lbV14.FormattingEnabled = true;
        this.lbV14.Items.AddRange(new object[] {
            "",
            "L-",
            "L+",
            "",
            "EL+",
            "RL+",
            "PL+",
            "UL+"});
        this.lbV14.Location = new System.Drawing.Point(324, 19);
        this.lbV14.Name = "lbV14";
        this.lbV14.Size = new System.Drawing.Size(100, 147);
        this.lbV14.TabIndex = 47;
        this.lbV14.TabStop = false;
        this.lbV14.SelectedIndexChanged += new System.EventHandler(this.lbV14_SelectedIndexChanged);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(76, 653);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(37, 13);
        this.label1.TabIndex = 59;
        this.label1.Text = "Makro";
        // 
        // grpV2
        // 
        this.grpV2.Controls.Add(this.lbV24);
        this.grpV2.Controls.Add(this.lbV21);
        this.grpV2.Controls.Add(this.lbV23);
        this.grpV2.Controls.Add(this.lbV22);
        this.grpV2.Controls.Add(this.label3);
        this.grpV2.Controls.Add(this.txtV2);
        this.grpV2.Location = new System.Drawing.Point(12, 230);
        this.grpV2.Name = "grpV2";
        this.grpV2.Size = new System.Drawing.Size(432, 202);
        this.grpV2.TabIndex = 59;
        this.grpV2.TabStop = false;
        this.grpV2.Text = "Variable 2";
        // 
        // lbV24
        // 
        this.lbV24.FormattingEnabled = true;
        this.lbV24.Items.AddRange(new object[] {
            "",
            "L-",
            "L+",
            "",
            "EL+",
            "RL+",
            "PL+",
            "UL+"});
        this.lbV24.Location = new System.Drawing.Point(324, 19);
        this.lbV24.Name = "lbV24";
        this.lbV24.Size = new System.Drawing.Size(100, 147);
        this.lbV24.TabIndex = 47;
        this.lbV24.TabStop = false;
        this.lbV24.SelectedIndexChanged += new System.EventHandler(this.lbV24_SelectedIndexChanged);
        // 
        // lbV21
        // 
        this.lbV21.FormattingEnabled = true;
        this.lbV21.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV21.Location = new System.Drawing.Point(6, 19);
        this.lbV21.Name = "lbV21";
        this.lbV21.Size = new System.Drawing.Size(100, 147);
        this.lbV21.TabIndex = 46;
        this.lbV21.TabStop = false;
        this.lbV21.SelectedIndexChanged += new System.EventHandler(this.lbV21_SelectedIndexChanged);
        // 
        // lbV23
        // 
        this.lbV23.FormattingEnabled = true;
        this.lbV23.Items.AddRange(new object[] {
            "",
            "L1",
            "L2",
            "L3",
            "N",
            "PE",
            "XN",
            "XPE",
            "",
            "U",
            "V"});
        this.lbV23.Location = new System.Drawing.Point(218, 19);
        this.lbV23.Name = "lbV23";
        this.lbV23.Size = new System.Drawing.Size(100, 147);
        this.lbV23.TabIndex = 44;
        this.lbV23.TabStop = false;
        this.lbV23.SelectedIndexChanged += new System.EventHandler(this.lbV23_SelectedIndexChanged);
        // 
        // lbV22
        // 
        this.lbV22.FormattingEnabled = true;
        this.lbV22.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV22.Location = new System.Drawing.Point(112, 19);
        this.lbV22.Name = "lbV22";
        this.lbV22.Size = new System.Drawing.Size(100, 147);
        this.lbV22.TabIndex = 45;
        this.lbV22.TabStop = false;
        this.lbV22.SelectedIndexChanged += new System.EventHandler(this.lbV22_SelectedIndexChanged);
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(6, 175);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(95, 13);
        this.label3.TabIndex = 52;
        this.label3.Text = "Manuelle Eingabe:";
        // 
        // txtV2
        // 
        this.txtV2.Location = new System.Drawing.Point(107, 172);
        this.txtV2.MaxLength = 10;
        this.txtV2.Name = "txtV2";
        this.txtV2.Size = new System.Drawing.Size(317, 20);
        this.txtV2.TabIndex = 2;
        this.txtV2.TextChanged += new System.EventHandler(this.txtV2_TextChanged);
        // 
        // grpV3
        // 
        this.grpV3.Controls.Add(this.lbV34);
        this.grpV3.Controls.Add(this.lbV31);
        this.grpV3.Controls.Add(this.lbV33);
        this.grpV3.Controls.Add(this.lbV32);
        this.grpV3.Controls.Add(this.label4);
        this.grpV3.Controls.Add(this.txtV3);
        this.grpV3.Location = new System.Drawing.Point(12, 438);
        this.grpV3.Name = "grpV3";
        this.grpV3.Size = new System.Drawing.Size(432, 202);
        this.grpV3.TabIndex = 60;
        this.grpV3.TabStop = false;
        this.grpV3.Text = "Variable 3";
        // 
        // lbV34
        // 
        this.lbV34.FormattingEnabled = true;
        this.lbV34.Items.AddRange(new object[] {
            "",
            "L-",
            "L+",
            "",
            "EL+",
            "RL+",
            "PL+",
            "UL+"});
        this.lbV34.Location = new System.Drawing.Point(324, 19);
        this.lbV34.Name = "lbV34";
        this.lbV34.Size = new System.Drawing.Size(100, 147);
        this.lbV34.TabIndex = 47;
        this.lbV34.TabStop = false;
        this.lbV34.SelectedIndexChanged += new System.EventHandler(this.lbV34_SelectedIndexChanged);
        // 
        // lbV31
        // 
        this.lbV31.FormattingEnabled = true;
        this.lbV31.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV31.Location = new System.Drawing.Point(6, 19);
        this.lbV31.Name = "lbV31";
        this.lbV31.Size = new System.Drawing.Size(100, 147);
        this.lbV31.TabIndex = 46;
        this.lbV31.TabStop = false;
        this.lbV31.SelectedIndexChanged += new System.EventHandler(this.lbV31_SelectedIndexChanged);
        // 
        // lbV33
        // 
        this.lbV33.FormattingEnabled = true;
        this.lbV33.Items.AddRange(new object[] {
            "",
            "L1",
            "L2",
            "L3",
            "N",
            "PE",
            "XN",
            "XPE",
            "",
            "U",
            "V"});
        this.lbV33.Location = new System.Drawing.Point(218, 19);
        this.lbV33.Name = "lbV33";
        this.lbV33.Size = new System.Drawing.Size(100, 147);
        this.lbV33.TabIndex = 44;
        this.lbV33.TabStop = false;
        this.lbV33.SelectedIndexChanged += new System.EventHandler(this.lbV33_SelectedIndexChanged);
        // 
        // lbV32
        // 
        this.lbV32.FormattingEnabled = true;
        this.lbV32.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV32.Location = new System.Drawing.Point(112, 19);
        this.lbV32.Name = "lbV32";
        this.lbV32.Size = new System.Drawing.Size(100, 147);
        this.lbV32.TabIndex = 45;
        this.lbV32.TabStop = false;
        this.lbV32.SelectedIndexChanged += new System.EventHandler(this.lbV32_SelectedIndexChanged);
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(6, 175);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(95, 13);
        this.label4.TabIndex = 52;
        this.label4.Text = "Manuelle Eingabe:";
        // 
        // txtV3
        // 
        this.txtV3.Location = new System.Drawing.Point(107, 172);
        this.txtV3.MaxLength = 10;
        this.txtV3.Name = "txtV3";
        this.txtV3.Size = new System.Drawing.Size(317, 20);
        this.txtV3.TabIndex = 3;
        this.txtV3.TextChanged += new System.EventHandler(this.txtV3_TextChanged);
        // 
        // lblVariante
        // 
        this.lblVariante.AutoSize = true;
        this.lblVariante.Location = new System.Drawing.Point(515, 653);
        this.lblVariante.Name = "lblVariante";
        this.lblVariante.Size = new System.Drawing.Size(46, 13);
        this.lblVariante.TabIndex = 62;
        this.lblVariante.Text = "Variante";
        // 
        // cbVariant
        // 
        this.cbVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbVariant.FormattingEnabled = true;
        this.cbVariant.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P"});
        this.cbVariant.Location = new System.Drawing.Point(567, 650);
        this.cbVariant.MaxDropDownItems = 20;
        this.cbVariant.Name = "cbVariant";
        this.cbVariant.Size = new System.Drawing.Size(156, 21);
        this.cbVariant.TabIndex = 7;
        this.cbVariant.SelectedIndexChanged += new System.EventHandler(this.cbVariant_SelectedIndexChanged);
        // 
        // grpV5
        // 
        this.grpV5.Controls.Add(this.lbV54);
        this.grpV5.Controls.Add(this.lbV51);
        this.grpV5.Controls.Add(this.lbV53);
        this.grpV5.Controls.Add(this.lbV52);
        this.grpV5.Controls.Add(this.label6);
        this.grpV5.Controls.Add(this.txtV5);
        this.grpV5.Location = new System.Drawing.Point(460, 230);
        this.grpV5.Name = "grpV5";
        this.grpV5.Size = new System.Drawing.Size(432, 202);
        this.grpV5.TabIndex = 62;
        this.grpV5.TabStop = false;
        this.grpV5.Text = "Variable 5";
        // 
        // lbV54
        // 
        this.lbV54.FormattingEnabled = true;
        this.lbV54.Items.AddRange(new object[] {
            "",
            "L-",
            "L+",
            "",
            "EL+",
            "RL+",
            "PL+",
            "UL+"});
        this.lbV54.Location = new System.Drawing.Point(324, 19);
        this.lbV54.Name = "lbV54";
        this.lbV54.Size = new System.Drawing.Size(100, 147);
        this.lbV54.TabIndex = 47;
        this.lbV54.TabStop = false;
        this.lbV54.SelectedIndexChanged += new System.EventHandler(this.lbV54_SelectedIndexChanged);
        // 
        // lbV51
        // 
        this.lbV51.FormattingEnabled = true;
        this.lbV51.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV51.Location = new System.Drawing.Point(6, 19);
        this.lbV51.Name = "lbV51";
        this.lbV51.Size = new System.Drawing.Size(100, 147);
        this.lbV51.TabIndex = 46;
        this.lbV51.TabStop = false;
        this.lbV51.SelectedIndexChanged += new System.EventHandler(this.lbV51_SelectedIndexChanged);
        // 
        // lbV53
        // 
        this.lbV53.FormattingEnabled = true;
        this.lbV53.Items.AddRange(new object[] {
            "",
            "L1",
            "L2",
            "L3",
            "N",
            "PE",
            "XN",
            "XPE",
            "",
            "U",
            "V"});
        this.lbV53.Location = new System.Drawing.Point(218, 19);
        this.lbV53.Name = "lbV53";
        this.lbV53.Size = new System.Drawing.Size(100, 147);
        this.lbV53.TabIndex = 44;
        this.lbV53.TabStop = false;
        this.lbV53.SelectedIndexChanged += new System.EventHandler(this.lbV53_SelectedIndexChanged);
        // 
        // lbV52
        // 
        this.lbV52.FormattingEnabled = true;
        this.lbV52.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV52.Location = new System.Drawing.Point(112, 19);
        this.lbV52.Name = "lbV52";
        this.lbV52.Size = new System.Drawing.Size(100, 147);
        this.lbV52.TabIndex = 45;
        this.lbV52.TabStop = false;
        this.lbV52.SelectedIndexChanged += new System.EventHandler(this.lbV52_SelectedIndexChanged);
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(6, 175);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(95, 13);
        this.label6.TabIndex = 52;
        this.label6.Text = "Manuelle Eingabe:";
        // 
        // txtV5
        // 
        this.txtV5.Location = new System.Drawing.Point(107, 172);
        this.txtV5.MaxLength = 10;
        this.txtV5.Name = "txtV5";
        this.txtV5.Size = new System.Drawing.Size(317, 20);
        this.txtV5.TabIndex = 5;
        this.txtV5.TextChanged += new System.EventHandler(this.txtV5_TextChanged);
        // 
        // grpV4
        // 
        this.grpV4.Controls.Add(this.lbV44);
        this.grpV4.Controls.Add(this.lbV41);
        this.grpV4.Controls.Add(this.lbV43);
        this.grpV4.Controls.Add(this.lbV42);
        this.grpV4.Controls.Add(this.label7);
        this.grpV4.Controls.Add(this.txtV4);
        this.grpV4.Location = new System.Drawing.Point(460, 12);
        this.grpV4.Name = "grpV4";
        this.grpV4.Size = new System.Drawing.Size(432, 202);
        this.grpV4.TabIndex = 61;
        this.grpV4.TabStop = false;
        this.grpV4.Text = "Variable 4";
        // 
        // lbV44
        // 
        this.lbV44.FormattingEnabled = true;
        this.lbV44.Items.AddRange(new object[] {
            "",
            "L-",
            "L+",
            "",
            "EL+",
            "RL+",
            "PL+",
            "UL+"});
        this.lbV44.Location = new System.Drawing.Point(324, 19);
        this.lbV44.Name = "lbV44";
        this.lbV44.Size = new System.Drawing.Size(100, 147);
        this.lbV44.TabIndex = 47;
        this.lbV44.TabStop = false;
        this.lbV44.SelectedIndexChanged += new System.EventHandler(this.lbV44_SelectedIndexChanged);
        // 
        // lbV41
        // 
        this.lbV41.FormattingEnabled = true;
        this.lbV41.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV41.Location = new System.Drawing.Point(6, 19);
        this.lbV41.Name = "lbV41";
        this.lbV41.Size = new System.Drawing.Size(100, 147);
        this.lbV41.TabIndex = 46;
        this.lbV41.TabStop = false;
        this.lbV41.SelectedIndexChanged += new System.EventHandler(this.lbV41_SelectedIndexChanged);
        // 
        // lbV43
        // 
        this.lbV43.FormattingEnabled = true;
        this.lbV43.Items.AddRange(new object[] {
            "",
            "L1",
            "L2",
            "L3",
            "N",
            "PE",
            "XN",
            "XPE",
            "",
            "U",
            "V"});
        this.lbV43.Location = new System.Drawing.Point(218, 19);
        this.lbV43.Name = "lbV43";
        this.lbV43.Size = new System.Drawing.Size(100, 147);
        this.lbV43.TabIndex = 44;
        this.lbV43.TabStop = false;
        this.lbV43.SelectedIndexChanged += new System.EventHandler(this.lbV43_SelectedIndexChanged);
        // 
        // lbV42
        // 
        this.lbV42.FormattingEnabled = true;
        this.lbV42.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
        this.lbV42.Location = new System.Drawing.Point(112, 19);
        this.lbV42.Name = "lbV42";
        this.lbV42.Size = new System.Drawing.Size(100, 147);
        this.lbV42.TabIndex = 45;
        this.lbV42.TabStop = false;
        this.lbV42.SelectedIndexChanged += new System.EventHandler(this.lbV42_SelectedIndexChanged);
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(6, 175);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(95, 13);
        this.label7.TabIndex = 52;
        this.label7.Text = "Manuelle Eingabe:";
        // 
        // txtV4
        // 
        this.txtV4.Location = new System.Drawing.Point(107, 172);
        this.txtV4.MaxLength = 10;
        this.txtV4.Name = "txtV4";
        this.txtV4.Size = new System.Drawing.Size(317, 20);
        this.txtV4.TabIndex = 4;
        this.txtV4.TextChanged += new System.EventHandler(this.txtV4_TextChanged);
        // 
        // lblV11
        // 
        this.lblV11.AutoSize = true;
        this.lblV11.Location = new System.Drawing.Point(548, 464);
        this.lblV11.Name = "lblV11";
        this.lblV11.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblV11.Size = new System.Drawing.Size(54, 13);
        this.lblV11.TabIndex = 64;
        this.lblV11.Text = "Variable 1";
        // 
        // lblV21
        // 
        this.lblV21.AutoSize = true;
        this.lblV21.Location = new System.Drawing.Point(548, 493);
        this.lblV21.Name = "lblV21";
        this.lblV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblV21.Size = new System.Drawing.Size(54, 13);
        this.lblV21.TabIndex = 65;
        this.lblV21.Text = "Variable 2";
        // 
        // lblV31
        // 
        this.lblV31.AutoSize = true;
        this.lblV31.Location = new System.Drawing.Point(548, 522);
        this.lblV31.Name = "lblV31";
        this.lblV31.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblV31.Size = new System.Drawing.Size(54, 13);
        this.lblV31.TabIndex = 66;
        this.lblV31.Text = "Variable 3";
        // 
        // lblV41
        // 
        this.lblV41.AutoSize = true;
        this.lblV41.Location = new System.Drawing.Point(548, 550);
        this.lblV41.Name = "lblV41";
        this.lblV41.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblV41.Size = new System.Drawing.Size(54, 13);
        this.lblV41.TabIndex = 67;
        this.lblV41.Text = "Variable 4";
        // 
        // lblV51
        // 
        this.lblV51.AutoSize = true;
        this.lblV51.Location = new System.Drawing.Point(548, 579);
        this.lblV51.Name = "lblV51";
        this.lblV51.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblV51.Size = new System.Drawing.Size(54, 13);
        this.lblV51.TabIndex = 68;
        this.lblV51.Text = "Variable 5";
        // 
        // lblV52
        // 
        this.lblV52.AutoSize = true;
        this.lblV52.Location = new System.Drawing.Point(767, 579);
        this.lblV52.Name = "lblV52";
        this.lblV52.Size = new System.Drawing.Size(54, 13);
        this.lblV52.TabIndex = 73;
        this.lblV52.Text = "Variable 5";
        // 
        // lblV42
        // 
        this.lblV42.AutoSize = true;
        this.lblV42.Location = new System.Drawing.Point(767, 550);
        this.lblV42.Name = "lblV42";
        this.lblV42.Size = new System.Drawing.Size(54, 13);
        this.lblV42.TabIndex = 72;
        this.lblV42.Text = "Variable 4";
        // 
        // lblV32
        // 
        this.lblV32.AutoSize = true;
        this.lblV32.Location = new System.Drawing.Point(767, 522);
        this.lblV32.Name = "lblV32";
        this.lblV32.Size = new System.Drawing.Size(54, 13);
        this.lblV32.TabIndex = 71;
        this.lblV32.Text = "Variable 3";
        // 
        // lblV22
        // 
        this.lblV22.AutoSize = true;
        this.lblV22.Location = new System.Drawing.Point(767, 493);
        this.lblV22.Name = "lblV22";
        this.lblV22.Size = new System.Drawing.Size(54, 13);
        this.lblV22.TabIndex = 70;
        this.lblV22.Text = "Variable 2";
        // 
        // lblV12
        // 
        this.lblV12.AutoSize = true;
        this.lblV12.Location = new System.Drawing.Point(767, 464);
        this.lblV12.Name = "lblV12";
        this.lblV12.Size = new System.Drawing.Size(54, 13);
        this.lblV12.TabIndex = 69;
        this.lblV12.Text = "Variable 1";
        // 
        // lblV13
        // 
        this.lblV13.AutoSize = true;
        this.lblV13.Font = new System.Drawing.Font("Arial", 19.83673F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.lblV13.Location = new System.Drawing.Point(657, 452);
        this.lblV13.Name = "lblV13";
        this.lblV13.Size = new System.Drawing.Size(43, 32);
        this.lblV13.TabIndex = 74;
        this.lblV13.Text = "→";
        // 
        // lblV23
        // 
        this.lblV23.AutoSize = true;
        this.lblV23.Font = new System.Drawing.Font("Arial", 19.83673F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblV23.Location = new System.Drawing.Point(657, 481);
        this.lblV23.Name = "lblV23";
        this.lblV23.Size = new System.Drawing.Size(43, 32);
        this.lblV23.TabIndex = 75;
        this.lblV23.Text = "→";
        // 
        // lblV33
        // 
        this.lblV33.AutoSize = true;
        this.lblV33.Font = new System.Drawing.Font("Arial", 19.83673F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblV33.Location = new System.Drawing.Point(657, 510);
        this.lblV33.Name = "lblV33";
        this.lblV33.Size = new System.Drawing.Size(43, 32);
        this.lblV33.TabIndex = 76;
        this.lblV33.Text = "→";
        // 
        // lblV43
        // 
        this.lblV43.AutoSize = true;
        this.lblV43.Font = new System.Drawing.Font("Arial", 19.83673F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblV43.Location = new System.Drawing.Point(657, 538);
        this.lblV43.Name = "lblV43";
        this.lblV43.Size = new System.Drawing.Size(43, 32);
        this.lblV43.TabIndex = 77;
        this.lblV43.Text = "→";
        // 
        // lblV53
        // 
        this.lblV53.AutoSize = true;
        this.lblV53.Font = new System.Drawing.Font("Arial", 19.83673F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblV53.Location = new System.Drawing.Point(657, 567);
        this.lblV53.Name = "lblV53";
        this.lblV53.Size = new System.Drawing.Size(43, 32);
        this.lblV53.TabIndex = 78;
        this.lblV53.Text = "→";
        // 
        // FrmAbbruchstellen
        // 
        this.AcceptButton = this.btnOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(904, 677);
        this.Controls.Add(this.lblV53);
        this.Controls.Add(this.lblV43);
        this.Controls.Add(this.lblV33);
        this.Controls.Add(this.lblV23);
        this.Controls.Add(this.lblV13);
        this.Controls.Add(this.lblV52);
        this.Controls.Add(this.lblV42);
        this.Controls.Add(this.lblV32);
        this.Controls.Add(this.lblV22);
        this.Controls.Add(this.lblV12);
        this.Controls.Add(this.lblV51);
        this.Controls.Add(this.lblV41);
        this.Controls.Add(this.lblV31);
        this.Controls.Add(this.lblV21);
        this.Controls.Add(this.lblV11);
        this.Controls.Add(this.lblVariante);
        this.Controls.Add(this.grpV5);
        this.Controls.Add(this.cbVariant);
        this.Controls.Add(this.grpV4);
        this.Controls.Add(this.grpV3);
        this.Controls.Add(this.grpV2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.grpV1);
        this.Controls.Add(this.cbMakro);
        this.Controls.Add(this.btnOK);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmAbbruchstellen";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = "Abbruchstelle einfügen";
        this.Load += new System.EventHandler(this.FrmAbbruchstellen_Load);
        this.grpV1.ResumeLayout(false);
        this.grpV1.PerformLayout();
        this.grpV2.ResumeLayout(false);
        this.grpV2.PerformLayout();
        this.grpV3.ResumeLayout(false);
        this.grpV3.PerformLayout();
        this.grpV5.ResumeLayout(false);
        this.grpV5.PerformLayout();
        this.grpV4.ResumeLayout(false);
        this.grpV4.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion


    # endregion // Code für das Formular

    public string sMacropath = PathMap.SubstitutePath("$(MD_MACROS)") + @"\Verbindungen\Potenziale\";
    public string sTemp = @"C:\Programme\EPLAN\TEMP\temp.ema";
    public string sVariantOut = "";
    public string sMacroOut = "";

    [DeclareAction("Abbruchstellen")]

    ////////////////////////////////////////////////////////////////////////
    // Open dialog
    ////////////////////////////////////////////////////////////////////////
    public void AbbruchstellenVoid()
    {
        FrmAbbruchstellen Frm1 = new FrmAbbruchstellen();
        Frm1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Frm1.ShowDialog();
        return;
    }

    ////////////////////////////////////////////////////////////////////////
    // Loading dialog
    ////////////////////////////////////////////////////////////////////////
    private void FrmAbbruchstellen_Load(object sender, System.EventArgs e)
    {
        txtV1.Select();
        cbMakro.Text = "1pol";
        cbVariant.Text = "A";


        if(!Directory.Exists(System.IO.Path.GetDirectoryName(sTemp)))
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(sTemp));

        }
        if (!File.Exists(sTemp))
        {
            File.Create(sTemp);
        }
    }


    ////////////////////////////////////////////////////////////////////////
    // Button: OK
    ////////////////////////////////////////////////////////////////////////
    public void btn_OK(object sender, System.EventArgs e)
    {
        // Replace Variable
        if (File.Exists(sMacroOut))
        {
            string sReplace = "";
            StreamReader srReplace = new StreamReader(sMacroOut, System.Text.Encoding.Default);
            sReplace = srReplace.ReadToEnd();
            sReplace = sReplace.Replace(@"###V1###", txtV1.Text);
            sReplace = sReplace.Replace(@"###V2###", txtV2.Text);
            sReplace = sReplace.Replace(@"###V3###", txtV3.Text);
            sReplace = sReplace.Replace(@"###V4###", txtV4.Text);
            sReplace = sReplace.Replace(@"###V5###", txtV5.Text);
            srReplace.Close();
            StreamWriter swReplace = new StreamWriter(sTemp);
            swReplace.Write(sReplace);
            swReplace.Close();
        }
        else
        {
            MessageBox.Show("Datei nicht gefunden\n" + sMacroOut);
        }

        // Action
        ActionCallingContext cContext = new ActionCallingContext();
        cContext.AddParameter("Name", "XMIaInsertMacro");
        cContext.AddParameter("filename", sTemp);
        cContext.AddParameter("variant", sVariantOut);
        new CommandLineInterpreter().Execute("XGedStartInteractionAction", cContext);

        Close();
    }

    ////////////////////////////////////////////////////////////////////////
    // Button Cancel
    ////////////////////////////////////////////////////////////////////////
    private void btnAbbrechen_Click(object sender, System.EventArgs e)
    {
        Close();
        return;
    }

    ////////////////////////////////////////////////////////////////////////
    // Get Variable 1
    ////////////////////////////////////////////////////////////////////////
    public void GetNameV1()
    {
        string slbV11 = "";
        string slbV12 = "";
        string slbV13 = "";
        string slbV14 = "";
        if (lbV11.SelectedIndex != -1)
        {
            slbV11 = lbV11.SelectedItem.ToString();
        }
        if (lbV12.SelectedIndex != -1)
        {
            slbV12 = lbV12.SelectedItem.ToString();
        }
        if (lbV13.SelectedIndex != -1)
        {
            slbV13 = lbV13.SelectedItem.ToString();
        }
        if (lbV14.SelectedIndex != -1)
        {
            slbV14 = lbV14.SelectedItem.ToString();
        }
        txtV1.Text = slbV11 + slbV12;
    }
    private void lbV1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV1.Text = "";
        GetNameV1();
    }

    private void lbV2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV1.Text = "";
        GetNameV1();
    }

    private void lbV3_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV1.Text = "";
        GetNameV1();
        txtV1.Text = txtV1.Text + lbV13.SelectedItem.ToString();

    }
    private void lbV14_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV1.Text = "";
        GetNameV1();
        txtV1.Text = txtV1.Text + lbV14.SelectedItem.ToString();
    }

    ////////////////////////////////////////////////////////////////////////
    // Get Variable 2
    ////////////////////////////////////////////////////////////////////////
    public void GetNameV2()
    {
        string slbV21 = "";
        string slbV22 = "";
        string slbV23 = "";
        string slbV24 = "";
        if (lbV21.SelectedIndex != -1)
        {
            slbV21 = lbV21.SelectedItem.ToString();
        }
        if (lbV22.SelectedIndex != -1)
        {
            slbV22 = lbV22.SelectedItem.ToString();
        }
        if (lbV23.SelectedIndex != -1)
        {
            slbV23 = lbV23.SelectedItem.ToString();
        }
        if (lbV24.SelectedIndex != -1)
        {
            slbV24 = lbV24.SelectedItem.ToString();
        }
        txtV2.Text = slbV21 + slbV22;
    }

    private void lbV21_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV2.Text = "";
        GetNameV2();
    }

    private void lbV22_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV2.Text = "";
        GetNameV2();
    }

    private void lbV23_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV2.Text = "";
        GetNameV2();
        txtV2.Text = txtV2.Text + lbV23.SelectedItem.ToString();
    }

    private void lbV24_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV2.Text = "";
        GetNameV2();
        txtV2.Text = txtV2.Text + lbV24.SelectedItem.ToString();
    }

    ////////////////////////////////////////////////////////////////////////
    // Get Variable 3
    ////////////////////////////////////////////////////////////////////////
    public void GetNameV3()
    {
        string slbV31 = "";
        string slbV32 = "";
        string slbV33 = "";
        string slbV34 = "";
        if (lbV31.SelectedIndex != -1)
        {
            slbV31 = lbV31.SelectedItem.ToString();
        }
        if (lbV32.SelectedIndex != -1)
        {
            slbV32 = lbV32.SelectedItem.ToString();
        }
        if (lbV33.SelectedIndex != -1)
        {
            slbV33 = lbV33.SelectedItem.ToString();
        }
        if (lbV34.SelectedIndex != -1)
        {
            slbV34 = lbV34.SelectedItem.ToString();
        }
        txtV3.Text = slbV31 + slbV32;
    }

    private void lbV31_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV3.Text = "";
        GetNameV3();
    }

    private void lbV32_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV3.Text = "";
        GetNameV3();
    }

    private void lbV33_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV3.Text = "";
        GetNameV3();
        txtV3.Text = txtV3.Text + lbV33.SelectedItem.ToString();
    }

    private void lbV34_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV3.Text = "";
        GetNameV3();
        txtV3.Text = txtV3.Text + lbV34.SelectedItem.ToString();
    }

    ////////////////////////////////////////////////////////////////////////
    // Get Variable 4
    ////////////////////////////////////////////////////////////////////////
    public void GetNameV4()
    {
        string slbV41 = "";
        string slbV42 = "";
        string slbV43 = "";
        string slbV44 = "";
        if (lbV41.SelectedIndex != -1)
        {
            slbV41 = lbV41.SelectedItem.ToString();
        }
        if (lbV42.SelectedIndex != -1)
        {
            slbV42 = lbV42.SelectedItem.ToString();
        }
        if (lbV43.SelectedIndex != -1)
        {
            slbV43 = lbV43.SelectedItem.ToString();
        }
        if (lbV44.SelectedIndex != -1)
        {
            slbV44 = lbV44.SelectedItem.ToString();
        }
        txtV4.Text = slbV41 + slbV42;
    }

    private void lbV41_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV4.Text = "";
        GetNameV4();
    }

    private void lbV42_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV4.Text = "";
        GetNameV4();
    }

    private void lbV43_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV4.Text = "";
        GetNameV4();
        txtV4.Text = txtV4.Text + lbV43.SelectedItem.ToString();
    }

    private void lbV44_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV4.Text = "";
        GetNameV4();
        txtV4.Text = txtV4.Text + lbV44.SelectedItem.ToString();
    }

    ////////////////////////////////////////////////////////////////////////
    // Get Variable 5
    ////////////////////////////////////////////////////////////////////////
    public void GetNameV5()
    {
        string slbV51 = "";
        string slbV52 = "";
        string slbV53 = "";
        string slbV54 = "";
        if (lbV51.SelectedIndex != -1)
        {
            slbV51 = lbV51.SelectedItem.ToString();
        }
        if (lbV52.SelectedIndex != -1)
        {
            slbV52 = lbV52.SelectedItem.ToString();
        }
        if (lbV53.SelectedIndex != -1)
        {
            slbV53 = lbV53.SelectedItem.ToString();
        }
        if (lbV54.SelectedIndex != -1)
        {
            slbV54 = lbV54.SelectedItem.ToString();
        }
        txtV5.Text = slbV51 + slbV52;
    }

    private void lbV51_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV5.Text = "";
        GetNameV5();
    }

    private void lbV52_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV5.Text = "";
        GetNameV5();
    }

    private void lbV53_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV5.Text = "";
        GetNameV5();
        txtV5.Text = txtV5.Text + lbV53.SelectedItem.ToString();
    }

    private void lbV54_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtV5.Text = "";
        GetNameV5();
        txtV5.Text = txtV5.Text + lbV54.SelectedItem.ToString();
    }

    private void cbMakro_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        #region Makro
        // Makro
        switch (cbMakro.Text)
        {
            case "1pol":
                sMacroOut = sMacropath + "1pol.ema";

                lblV11.Visible = true;
                lblV12.Visible = false;
                lblV13.Visible = true;

                lblV21.Visible = false;
                lblV22.Visible = false;
                lblV23.Visible = false;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "1pol (links)":
                sMacroOut = sMacropath + "1pol-links.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = false;
                lblV22.Visible = false;
                lblV23.Visible = false;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "1pol (rechts)":
                sMacroOut = sMacropath + "1pol-rechts.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = false;
                lblV22.Visible = false;
                lblV23.Visible = false;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "1pol (ganz)":
                sMacroOut = sMacropath + "1pol-ganz.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = false;
                lblV22.Visible = false;
                lblV23.Visible = false;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;

            case "2pol":
                sMacroOut = sMacropath + "2pol.ema";

                lblV11.Visible = true;
                lblV12.Visible = false;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = false;
                lblV23.Visible = true;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "2pol (links)":
                sMacroOut = sMacropath + "2pol-links.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "2pol (rechts)":
                sMacroOut = sMacropath + "2pol-rechts.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "2pol (ganz)":
                sMacroOut = sMacropath + "2pol-ganz.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;

            case "3pol":
                sMacroOut = sMacropath + "3pol.ema";

                lblV11.Visible = true;
                lblV12.Visible = false;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = false;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = false;
                lblV33.Visible = true;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "3pol (links)":
                sMacroOut = sMacropath + "3pol-links.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "3pol (rechts)":
                sMacroOut = sMacropath + "3pol-rechts.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "3pol (ganz)":
                sMacroOut = sMacropath + "3pol-ganz.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;

            case "4pol":
                sMacroOut = sMacropath + "4pol.ema";

                lblV11.Visible = true;
                lblV12.Visible = false;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = false;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = false;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = false;
                lblV43.Visible = true;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "4pol (links)":
                sMacroOut = sMacropath + "4pol-links.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = true;
                lblV43.Visible = true;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "4pol (rechts)":
                sMacroOut = sMacropath + "4pol-rechts.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = true;
                lblV43.Visible = true;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;
            case "4pol (ganz)":
                sMacroOut = sMacropath + "4pol-ganz.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = true;
                lblV43.Visible = true;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;

                break;

            case "5pol":
                sMacroOut = sMacropath + "5pol.ema";

                lblV11.Visible = true;
                lblV12.Visible = false;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = false;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = false;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = false;
                lblV43.Visible = true;

                lblV51.Visible = true;
                lblV52.Visible = false;
                lblV53.Visible = true;

                break;
            case "5pol (links)":
                sMacroOut = sMacropath + "5pol-links.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = true;
                lblV43.Visible = true;

                lblV51.Visible = true;
                lblV52.Visible = true;
                lblV53.Visible = true;

                break;
            case "5pol (rechts)":
                sMacroOut = sMacropath + "5pol-rechts.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = true;
                lblV43.Visible = true;

                lblV51.Visible = true;
                lblV52.Visible = true;
                lblV53.Visible = true;

                break;
            case "5pol (ganz)":
                sMacroOut = sMacropath + "5pol-ganz.ema";

                lblV11.Visible = true;
                lblV12.Visible = true;
                lblV13.Visible = true;

                lblV21.Visible = true;
                lblV22.Visible = true;
                lblV23.Visible = true;

                lblV31.Visible = true;
                lblV32.Visible = true;
                lblV33.Visible = true;

                lblV41.Visible = true;
                lblV42.Visible = true;
                lblV43.Visible = true;

                lblV51.Visible = true;
                lblV52.Visible = true;
                lblV53.Visible = true;

                break;
            case "":
                grpV1.Enabled = false;
                grpV2.Enabled = false;
                grpV3.Enabled = false;
                grpV4.Enabled = false;
                grpV5.Enabled = false;

                lblV11.Visible = false;
                lblV12.Visible = false;
                lblV13.Visible = false;

                lblV21.Visible = false;
                lblV22.Visible = false;
                lblV23.Visible = false;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;
                break;
        }
        #endregion

        if (File.Exists(sMacroOut))
        {
            string sEqual = "";
            StreamReader srEqual = new StreamReader(sMacroOut, System.Text.Encoding.Default);
            sEqual = srEqual.ReadToEnd();
            srEqual.Close();

            if (sEqual.IndexOf("###V1###") > 0)
            {
                grpV1.Enabled = true;
            }
            else
            {
                grpV1.Enabled = false;
            }

            if (sEqual.IndexOf("###V2###") > 0)
            {
                grpV2.Enabled = true;
            }
            else
            {
                grpV2.Enabled = false;
            }

            if (sEqual.IndexOf("###V3###") > 0)
            {
                grpV3.Enabled = true;
            }
            else
            {
                grpV3.Enabled = false;
            }

            if (sEqual.IndexOf("###V4###") > 0)
            {
                grpV4.Enabled = true;
            }
            else
            {
                grpV4.Enabled = false;
            }

            if (sEqual.IndexOf("###V5###") > 0)
            {
                grpV5.Enabled = true;
            }
            else
            {
                grpV5.Enabled = false;
            }
        }
        else
        {
            MessageBox.Show("Datei nicht gefunden\n" + sMacroOut);
        }
        switch (cbMakro.Text)
        {
                    case "":
                grpV1.Enabled = false;
                grpV2.Enabled = false;
                grpV3.Enabled = false;
                grpV4.Enabled = false;
                grpV5.Enabled = false;

                lblV11.Visible = false;
                lblV12.Visible = false;
                lblV13.Visible = false;

                lblV21.Visible = false;
                lblV22.Visible = false;
                lblV23.Visible = false;

                lblV31.Visible = false;
                lblV32.Visible = false;
                lblV33.Visible = false;

                lblV41.Visible = false;
                lblV42.Visible = false;
                lblV43.Visible = false;

                lblV51.Visible = false;
                lblV52.Visible = false;
                lblV53.Visible = false;
                break;
        }
    }

    private void txtV1_TextChanged(object sender, System.EventArgs e)
    {
        lblV11.Text = txtV1.Text;
        lblV12.Text = txtV1.Text;
    }

    private void txtV2_TextChanged(object sender, System.EventArgs e)
    {
        lblV21.Text = txtV2.Text;
        lblV22.Text = txtV2.Text;
    }

    private void txtV3_TextChanged(object sender, System.EventArgs e)
    {
        lblV31.Text = txtV3.Text;
        lblV32.Text = txtV3.Text;
    }

    private void txtV4_TextChanged(object sender, System.EventArgs e)
    {
        lblV41.Text = txtV4.Text;
        lblV42.Text = txtV4.Text;
    }

    private void txtV5_TextChanged(object sender, System.EventArgs e)
    {
        lblV51.Text = txtV5.Text;
        lblV52.Text = txtV5.Text;
    }

    private void cbVariant_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Variant
        switch (cbVariant.Text)
        {
            case "A":
                sVariantOut = "0";
                break;
            case "B":
                sVariantOut = "1";
                break;
            case "C":
                sVariantOut = "2";
                break;
            case "D":
                sVariantOut = "3";
                break;
            case "E":
                sVariantOut = "4";
                break;
            case "F":
                sVariantOut = "5";
                break;
            case "G":
                sVariantOut = "6";
                break;
            case "H":
                sVariantOut = "7";
                break;
            case "I":
                sVariantOut = "8";
                break;
            case "J":
                sVariantOut = "9";
                break;
            case "K":
                sVariantOut = "10";
                break;
            case "L":
                sVariantOut = "11";
                break;
            case "M":
                sVariantOut = "12";
                break;
            case "N":
                sVariantOut = "13";
                break;
            case "O":
                sVariantOut = "14";
                break;
            case "P":
                sVariantOut = "15";
                break;
        }
    }
	
	
		    [DeclareMenu]
    public void MenuFunction()
    {
        uint intIDUntermenue1;                                         // MenuID
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        intIDUntermenue1 = oMenu.AddMainMenu(
            "ePlanus",                                                     // Hauptmenüname
            "Hilfe",                                                       // neben Menüpunkt...
            "< ePlanus.de >",                                              // Menüpunktname
            "ePlanus",                                                     // Action
            "ePlanus.de - Scripting in Eplan ist einfach (toll)",          // Statustext
            1                                                              // Hinter Menüpunkt x
        );

        // Untermenüpunkte
        oMenu.AddMenuItem(
            "Abbruchstellenkonfigurator",                                            // Menüpunktname
            "Abbruchstellen",                                             // Action
            "ePlanus - Abbruchstellenkonfigurator",                         // Statustext
            intIDUntermenue1,                                               // Menü-ID
            1,                                                              // 1 = Hinter Menüpunkt X
            false,                                                          // Seperator davor
            false                                                           // Seperator dahinter
        );

    }
	

}
