using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class SetSettingExampleWindowLocation : System.Windows.Forms.Form
{
    private const string SettingPathWindowLocation = "USER.SCRIPTS.SUPLANUS.WINDOWLOCATION";
    private readonly Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
    private LinkLabel lblSuplanus;

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
        this.lblSuplanus = new System.Windows.Forms.LinkLabel();
        this.SuspendLayout();
        // 
        // lblSuplanus
        // 
        this.lblSuplanus.AutoSize = true;
        this.lblSuplanus.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
        this.lblSuplanus.Location = new System.Drawing.Point(5, 115);
        this.lblSuplanus.Name = "lblSuplanus";
        this.lblSuplanus.Size = new System.Drawing.Size(274, 24);
        this.lblSuplanus.TabIndex = 23;
        this.lblSuplanus.TabStop = true;
        this.lblSuplanus.Text = "http://www.Suplanus.de";
        this.lblSuplanus.LinkClicked +=
            new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSuplanus_LinkClicked);
        // 
        // SetSettingExampleWindowLocation
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 262);
        this.Controls.Add(this.lblSuplanus);
        this.Name = "SetSettingExampleWindowLocation";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "SetSettingExampleWindowLocation";
        this.FormClosing +=
            new System.Windows.Forms.FormClosingEventHandler(this.SetSettingExampleWindowLocation_FormClosing);
        this.Load += new System.EventHandler(this.SetSettingExampleWindowLocation_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    public SetSettingExampleWindowLocation()
    {
        InitializeComponent();
    }

    #endregion

    [Start]
    public void Function()
    {
        SetSettingExampleWindowLocation frm = new SetSettingExampleWindowLocation();
        frm.ShowDialog();
    }

    private void SetSettingExampleWindowLocation_Load(object sender, System.EventArgs e)
    {
        SettingsGet();
    }

    private void SetSettingExampleWindowLocation_FormClosing(object sender, FormClosingEventArgs e)
    {
        SettingsSet();
    }

    private void SettingsGet()
    {
        if (!oSettings.ExistSetting(SettingPathWindowLocation)) // Create setting
        {
            oSettings.AddStringSetting(
                SettingPathWindowLocation,
                new string[] {},
                new string[] {},
                "Location of the form",
                new string[] {},
                ISettings.CreationFlag.Insert
                );
        }
        else // Get setting
        {
            try
            {
                this.Location = new Point(
                    Convert.ToInt32(oSettings.GetStringSetting(SettingPathWindowLocation, 0)),
                    Convert.ToInt32(oSettings.GetStringSetting(SettingPathWindowLocation, 1))
                    );
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void SettingsSet()
    {
        try
        {
            oSettings.SetStringSetting(SettingPathWindowLocation, this.Location.X.ToString(), 0);
            oSettings.SetStringSetting(SettingPathWindowLocation, this.Location.Y.ToString(), 1);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void lblSuplanus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(@"http://www.suplanus.de");
    }
}

