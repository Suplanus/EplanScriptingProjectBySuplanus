// LocationPrint.cs
//
// Beschreibung:
// Stromlaufpläne nach Orten sortiert drucken.
// Im Auswahlfeld einen Ort auswählen oder eingeben und die Stromlaufplanseiten für den gewählten Ort werden
// ausgedruckt
// Wildcards werden mitberücksichtigt (* und &)
// z.B.Ort1: KK1 --> alle Seiten mit Bauteilen in +KK1 werden ausgedruckt
// z.B.Ort5: S* --> alle Seiten mit Bauteilen in +S1, +S2, +S3...werden ausgedruckt
// wenn der Hacken bei "Orte vereinzeln" gesetzt wird werden eingaben mit Wildcards vereinzelt ausgewertet: 
// Z.B.alle Bedienstellen im Stromlaufplan heißen +BKx, wenn der Hacken gesetzt ist und die Eingabe BK* bekommt man
// von jeder Bedienstelle die Pläne sortiert ausgedruckt BK1, BK2, BK3 ….
// Die Seiten werden Bauteileorientiert gedruckt. 
// Wenn die Eingabe BK1 ist und auf einer Seite mit einem BK1 Bauteil im Rahmen +KK5 steht,   
// wird die Seite gedruckt
//
// Es werden folgende Seitentypen berücksichtigt: Schaltplan allpolig, Schaltplan einpolig, Übersicht, Grafik, Schaltschrankaufbau
//
//
// 12.02.2018   Artur Netz  V1.0
//

using System;
using System.Windows.Forms;
using System.IO;
using Eplan.EplApi.Scripting;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

