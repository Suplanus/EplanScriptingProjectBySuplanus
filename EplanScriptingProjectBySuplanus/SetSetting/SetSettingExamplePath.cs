using System;
using System.IO;
using System.Windows.Forms;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class frmSetSettingExamplePath : System.Windows.Forms.Form
{
    public Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
    public const string SettingPath = "USER.SCRIPTS.SUPLANUS.Path";
    private TextBox txtPath;
    private Button btnPath;
    private FolderBrowserDialog fbd;
    private Label label1;

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
        this.txtPath = new System.Windows.Forms.TextBox();
        this.btnPath = new System.Windows.Forms.Button();
        this.fbd = new System.Windows.Forms.FolderBrowserDialog();
        this.label1 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // txtPath
        // 
        this.txtPath.Location = new System.Drawing.Point(12, 30);
        this.txtPath.Name = "txtPath";
        this.txtPath.ReadOnly = true;
        this.txtPath.Size = new System.Drawing.Size(340, 20);
        this.txtPath.TabIndex = 0;
        // 
        // btnPath
        // 
        this.btnPath.Location = new System.Drawing.Point(358, 28);
        this.btnPath.Name = "btnPath";
        this.btnPath.Size = new System.Drawing.Size(24, 23);
        this.btnPath.TabIndex = 1;
        this.btnPath.Text = "...";
        this.btnPath.UseVisualStyleBackColor = true;
        this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(79, 13);
        this.label1.TabIndex = 2;
        this.label1.Text = "Ordner wählen:";
        // 
        // frmSetSettingExamplePath
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(394, 72);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnPath);
        this.Controls.Add(this.txtPath);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmSetSettingExamplePath";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "SetStringSettingExamplePath";
        this.Load += new System.EventHandler(this.frmSetSettingExamplePath_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    public frmSetSettingExamplePath()
    {
        InitializeComponent();
    }

    #endregion

    [Start]
    public void Function()
    {
        frmSetSettingExamplePath frm = new frmSetSettingExamplePath();
        frm.ShowDialog();
    }

    private void frmSetSettingExamplePath_Load(object sender, System.EventArgs e)
    {
        // Check if setting exists
        if (!oSettings.ExistSetting(SettingPath))
        {
            // Add setting
            oSettings.AddStringSetting(
                SettingPath,
                new string[] {},
                new string[] {},
                "FolderBrowseDialog Path",
                new string[] {@"Default value of test setting"},
                ISettings.CreationFlag.Insert
                );
            // Add setting value
            oSettings.SetStringSetting(SettingPath, Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 0);
            txtPath.Text = oSettings.GetStringSetting(SettingPath, 0);
        }
        else
        {
            // Load values
            txtPath.Text = oSettings.GetStringSetting(SettingPath, 0);
        }
    }

    private void btnPath_Click(object sender, System.EventArgs e)
    {
        // Check if directory exists
        if (Directory.Exists(txtPath.Text))
        {
            fbd.SelectedPath = txtPath.Text;
        }
        else
        {
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        // Set path to setting
        if (fbd.ShowDialog() == DialogResult.OK)
        {
            txtPath.Text = fbd.SelectedPath;
            oSettings.SetStringSetting(SettingPath, fbd.SelectedPath, 0);
        }
    }
}