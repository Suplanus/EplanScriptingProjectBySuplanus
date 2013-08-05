/*
 * SetCursorColor
 * 
 * Cursor-Farbe je EPLAN-Farbscheme benutzerdefiniert setzen.
 * 
 * ~~~~~~~~~~~~~~~~~ Changelog ~~~~~~~~~~~~~~~~~
 * 2011-07-18   Nairolf     Programmerstellung
 * 2011-08-07   Jonny Wire  Erweiterung um GUI
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public partial class frmSetCursorColor : System.Windows.Forms.Form
{
    #region Variable
    private ColorDialog cd;
    private Settings oSettings = new Settings();
    private Button btnReset;
    private PictureBox pbWhite;
    private PictureBox pbGray;
    private PictureBox pbBlack;
    private Label lblWhite;
    private Label lblGray;
    private Label lblBlack;
    private Button btnClose;
    private bool bColorChanged = false;
    private Color cSetting = new Color();
    #endregion

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
        this.cd = new System.Windows.Forms.ColorDialog();
        this.btnReset = new System.Windows.Forms.Button();
        this.pbWhite = new System.Windows.Forms.PictureBox();
        this.pbGray = new System.Windows.Forms.PictureBox();
        this.pbBlack = new System.Windows.Forms.PictureBox();
        this.lblWhite = new System.Windows.Forms.Label();
        this.lblGray = new System.Windows.Forms.Label();
        this.lblBlack = new System.Windows.Forms.Label();
        this.btnClose = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.pbWhite)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbGray)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbBlack)).BeginInit();
        this.SuspendLayout();
        // 
        // cd
        // 
        this.cd.AnyColor = true;
        // 
        // btnReset
        // 
        this.btnReset.Location = new System.Drawing.Point(11, 107);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new System.Drawing.Size(120, 23);
        this.btnReset.TabIndex = 1;
        this.btnReset.Text = "Zurücksetzen";
        this.btnReset.UseVisualStyleBackColor = true;
        this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
        // 
        // pbWhite
        // 
        this.pbWhite.BackColor = System.Drawing.Color.White;
        this.pbWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pbWhite.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pbWhite.Location = new System.Drawing.Point(12, 12);
        this.pbWhite.Margin = new System.Windows.Forms.Padding(20);
        this.pbWhite.Name = "pbWhite";
        this.pbWhite.Size = new System.Drawing.Size(50, 50);
        this.pbWhite.TabIndex = 3;
        this.pbWhite.TabStop = false;
        this.pbWhite.Click += new System.EventHandler(this.pbWhite_Click);
        // 
        // pbGray
        // 
        this.pbGray.BackColor = System.Drawing.Color.White;
        this.pbGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pbGray.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pbGray.Location = new System.Drawing.Point(109, 12);
        this.pbGray.Margin = new System.Windows.Forms.Padding(20);
        this.pbGray.Name = "pbGray";
        this.pbGray.Size = new System.Drawing.Size(50, 50);
        this.pbGray.TabIndex = 4;
        this.pbGray.TabStop = false;
        this.pbGray.Click += new System.EventHandler(this.pbGray_Click);
        // 
        // pbBlack
        // 
        this.pbBlack.BackColor = System.Drawing.Color.White;
        this.pbBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pbBlack.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pbBlack.Location = new System.Drawing.Point(207, 12);
        this.pbBlack.Margin = new System.Windows.Forms.Padding(20);
        this.pbBlack.Name = "pbBlack";
        this.pbBlack.Size = new System.Drawing.Size(50, 50);
        this.pbBlack.TabIndex = 5;
        this.pbBlack.TabStop = false;
        this.pbBlack.Click += new System.EventHandler(this.pbBlack_Click);
        // 
        // lblWhite
        // 
        this.lblWhite.AutoSize = true;
        this.lblWhite.Location = new System.Drawing.Point(18, 65);
        this.lblWhite.Name = "lblWhite";
        this.lblWhite.Size = new System.Drawing.Size(32, 13);
        this.lblWhite.TabIndex = 6;
        this.lblWhite.Text = "Weiß";
        // 
        // lblGray
        // 
        this.lblGray.AutoSize = true;
        this.lblGray.Location = new System.Drawing.Point(120, 65);
        this.lblGray.Name = "lblGray";
        this.lblGray.Size = new System.Drawing.Size(30, 13);
        this.lblGray.TabIndex = 7;
        this.lblGray.Text = "Grau";
        // 
        // lblBlack
        // 
        this.lblBlack.AutoSize = true;
        this.lblBlack.Location = new System.Drawing.Point(209, 65);
        this.lblBlack.Name = "lblBlack";
        this.lblBlack.Size = new System.Drawing.Size(48, 13);
        this.lblBlack.TabIndex = 8;
        this.lblBlack.Text = "Schwarz";
        // 
        // btnClose
        // 
        this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnClose.Location = new System.Drawing.Point(137, 107);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(120, 23);
        this.btnClose.TabIndex = 0;
        this.btnClose.Text = "Schließen";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // frmSetCursorColor
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnClose;
        this.ClientSize = new System.Drawing.Size(269, 142);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.pbWhite);
        this.Controls.Add(this.lblBlack);
        this.Controls.Add(this.lblWhite);
        this.Controls.Add(this.btnReset);
        this.Controls.Add(this.pbBlack);
        this.Controls.Add(this.lblGray);
        this.Controls.Add(this.pbGray);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmSetCursorColor";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "SetCursorColor";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetCursorColor_FormClosed);
        this.Load += new System.EventHandler(this.frmSetCursorColor_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pbWhite)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbGray)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbBlack)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    public frmSetCursorColor()
    {
        InitializeComponent();
        return;
    }

    #endregion

    # region Action
    [DeclareAction("SetCursorColor")]
    public void Function()
    {
        frmSetCursorColor fSetCursorColor = new frmSetCursorColor();
        fSetCursorColor.ShowDialog();

        return;
    }

    private void SetCursorSetting(string Schema)
    {
        // Set color to setting
        if (cd.ShowDialog() == DialogResult.OK)
        {
            oSettings.SetNumericSetting("USER.GedViewer.ColorSchema." + Schema + ".Cursor.Red", cd.Color.R, 0);
            oSettings.SetNumericSetting("USER.GedViewer.ColorSchema." + Schema + ".Cursor.Green", cd.Color.G, 0);
            oSettings.SetNumericSetting("USER.GedViewer.ColorSchema." + Schema + ".Cursor.Blue", cd.Color.B, 0);

            // Set color to preview
            switch (Schema)
            {
                case "White":
                    pbWhite.BackColor = cd.Color;
                    break;
                case "Gray":
                    pbGray.BackColor = cd.Color;
                    break;
                case "Black":
                    pbBlack.BackColor = cd.Color;
                    break;
            }

            bColorChanged = true;
        }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        // Set default colors
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.White.Cursor.Red", 128, 0);
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.White.Cursor.Green", 128, 0);
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.White.Cursor.Blue", 128, 0);
        pbWhite.BackColor = Color.FromArgb(128, 128, 128);

        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.Gray.Cursor.Red", 192, 0);
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.Gray.Cursor.Green", 0, 0);
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.Gray.Cursor.Blue", 0, 0);
        pbGray.BackColor = Color.FromArgb(192, 0, 0);

        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.Black.Cursor.Red", 255, 0);
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.Black.Cursor.Green", 255, 0);
        oSettings.SetNumericSetting("USER.GedViewer.ColorSchema.Black.Cursor.Blue", 255, 0);
        pbBlack.BackColor = Color.FromArgb(255, 255, 255);

        bColorChanged = true;
    }

    private void pbWhite_Click(object sender, EventArgs e)
    {
        SetCursorSetting("White");
    }

    private void pbGray_Click(object sender, EventArgs e)
    {
        SetCursorSetting("Gray");
    }

    private void pbBlack_Click(object sender, EventArgs e)
    {
        SetCursorSetting("Black");
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void frmSetCursorColor_Load(object sender, EventArgs e)
    {
        // Load colors from settings
        // Wthite
        cSetting = Color.FromArgb(
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.White.Cursor.Red", 0),
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.White.Cursor.Green", 0),
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.White.Cursor.Blue", 0));
        pbWhite.BackColor = cSetting;
        // Gray
        cSetting = Color.FromArgb(
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.Gray.Cursor.Red", 0),
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.Gray.Cursor.Green", 0),
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.Gray.Cursor.Blue", 0));
        pbGray.BackColor = cSetting;
        // Black
        cSetting = Color.FromArgb(
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.Black.Cursor.Red", 0),
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.Black.Cursor.Green", 0),
            oSettings.GetNumericSetting("USER.GedViewer.ColorSchema.Black.Cursor.Blue", 0));
        pbBlack.BackColor = cSetting;
    }

    private void frmSetCursorColor_FormClosed(object sender, FormClosedEventArgs e)
    {
        // Check if color changed
        if (bColorChanged)
        {
            MessageBox.Show("Cursor-Farbschema geändert.\n"
            + "EPLAN muß neu gestartet werden damit die neue Einstellung übernommen wird.",
            "SetCursorColor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    #endregion

    #region Menü
    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        oMenu.AddMenuItem
            (
            "Cursor-Farbe setzen...",
            "SetCursorColor",
            "Cursor-Farbe für verschiedene Farbschema setzen",
            35178,
            1,
            false,
            false
            );
    }
    #endregion
}