public partial class LocationPrint : System.Windows.Forms.Form
{
    private Button btnPrint;
    private Label lblLocation1;
    private ComboBox cobxOrt1;
    private Label lblLocation2;
    private ComboBox cobxOrt2;
    private Label lblLocation3;
    private ComboBox cobxOrt3;
    private Label lblLocation4;
    private ComboBox cobxOrt4;
    private Label lblLocation5;
    private ComboBox cobxOrt5;
    private Label lblLocation6;
    private ComboBox cobxOrt6;
    private Label lblLocation7;
    private ComboBox cobxOrt7;
    private Label lblLocation8;
    private ComboBox cobxOrt8;
    private Label lblLocation9;
    private ComboBox cobxOrt9;
    private Label lblLocation10;
    private ComboBox cobxOrt10;
    private ComboBox cobxSelectPrinter;
    private Label label13;
    private Label label14;
    private Label label15;
    private GroupBox grbxInfo;
    private GroupBox grbxLocations;
    private GroupBox grbxPrint;
    private ComboBox cobxOrt11;
    private ComboBox cobxOrt12;
    private Label lblLocation12;
    private Label lblLocation11;
    private CheckBox chbxOrt12;
    private CheckBox chbxOrt11;
    private CheckBox chbxOrt10;
    private CheckBox chbxOrt9;
    private CheckBox chbxOrt8;
    private CheckBox chbxOrt7;
    private CheckBox chbxOrt6;
    private CheckBox chbxOrt5;
    private CheckBox chbxOrt4;
    private CheckBox chbxOrt3;
    private CheckBox chbxOrt2;
    private CheckBox chbxOrt1;
    private Button btnReset;
    private Label lbl1;
    private Label label1;
    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
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
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblLocation1 = new System.Windows.Forms.Label();
            this.cobxOrt1 = new System.Windows.Forms.ComboBox();
            this.lblLocation2 = new System.Windows.Forms.Label();
            this.cobxOrt2 = new System.Windows.Forms.ComboBox();
            this.lblLocation3 = new System.Windows.Forms.Label();
            this.cobxOrt3 = new System.Windows.Forms.ComboBox();
            this.lblLocation4 = new System.Windows.Forms.Label();
            this.cobxOrt4 = new System.Windows.Forms.ComboBox();
            this.lblLocation5 = new System.Windows.Forms.Label();
            this.cobxOrt5 = new System.Windows.Forms.ComboBox();
            this.lblLocation6 = new System.Windows.Forms.Label();
            this.cobxOrt6 = new System.Windows.Forms.ComboBox();
            this.lblLocation7 = new System.Windows.Forms.Label();
            this.cobxOrt7 = new System.Windows.Forms.ComboBox();
            this.lblLocation8 = new System.Windows.Forms.Label();
            this.cobxOrt8 = new System.Windows.Forms.ComboBox();
            this.lblLocation9 = new System.Windows.Forms.Label();
            this.cobxOrt9 = new System.Windows.Forms.ComboBox();
            this.lblLocation10 = new System.Windows.Forms.Label();
            this.cobxOrt10 = new System.Windows.Forms.ComboBox();
            this.cobxSelectPrinter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.grbxInfo = new System.Windows.Forms.GroupBox();
            this.grbxLocations = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.chbxOrt12 = new System.Windows.Forms.CheckBox();
            this.chbxOrt11 = new System.Windows.Forms.CheckBox();
            this.chbxOrt10 = new System.Windows.Forms.CheckBox();
            this.chbxOrt9 = new System.Windows.Forms.CheckBox();
            this.chbxOrt8 = new System.Windows.Forms.CheckBox();
            this.chbxOrt7 = new System.Windows.Forms.CheckBox();
            this.chbxOrt6 = new System.Windows.Forms.CheckBox();
            this.chbxOrt5 = new System.Windows.Forms.CheckBox();
            this.chbxOrt4 = new System.Windows.Forms.CheckBox();
            this.chbxOrt3 = new System.Windows.Forms.CheckBox();
            this.chbxOrt2 = new System.Windows.Forms.CheckBox();
            this.chbxOrt1 = new System.Windows.Forms.CheckBox();
            this.cobxOrt11 = new System.Windows.Forms.ComboBox();
            this.cobxOrt12 = new System.Windows.Forms.ComboBox();
            this.lblLocation12 = new System.Windows.Forms.Label();
            this.lblLocation11 = new System.Windows.Forms.Label();
            this.grbxPrint = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grbxInfo.SuspendLayout();
            this.grbxLocations.SuspendLayout();
            this.grbxPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(85, 549);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(168, 30);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Drucken";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblLocation1
            // 
            this.lblLocation1.AutoSize = true;
            this.lblLocation1.Location = new System.Drawing.Point(8, 36);
            this.lblLocation1.Name = "lblLocation1";
            this.lblLocation1.Size = new System.Drawing.Size(27, 13);
            this.lblLocation1.TabIndex = 3;
            this.lblLocation1.Text = "Ort1";
            // 
            // cobxOrt1
            // 
            this.cobxOrt1.FormattingEnabled = true;
            this.cobxOrt1.Location = new System.Drawing.Point(58, 33);
            this.cobxOrt1.Name = "cobxOrt1";
            this.cobxOrt1.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt1.TabIndex = 48;
            // 
            // lblLocation2
            // 
            this.lblLocation2.AutoSize = true;
            this.lblLocation2.Location = new System.Drawing.Point(8, 63);
            this.lblLocation2.Name = "lblLocation2";
            this.lblLocation2.Size = new System.Drawing.Size(27, 13);
            this.lblLocation2.TabIndex = 47;
            this.lblLocation2.Text = "Ort2";
            // 
            // cobxOrt2
            // 
            this.cobxOrt2.FormattingEnabled = true;
            this.cobxOrt2.Location = new System.Drawing.Point(58, 60);
            this.cobxOrt2.Name = "cobxOrt2";
            this.cobxOrt2.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt2.TabIndex = 50;
            // 
            // lblLocation3
            // 
            this.lblLocation3.AutoSize = true;
            this.lblLocation3.Location = new System.Drawing.Point(8, 90);
            this.lblLocation3.Name = "lblLocation3";
            this.lblLocation3.Size = new System.Drawing.Size(27, 13);
            this.lblLocation3.TabIndex = 49;
            this.lblLocation3.Text = "Ort3";
            // 
            // cobxOrt3
            // 
            this.cobxOrt3.FormattingEnabled = true;
            this.cobxOrt3.Location = new System.Drawing.Point(58, 87);
            this.cobxOrt3.Name = "cobxOrt3";
            this.cobxOrt3.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt3.TabIndex = 52;
            // 
            // lblLocation4
            // 
            this.lblLocation4.AutoSize = true;
            this.lblLocation4.Location = new System.Drawing.Point(8, 117);
            this.lblLocation4.Name = "lblLocation4";
            this.lblLocation4.Size = new System.Drawing.Size(27, 13);
            this.lblLocation4.TabIndex = 51;
            this.lblLocation4.Text = "Ort4";
            // 
            // cobxOrt4
            // 
            this.cobxOrt4.FormattingEnabled = true;
            this.cobxOrt4.Location = new System.Drawing.Point(58, 114);
            this.cobxOrt4.Name = "cobxOrt4";
            this.cobxOrt4.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt4.TabIndex = 54;
            // 
            // lblLocation5
            // 
            this.lblLocation5.AutoSize = true;
            this.lblLocation5.Location = new System.Drawing.Point(8, 144);
            this.lblLocation5.Name = "lblLocation5";
            this.lblLocation5.Size = new System.Drawing.Size(27, 13);
            this.lblLocation5.TabIndex = 53;
            this.lblLocation5.Text = "Ort5";
            // 
            // cobxOrt5
            // 
            this.cobxOrt5.FormattingEnabled = true;
            this.cobxOrt5.Location = new System.Drawing.Point(58, 141);
            this.cobxOrt5.Name = "cobxOrt5";
            this.cobxOrt5.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt5.TabIndex = 56;
            // 
            // lblLocation6
            // 
            this.lblLocation6.AutoSize = true;
            this.lblLocation6.Location = new System.Drawing.Point(8, 171);
            this.lblLocation6.Name = "lblLocation6";
            this.lblLocation6.Size = new System.Drawing.Size(27, 13);
            this.lblLocation6.TabIndex = 55;
            this.lblLocation6.Text = "Ort6";
            // 
            // cobxOrt6
            // 
            this.cobxOrt6.FormattingEnabled = true;
            this.cobxOrt6.Location = new System.Drawing.Point(58, 168);
            this.cobxOrt6.Name = "cobxOrt6";
            this.cobxOrt6.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt6.TabIndex = 58;
            // 
            // lblLocation7
            // 
            this.lblLocation7.AutoSize = true;
            this.lblLocation7.Location = new System.Drawing.Point(8, 198);
            this.lblLocation7.Name = "lblLocation7";
            this.lblLocation7.Size = new System.Drawing.Size(27, 13);
            this.lblLocation7.TabIndex = 57;
            this.lblLocation7.Text = "Ort7";
            // 
            // cobxOrt7
            // 
            this.cobxOrt7.FormattingEnabled = true;
            this.cobxOrt7.Location = new System.Drawing.Point(58, 195);
            this.cobxOrt7.Name = "cobxOrt7";
            this.cobxOrt7.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt7.TabIndex = 60;
            // 
            // lblLocation8
            // 
            this.lblLocation8.AutoSize = true;
            this.lblLocation8.Location = new System.Drawing.Point(8, 225);
            this.lblLocation8.Name = "lblLocation8";
            this.lblLocation8.Size = new System.Drawing.Size(27, 13);
            this.lblLocation8.TabIndex = 59;
            this.lblLocation8.Text = "Ort8";
            // 
            // cobxOrt8
            // 
            this.cobxOrt8.FormattingEnabled = true;
            this.cobxOrt8.Location = new System.Drawing.Point(58, 222);
            this.cobxOrt8.Name = "cobxOrt8";
            this.cobxOrt8.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt8.TabIndex = 62;
            // 
            // lblLocation9
            // 
            this.lblLocation9.AutoSize = true;
            this.lblLocation9.Location = new System.Drawing.Point(8, 252);
            this.lblLocation9.Name = "lblLocation9";
            this.lblLocation9.Size = new System.Drawing.Size(27, 13);
            this.lblLocation9.TabIndex = 61;
            this.lblLocation9.Text = "Ort9";
            // 
            // cobxOrt9
            // 
            this.cobxOrt9.FormattingEnabled = true;
            this.cobxOrt9.Location = new System.Drawing.Point(58, 249);
            this.cobxOrt9.Name = "cobxOrt9";
            this.cobxOrt9.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt9.TabIndex = 64;
            // 
            // lblLocation10
            // 
            this.lblLocation10.AutoSize = true;
            this.lblLocation10.Location = new System.Drawing.Point(8, 279);
            this.lblLocation10.Name = "lblLocation10";
            this.lblLocation10.Size = new System.Drawing.Size(33, 13);
            this.lblLocation10.TabIndex = 63;
            this.lblLocation10.Text = "Ort10";
            // 
            // cobxOrt10
            // 
            this.cobxOrt10.FormattingEnabled = true;
            this.cobxOrt10.Location = new System.Drawing.Point(58, 276);
            this.cobxOrt10.Name = "cobxOrt10";
            this.cobxOrt10.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt10.TabIndex = 65;
            // 
            // cobxSelectPrinter
            // 
            this.cobxSelectPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxSelectPrinter.FormattingEnabled = true;
            this.cobxSelectPrinter.Location = new System.Drawing.Point(60, 19);
            this.cobxSelectPrinter.Name = "cobxSelectPrinter";
            this.cobxSelectPrinter.Size = new System.Drawing.Size(205, 21);
            this.cobxSelectPrinter.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Trennung mehrerer Orte mit ; (Semikolon)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 70;
            this.label14.Text = "Wildcards:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 26);
            this.label15.TabIndex = 71;
            this.label15.Text = "S* --> Druckt alle Orte die mit S beginnen\r\nS? --> Druckt alle Orte die S + 1 Zei" +
    "chen haben";
            // 
            // grbxInfo
            // 
            this.grbxInfo.Controls.Add(this.label13);
            this.grbxInfo.Controls.Add(this.label15);
            this.grbxInfo.Controls.Add(this.label14);
            this.grbxInfo.Location = new System.Drawing.Point(27, 28);
            this.grbxInfo.Name = "grbxInfo";
            this.grbxInfo.Size = new System.Drawing.Size(301, 82);
            this.grbxInfo.TabIndex = 72;
            this.grbxInfo.TabStop = false;
            this.grbxInfo.Text = "Info";
            // 
            // grbxLocations
            // 
            this.grbxLocations.Controls.Add(this.lbl1);
            this.grbxLocations.Controls.Add(this.chbxOrt12);
            this.grbxLocations.Controls.Add(this.chbxOrt11);
            this.grbxLocations.Controls.Add(this.chbxOrt10);
            this.grbxLocations.Controls.Add(this.chbxOrt9);
            this.grbxLocations.Controls.Add(this.chbxOrt8);
            this.grbxLocations.Controls.Add(this.chbxOrt7);
            this.grbxLocations.Controls.Add(this.chbxOrt6);
            this.grbxLocations.Controls.Add(this.chbxOrt5);
            this.grbxLocations.Controls.Add(this.chbxOrt4);
            this.grbxLocations.Controls.Add(this.chbxOrt3);
            this.grbxLocations.Controls.Add(this.chbxOrt2);
            this.grbxLocations.Controls.Add(this.chbxOrt1);
            this.grbxLocations.Controls.Add(this.cobxOrt11);
            this.grbxLocations.Controls.Add(this.cobxOrt12);
            this.grbxLocations.Controls.Add(this.lblLocation12);
            this.grbxLocations.Controls.Add(this.lblLocation11);
            this.grbxLocations.Controls.Add(this.lblLocation1);
            this.grbxLocations.Controls.Add(this.lblLocation2);
            this.grbxLocations.Controls.Add(this.cobxOrt1);
            this.grbxLocations.Controls.Add(this.lblLocation3);
            this.grbxLocations.Controls.Add(this.cobxOrt10);
            this.grbxLocations.Controls.Add(this.cobxOrt2);
            this.grbxLocations.Controls.Add(this.cobxOrt9);
            this.grbxLocations.Controls.Add(this.lblLocation4);
            this.grbxLocations.Controls.Add(this.lblLocation10);
            this.grbxLocations.Controls.Add(this.cobxOrt3);
            this.grbxLocations.Controls.Add(this.cobxOrt8);
            this.grbxLocations.Controls.Add(this.lblLocation5);
            this.grbxLocations.Controls.Add(this.lblLocation9);
            this.grbxLocations.Controls.Add(this.cobxOrt4);
            this.grbxLocations.Controls.Add(this.cobxOrt7);
            this.grbxLocations.Controls.Add(this.lblLocation6);
            this.grbxLocations.Controls.Add(this.lblLocation8);
            this.grbxLocations.Controls.Add(this.cobxOrt5);
            this.grbxLocations.Controls.Add(this.cobxOrt6);
            this.grbxLocations.Controls.Add(this.lblLocation7);
            this.grbxLocations.Location = new System.Drawing.Point(25, 117);
            this.grbxLocations.Name = "grbxLocations";
            this.grbxLocations.Size = new System.Drawing.Size(303, 359);
            this.grbxLocations.TabIndex = 73;
            this.grbxLocations.TabStop = false;
            this.grbxLocations.Text = "Orte";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(217, 13);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(78, 13);
            this.lbl1.TabIndex = 72;
            this.lbl1.Text = "Orte vereinzeln";
            // 
            // chbxOrt12
            // 
            this.chbxOrt12.AutoSize = true;
            this.chbxOrt12.Location = new System.Drawing.Point(274, 333);
            this.chbxOrt12.Name = "chbxOrt12";
            this.chbxOrt12.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt12.TabIndex = 83;
            this.chbxOrt12.UseVisualStyleBackColor = true;
            // 
            // chbxOrt11
            // 
            this.chbxOrt11.AutoSize = true;
            this.chbxOrt11.Location = new System.Drawing.Point(274, 306);
            this.chbxOrt11.Name = "chbxOrt11";
            this.chbxOrt11.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt11.TabIndex = 82;
            this.chbxOrt11.UseVisualStyleBackColor = true;
            // 
            // chbxOrt10
            // 
            this.chbxOrt10.AutoSize = true;
            this.chbxOrt10.Location = new System.Drawing.Point(274, 279);
            this.chbxOrt10.Name = "chbxOrt10";
            this.chbxOrt10.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt10.TabIndex = 81;
            this.chbxOrt10.UseVisualStyleBackColor = true;
            // 
            // chbxOrt9
            // 
            this.chbxOrt9.AutoSize = true;
            this.chbxOrt9.Location = new System.Drawing.Point(274, 252);
            this.chbxOrt9.Name = "chbxOrt9";
            this.chbxOrt9.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt9.TabIndex = 80;
            this.chbxOrt9.UseVisualStyleBackColor = true;
            // 
            // chbxOrt8
            // 
            this.chbxOrt8.AutoSize = true;
            this.chbxOrt8.Location = new System.Drawing.Point(274, 225);
            this.chbxOrt8.Name = "chbxOrt8";
            this.chbxOrt8.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt8.TabIndex = 79;
            this.chbxOrt8.UseVisualStyleBackColor = true;
            // 
            // chbxOrt7
            // 
            this.chbxOrt7.AutoSize = true;
            this.chbxOrt7.Location = new System.Drawing.Point(274, 198);
            this.chbxOrt7.Name = "chbxOrt7";
            this.chbxOrt7.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt7.TabIndex = 78;
            this.chbxOrt7.UseVisualStyleBackColor = true;
            // 
            // chbxOrt6
            // 
            this.chbxOrt6.AutoSize = true;
            this.chbxOrt6.Location = new System.Drawing.Point(274, 171);
            this.chbxOrt6.Name = "chbxOrt6";
            this.chbxOrt6.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt6.TabIndex = 77;
            this.chbxOrt6.UseVisualStyleBackColor = true;
            // 
            // chbxOrt5
            // 
            this.chbxOrt5.AutoSize = true;
            this.chbxOrt5.Location = new System.Drawing.Point(274, 144);
            this.chbxOrt5.Name = "chbxOrt5";
            this.chbxOrt5.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt5.TabIndex = 76;
            this.chbxOrt5.UseVisualStyleBackColor = true;
            // 
            // chbxOrt4
            // 
            this.chbxOrt4.AutoSize = true;
            this.chbxOrt4.Location = new System.Drawing.Point(274, 117);
            this.chbxOrt4.Name = "chbxOrt4";
            this.chbxOrt4.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt4.TabIndex = 75;
            this.chbxOrt4.UseVisualStyleBackColor = true;
            // 
            // chbxOrt3
            // 
            this.chbxOrt3.AutoSize = true;
            this.chbxOrt3.Location = new System.Drawing.Point(274, 90);
            this.chbxOrt3.Name = "chbxOrt3";
            this.chbxOrt3.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt3.TabIndex = 72;
            this.chbxOrt3.UseVisualStyleBackColor = true;
            // 
            // chbxOrt2
            // 
            this.chbxOrt2.AutoSize = true;
            this.chbxOrt2.Location = new System.Drawing.Point(274, 63);
            this.chbxOrt2.Name = "chbxOrt2";
            this.chbxOrt2.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt2.TabIndex = 71;
            this.chbxOrt2.UseVisualStyleBackColor = true;
            // 
            // chbxOrt1
            // 
            this.chbxOrt1.AutoSize = true;
            this.chbxOrt1.Location = new System.Drawing.Point(274, 36);
            this.chbxOrt1.Name = "chbxOrt1";
            this.chbxOrt1.Size = new System.Drawing.Size(15, 14);
            this.chbxOrt1.TabIndex = 70;
            this.chbxOrt1.UseVisualStyleBackColor = true;
            // 
            // cobxOrt11
            // 
            this.cobxOrt11.FormattingEnabled = true;
            this.cobxOrt11.Location = new System.Drawing.Point(58, 303);
            this.cobxOrt11.Name = "cobxOrt11";
            this.cobxOrt11.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt11.TabIndex = 69;
            // 
            // cobxOrt12
            // 
            this.cobxOrt12.FormattingEnabled = true;
            this.cobxOrt12.Location = new System.Drawing.Point(58, 330);
            this.cobxOrt12.Name = "cobxOrt12";
            this.cobxOrt12.Size = new System.Drawing.Size(207, 21);
            this.cobxOrt12.TabIndex = 68;
            // 
            // lblLocation12
            // 
            this.lblLocation12.AutoSize = true;
            this.lblLocation12.Location = new System.Drawing.Point(8, 333);
            this.lblLocation12.Name = "lblLocation12";
            this.lblLocation12.Size = new System.Drawing.Size(33, 13);
            this.lblLocation12.TabIndex = 67;
            this.lblLocation12.Text = "Ort12";
            // 
            // lblLocation11
            // 
            this.lblLocation11.AutoSize = true;
            this.lblLocation11.Location = new System.Drawing.Point(8, 306);
            this.lblLocation11.Name = "lblLocation11";
            this.lblLocation11.Size = new System.Drawing.Size(33, 13);
            this.lblLocation11.TabIndex = 66;
            this.lblLocation11.Text = "Ort11";
            // 
            // grbxPrint
            // 
            this.grbxPrint.Controls.Add(this.cobxSelectPrinter);
            this.grbxPrint.Location = new System.Drawing.Point(25, 484);
            this.grbxPrint.Name = "grbxPrint";
            this.grbxPrint.Size = new System.Drawing.Size(303, 56);
            this.grbxPrint.TabIndex = 74;
            this.grbxPrint.TabStop = false;
            this.grbxPrint.Text = "Drucker wählen";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(282, 549);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(44, 30);
            this.btnReset.TabIndex = 75;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "nach Orten sortiert Drucken";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 597);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.grbxPrint);
            this.Controls.Add(this.grbxLocations);
            this.Controls.Add(this.grbxInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationPrint";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Location Print";
            this.Load += new System.EventHandler(this.frmDateinamebeispiel_Load);
            this.grbxInfo.ResumeLayout(false);
            this.grbxInfo.PerformLayout();
            this.grbxLocations.ResumeLayout(false);
            this.grbxLocations.PerformLayout();
            this.grbxPrint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    public LocationPrint()
    {
        InitializeComponent();
    }
    #endregion
    // Angaben für Menüeintrag und Toolbar
    static class ScriptConst
    {
        public const string SCRIPTFAMILIE = "ANTools";
        // Werte Anpassen, je nach Script
        public const string SCRIPTTITEL = "Location Print";
        public const string SCRIPTSTATUSTEXT = "Nach Orten sortiert drucken";
        public const string SCRIPTACTION = "LocationPrint"; // in Declare Action die Action manuel eintragen!
    }
    
    [DeclareAction("LocationPrint")]
    public void NachOrtenDrucken()
    {
        LocationPrint frm = new LocationPrint();
        frm.ShowDialog();
    }

    [DeclareAction("Info")]
    public void Infofenster()
    {
        MessageBox.Show("ANTools erstellt von Artur Netz");
    }
    // Menü und Toolbar erzeugen
    [DeclareMenu()]
    public void MenuFunction()
    {
        // Menüeintrag erzeugen
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        uint MenueID = oMenu.GetCustomMenuId(ScriptConst.SCRIPTFAMILIE, null);
        if (MenueID == 0) // Menüpunkt neu erzeugen
        {
            MenueID = oMenu.AddMainMenu(
            ScriptConst.SCRIPTFAMILIE, // Name: Menü
            "Hilfe", // neben...
            ScriptConst.SCRIPTFAMILIE, // Name: Menüpunkt
            "Info", // Name: Action
            " ", // Statustext
            1 // 1 = Hinter Menüpunkt, 0 = Vor Menüpunkt
            );
            oMenu.AddMenuItem(
                ScriptConst.SCRIPTTITEL, // Name: Menüpunkt
                ScriptConst.SCRIPTACTION, // Name: Action
                ScriptConst.SCRIPTSTATUSTEXT, // Statustext
                MenueID, // Menü-ID: Einfügen/Fenstermakro... (STRG + ^ um Menü-ID rauszufinden)
                0, // 1 = Hinter Menüpunkt, 0 = Vor Menüpunkt
                false, // Seperator davor anzeigen
                false // Seperator dahinter anzeigen
                );
        }
        else
        {
            oMenu.AddMenuItem(
                ScriptConst.SCRIPTTITEL, // Name: Menüpunkt
                ScriptConst.SCRIPTACTION, // Name: Action
                ScriptConst.SCRIPTSTATUSTEXT, // Statustext
                MenueID,
                0, // 1 = Hinter Menüpunkt, 0 = Vor Menüpunkt
                false,
                false);
        }
        // Symbolleiste erzeugen
        string symbolLeisteName = ScriptConst.SCRIPTFAMILIE;
        Eplan.EplApi.Gui.Toolbar symbolLeiste = new Eplan.EplApi.Gui.Toolbar();
        bool userLeiste = true;
        // Symbolleiste vorhanden?
        if (symbolLeiste.ExistsToolbar(symbolLeisteName, ref userLeiste) == false)
        {
            symbolLeiste.CreateCustomToolbar(symbolLeisteName, Eplan.EplApi.Gui.Toolbar.ToolBarDockPos.eToolbarFloat, 0, 0, true);
        }
        // Button vorhanden?
        bool buttonvorhanden = false;
        for (int i = 0; i < symbolLeiste.GetCountOfButtons(symbolLeisteName); i++)
        {
            string buttonAction = symbolLeiste.GetButtonAction(symbolLeisteName, i);
            if (buttonAction == ScriptConst.SCRIPTACTION)
            {
                buttonvorhanden = true;
            }
        }
        if (buttonvorhanden == false)
        {
            symbolLeiste.AddButton(symbolLeisteName, 0, ScriptConst.SCRIPTACTION, @"$(MD_SCRIPTS)\" + ScriptConst.SCRIPTACTION + @"\Icon\" + ScriptConst.SCRIPTACTION+ @".BMP", ScriptConst.SCRIPTTITEL);
        }
    }

    public class OrteProjekt
    {
        public static string alleOrte;
        public static string[] orte;

        public static string[] getOrte()
        {
            alleOrte = hilfsfunktion.GetAllLocations();
            alleOrte.Replace("+", "");
            Char delimiter = '\n';
            orte = alleOrte.Split(delimiter);
            return orte;
        }
    }

    private void frmDateinamebeispiel_Load(object sender, EventArgs e)
    {
        string[] orte = OrteProjekt.getOrte();

        for (int i = 0; i < orte.Length; i++)
        {
            cobxOrt1.Items.Add(orte[i]);
            cobxOrt2.Items.Add(orte[i]);
            cobxOrt3.Items.Add(orte[i]);
            cobxOrt4.Items.Add(orte[i]);
            cobxOrt5.Items.Add(orte[i]);
            cobxOrt6.Items.Add(orte[i]);
            cobxOrt7.Items.Add(orte[i]);
            cobxOrt8.Items.Add(orte[i]);
            cobxOrt9.Items.Add(orte[i]);
            cobxOrt10.Items.Add(orte[i]);
            cobxOrt11.Items.Add(orte[i]);
            cobxOrt12.Items.Add(orte[i]);
        }
        // Standard Drucker ermitteln
        PrintDocument pd = new PrintDocument();
        string Standarddrucker = pd.PrinterSettings.PrinterName;
        // Alle Drucker ermitteln
        int j = 0;
        int indexstdprinter = 0;
        foreach (string Name in PrinterSettings.InstalledPrinters)
        {
            cobxSelectPrinter.Items.Add(Name);
            if (Name == Standarddrucker)
            {
                indexstdprinter = j;
            }
            j = j + 1;
        }
        // Standard Drucker wählen
        cobxSelectPrinter.SelectedIndex = indexstdprinter;
    }

    private static String WildCardToRegular(String value)
    {
        return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
    }


    private string OrteVereinzeln(string input)
    {
        string ortedrucken = "";
        string alleOrte = "";
        alleOrte = OrteProjekt.alleOrte;
        string[] orteimprojekt;
        string[] inputSplit;
        // String in Array String Aufteilen
        orteimprojekt = alleOrte.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
        //orteimprojekt = alleOrte.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
        //orteimprojekt = alleOrte.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
        inputSplit = input.Split(';');
        inputSplit = input.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
        //inputSplit = input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
        //inputSplit = input.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);

        for (int j = 0; j < inputSplit.Length; j++)
        {
            for (int i = 0; i < orteimprojekt.Length; i++)
            {
                // Vergleich mit Wildcards
                Boolean endsWithEx = Regex.IsMatch(orteimprojekt[i], WildCardToRegular(inputSplit[j]));
                if (endsWithEx)
                    {
                    //MessageBox.Show(orteimprojekt[i]);
                    hilfsfunktion.GetAllLocationSites(orteimprojekt[i]);
                    ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
                }
            }
        }
        if (ortedrucken =="")
        {
            MessageBox.Show("Beim Ausdruck \"" + input + "\" wurde kein Ort gefunden!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return ortedrucken;
    }
    private void btnPrint_Click(object sender, EventArgs e)
    {
        string ortedrucken = "";
        // Datei generieren mit allen Projektseiten
        hilfsfunktion.GetAllSites();

        if (cobxOrt1.Text != "")
        {
            if (chbxOrt1.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt1.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt1.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt2.Text != "")
        {
            if (chbxOrt2.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt2.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt2.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt3.Text != "")
        {
            if (chbxOrt3.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt3.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt3.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt4.Text != "")
        {
            if (chbxOrt4.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt4.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt4.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt5.Text != "")
        {
            if (chbxOrt5.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt5.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt5.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt6.Text != "")
        {
            if (chbxOrt6.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt6.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt6.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt7.Text != "")
        {
            if (chbxOrt7.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt7.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt7.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt8.Text != "")
        {
            if (chbxOrt8.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt8.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt8.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt9.Text != "")
        {
            if (chbxOrt9.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt9.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt9.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt10.Text != "")
        {
            if (chbxOrt10.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt10.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt10.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt11.Text != "")
        {
            if (chbxOrt11.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt11.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt11.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }
        if (cobxOrt12.Text != "")
        {
            if (chbxOrt12.Checked == true)
            {
                ortedrucken = ortedrucken + OrteVereinzeln(cobxOrt12.Text);
            }
            else
            {
                hilfsfunktion.GetAllLocationSites(cobxOrt12.Text);
                ortedrucken = ortedrucken + hilfsfunktion.ortsdrucken();
            }
        }

        // Drucken
        ActionCallingContext actionCallingContext = new ActionCallingContext();
        actionCallingContext.AddParameter("type", "pages");
        actionCallingContext.AddParameter("printername", cobxSelectPrinter.Text);
        // Mehrere Seiten Parameter erzeugen
        Char delimiter = ' ';
        string[] orte = ortedrucken.Split(delimiter);
        for (int i = 0; i < orte.Length; i++)
        {
            actionCallingContext.AddParameter("pagename" + (i - 1), orte[i]);
        }
        // Letzte Abfrage ob wirklich gedruckt werden soll
        if (ortedrucken.Length >= 1)
        {
            DialogResult result = MessageBox.Show(ortedrucken.Substring(1) + "\nInsgesammt: " + (orte.Length - 1) + " Seiten", "Drucken?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                new CommandLineInterpreter().Execute("print", actionCallingContext);
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }
        else
        {
            MessageBox.Show("Keine Seiten zum Drucken gefunden!","Info" ,MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }

    }
    private void btnReset_Click(object sender, EventArgs e)
    {
        cobxOrt1.Text = "";
        cobxOrt2.Text = "";
        cobxOrt3.Text = "";
        cobxOrt4.Text = "";
        cobxOrt5.Text = "";
        cobxOrt6.Text = "";
        cobxOrt7.Text = "";
        cobxOrt8.Text = "";
        cobxOrt9.Text = "";
        cobxOrt10.Text = "";
        cobxOrt11.Text = "";
        cobxOrt12.Text = "";

        chbxOrt1.Checked = false;
        chbxOrt2.Checked = false;
        chbxOrt3.Checked = false;
        chbxOrt4.Checked = false;
        chbxOrt5.Checked = false;
        chbxOrt6.Checked = false;
        chbxOrt7.Checked = false;
        chbxOrt8.Checked = false;
        chbxOrt9.Checked = false;
        chbxOrt10.Checked = false;
        chbxOrt11.Checked = false;
        chbxOrt12.Checked = false;
    }
    public class hilfsfunktion
    {
        public static string GetAllLocations()
        {
            string path = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                        "LocationPrint", "Schemes", "[LocationPrint]GetAllLocations.xml");
            string value = "";
            try
            {
                new Settings().ReadSettings(path);
                string pathOutput = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                           "LocationPrint", "Schemes", "GetAllLocations_Output.txt");
                File.Delete(pathOutput);

                // Export
                ActionCallingContext actionCallingContext = new ActionCallingContext();
                actionCallingContext.AddParameter("configscheme", "[LocationPrint]GetAllLocations");
               // actionCallingContext.AddParameter("filterscheme", "[LocationPrint]Einbauorte");
                actionCallingContext.AddParameter("destinationfile", pathOutput);
                actionCallingContext.AddParameter("language", "de_DE");
                new CommandLineInterpreter().Execute("label", actionCallingContext);

                // Read
                value = File.ReadAllText(pathOutput);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "[LocationPrint]GetAllLocations", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                value = "[Error]";
            }
            return value;
        }
        // Funktion um alle Seiten aus EplanProjekt auszulesen
        public static string GetAllSites()
        {
            string path = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                        "LocationPrint", "Schemes", "[LocationPrint]GetAllSites.xml");
            string value = "";
            try
            {
                new Settings().ReadSettings(path);
                string pathOutput = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                           "LocationPrint", "Schemes", "GetAllSites_Output.txt");
                File.Delete(pathOutput);    // Datei aus letztem Lauf löschen
                // Export
                ActionCallingContext actionCallingContext = new ActionCallingContext();
                actionCallingContext.AddParameter("configscheme", "[LocationPrint]GetAllSites");
                //actionCallingContext.AddParameter("filterscheme", "[LocationPrint]GetAllSitesFilter");
                actionCallingContext.AddParameter("destinationfile", pathOutput);
                actionCallingContext.AddParameter("language", "de_DE");
                new CommandLineInterpreter().Execute("label", actionCallingContext);

                // Read
                value = File.ReadAllText(pathOutput);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "[LocationPrint]GetAllSites", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                value = "[Error]";
            }
            return value;
        }
        // Funktion um alle Seiten aus EplanProjekt auszulesen
        public static string GetAllLocationSites(string ort)
        {
            string path = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                        "LocationPrint", "Schemes", "[LocationPrint]GetAllLocationSites.xml");
            string pathtemp = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                "LocationPrint", "Schemes", "[LocationPrint]GetAllLocationSitesTemp.xml");
            string value = "";
            string content = string.Empty;
            string filterstring = string.Empty;
            string stringbereinigung;
            // Set scheme
            content = File.ReadAllText(pathtemp);
            // das "+" rausschneiden, falls versehentlich eingetippt
            stringbereinigung = ort.Replace("+", "");
            stringbereinigung = stringbereinigung.Replace("\r", "");
            filterstring = "0|1|0|1220;0|0|" + stringbereinigung + "|0|1|1|0|0|0;0|";
            content = content.Replace("FilterLocation", filterstring);
            File.WriteAllText(path, content);

            try
            {
                new Settings().ReadSettings(path);
                string pathOutput = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                           "LocationPrint", "Schemes", "GetAllLocationSites_Output.txt");
                File.Delete(pathOutput);    // Datei aus letztem Lauf löschen
                // Export
                ActionCallingContext actionCallingContext = new ActionCallingContext();
                actionCallingContext.AddParameter("configscheme", "[LocationPrint]GetAllLocationSites");
                //actionCallingContext.AddParameter("filterscheme", "[LocationPrint]GetAllLocationSitesFilter");
                actionCallingContext.AddParameter("destinationfile", pathOutput);
                actionCallingContext.AddParameter("language", "de_DE");
                new CommandLineInterpreter().Execute("label", actionCallingContext);
                // Read
                value = File.ReadAllText(pathOutput);
            }
            catch
            {
                MessageBox.Show("Ort \"" + ort + "\" wurde nicht gefunden!","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                value = "";
            }
            return value;
        }
        // Funktion um die Druckseiten zu erstellen
        public static string ortsdrucken()
        {
            string tempstring = string.Empty;
            int seitenanzahl = 0;
            string[] stringarray = new string[1000];
            string seitendrucken = string.Empty;
            string path1 = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                           "LocationPrint", "Schemes", "GetAllSites_Output.txt");
            string path2 = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
                           "LocationPrint", "Schemes", "GetAllLocationSites_Output.txt");
            try
            {
                // Seitenzahlen des Projektes einlesen
                using (StreamReader sr = new StreamReader(path1))
                    tempstring = sr.ReadToEnd();
                string[] separators = { " ", "\n", "\r" };
                string[] seitenzahlen = tempstring.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                // orte die gedruckt werden sollen Seitenzahlen einlesen
                using (StreamReader sr2 = new StreamReader(path2))
                    tempstring = sr2.ReadToEnd();
                string[] druckseiten = tempstring.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                // Ausgabe
                for (int i1 = 0; i1 < seitenzahlen.Length; i1++)
                {
                    for (int i2 = 0; i2 < druckseiten.Length; i2++)
                    {
                        if (seitenzahlen[i1] == druckseiten[i2])
                        {
                            //Seite gefunden , wird gedruckt
                            seitendrucken = seitendrucken + " " + seitenzahlen[i1];
                            seitenanzahl = seitenanzahl + 1;
                            break; // For Schleife verlassen
                        }
                    }
                }
            }
            catch
            {
                //   MessageBox.Show("Fehler beim Auswerten, Druck konnte nicht erstellt werden");
            }
            return seitendrucken;
        }
    }
}
