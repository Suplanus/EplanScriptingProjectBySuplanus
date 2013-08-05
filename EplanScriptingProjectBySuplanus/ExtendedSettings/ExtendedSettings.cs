using System.Windows.Forms;
using Eplan.EplApi.Scripting;

public class frmExtendedSettings : System.Windows.Forms.Form
{
    private Button btnCancel;
    private Button btnOk;
    private CheckBox chbCopySettingsPath;
    private ToolTip tt;
    private CheckBox chbMenuId;
    public Eplan.EplApi.Base.Settings oSetting = new Eplan.EplApi.Base.Settings();
    private CheckBox chbInplaceEditing;
    private CheckBox chbDontChangeSourceText;

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
        this.components = new System.ComponentModel.Container();
        this.btnCancel = new System.Windows.Forms.Button();
        this.btnOk = new System.Windows.Forms.Button();
        this.chbCopySettingsPath = new System.Windows.Forms.CheckBox();
        this.chbMenuId = new System.Windows.Forms.CheckBox();
        this.tt = new System.Windows.Forms.ToolTip(this.components);
        this.chbInplaceEditing = new System.Windows.Forms.CheckBox();
        this.chbDontChangeSourceText = new System.Windows.Forms.CheckBox();
        this.SuspendLayout();
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(212, 117);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(120, 23);
        this.btnCancel.TabIndex = 1;
        this.btnCancel.Text = "Abbrechen";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnOk
        // 
        this.btnOk.Location = new System.Drawing.Point(86, 117);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(120, 23);
        this.btnOk.TabIndex = 0;
        this.btnOk.Text = "OK";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // chbCopySettingsPath
        // 
        this.chbCopySettingsPath.AutoSize = true;
        this.chbCopySettingsPath.Location = new System.Drawing.Point(12, 12);
        this.chbCopySettingsPath.Name = "chbCopySettingsPath";
        this.chbCopySettingsPath.Size = new System.Drawing.Size(113, 17);
        this.chbCopySettingsPath.TabIndex = 2;
        this.chbCopySettingsPath.Text = "Copy settings path";
        this.tt.SetToolTip(this.chbCopySettingsPath, "Fügt Menüpunkt im Kontextmenü in den Einstellungen hinzu um den Pfad zu kopieren." +
                "");
        this.chbCopySettingsPath.UseVisualStyleBackColor = true;
        // 
        // chbMenuId
        // 
        this.chbMenuId.AutoSize = true;
        this.chbMenuId.Location = new System.Drawing.Point(12, 35);
        this.chbMenuId.Name = "chbMenuId";
        this.chbMenuId.Size = new System.Drawing.Size(67, 17);
        this.chbMenuId.TabIndex = 3;
        this.chbMenuId.Text = "Menu ID";
        this.tt.SetToolTip(this.chbMenuId, "Fügt Menüpunkt im Kontextmenü hinzu um die Menü ID und Ort anzuzeigen. EPLAN-Neus" +
                "tart erforderlich.");
        this.chbMenuId.UseVisualStyleBackColor = true;
        // 
        // chbInplaceEditing
        // 
        this.chbInplaceEditing.AutoSize = true;
        this.chbInplaceEditing.Location = new System.Drawing.Point(12, 58);
        this.chbInplaceEditing.Name = "chbInplaceEditing";
        this.chbInplaceEditing.Size = new System.Drawing.Size(95, 17);
        this.chbInplaceEditing.TabIndex = 4;
        this.chbInplaceEditing.Text = "Inplace editing";
        this.tt.SetToolTip(this.chbInplaceEditing, "Direktes Bearbeiten, Weiterschaltung der Properties mit \"TAB\"-Taste.");
        this.chbInplaceEditing.UseVisualStyleBackColor = true;
        // 
        // chbDontChangeSourceText
        // 
        this.chbDontChangeSourceText.AutoSize = true;
        this.chbDontChangeSourceText.Location = new System.Drawing.Point(12, 81);
        this.chbDontChangeSourceText.Name = "chbDontChangeSourceText";
        this.chbDontChangeSourceText.Size = new System.Drawing.Size(141, 17);
        this.chbDontChangeSourceText.TabIndex = 5;
        this.chbDontChangeSourceText.Text = "DontChangeSourceText";
        this.tt.SetToolTip(this.chbDontChangeSourceText, "Großbuchstabenkonvertierung für Quellsprache deaktivieren.");
        this.chbDontChangeSourceText.UseVisualStyleBackColor = true;
        // 
        // frmExtendedSettings
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(344, 152);
        this.Controls.Add(this.chbDontChangeSourceText);
        this.Controls.Add(this.chbInplaceEditing);
        this.Controls.Add(this.chbMenuId);
        this.Controls.Add(this.chbCopySettingsPath);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmExtendedSettings";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "ExtendedSettings";
        this.Load += new System.EventHandler(this.frmExtendedSettings_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    public frmExtendedSettings()
    {
        InitializeComponent();
    }

    #endregion

    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        oMenu.AddMenuItem(
            "Einstellungen...(erweitert)",
            "ExtendedSettings",
            "Erweiterte Einstellungen setzen...",
            35006,
            1,
            false,
            false
            );
    }

    [DeclareAction("ExtendedSettings")]
    public void Function()
    {
        frmExtendedSettings frm = new frmExtendedSettings();
        frm.ShowDialog();
    }

    private void btnCancel_Click(object sender, System.EventArgs e)
    {
        Close();
    }

    private void frmExtendedSettings_Load(object sender, System.EventArgs e)
    {
        // CopySettingsPath
        chbCopySettingsPath.Checked = oSetting.GetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowExtended", 0);

        // MenuId
        chbMenuId.Checked = oSetting.GetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowIdentifier", 0);

        // InplaceEditing
        chbInplaceEditing.Checked = oSetting.GetBoolSetting("USER.EnfMVC.Debug.InplaceEditingShowAllProperties", 0);

        // DontChangeSourceText
        chbDontChangeSourceText.Checked = oSetting.GetBoolSetting("USER.TRANSLATEGUI.DontChangeSourceText", 0);
    }

    private void btnOk_Click(object sender, System.EventArgs e)
    {
        // CopySettingsPath
        oSetting.SetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowExtended", chbCopySettingsPath.Checked, 0);

        // MenuId
        oSetting.SetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowIdentifier", chbMenuId.Checked, 0);

        // InplaceEditing
        oSetting.SetBoolSetting("USER.EnfMVC.Debug.InplaceEditingShowAllProperties", chbInplaceEditing.Checked, 0);

        // DontChangeSourceText
        oSetting.SetBoolSetting("USER.TRANSLATEGUI.DontChangeSourceText", chbDontChangeSourceText.Checked, 0);

        Close();
    }



}

