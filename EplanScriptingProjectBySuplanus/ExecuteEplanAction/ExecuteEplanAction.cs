using System.Drawing;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public partial class frmExecuteEplanAction : System.Windows.Forms.Form
{
    private Button btnCancel;
    private Button btnOk;
    private TextBox txtAction;
    private CommandLineInterpreter oCLI = new CommandLineInterpreter();

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
        this.btnCancel = new System.Windows.Forms.Button();
        this.btnOk = new System.Windows.Forms.Button();
        this.txtAction = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(262, 87);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(120, 23);
        this.btnCancel.TabIndex = 1;
        this.btnCancel.Text = "Abbrechen";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnOk
        // 
        this.btnOk.Enabled = false;
        this.btnOk.Location = new System.Drawing.Point(136, 87);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(120, 23);
        this.btnOk.TabIndex = 0;
        this.btnOk.Text = "OK";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // txtAction
        // 
        this.txtAction.BackColor = System.Drawing.Color.LightSalmon;
        this.txtAction.Location = new System.Drawing.Point(12, 37);
        this.txtAction.Name = "txtAction";
        this.txtAction.Size = new System.Drawing.Size(370, 20);
        this.txtAction.TabIndex = 2;
        this.txtAction.TextChanged += new System.EventHandler(this.txtAction_TextChanged);
        // 
        // frmExecuteEplanAction
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(394, 122);
        this.Controls.Add(this.txtAction);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmExecuteEplanAction";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "ExecuteEplanAction";
        this.Load += new System.EventHandler(this.frmExecuteEplanAction_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    public frmExecuteEplanAction()
    {
        InitializeComponent();
    }

    #endregion

    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();

        oMenu.AddMenuItem(
            "EPLAN Action ausführen...",
            "ExecuteEplanAction"
            );

        return;
    }

    [DeclareAction("ExecuteEplanAction")]
    public void Function()
    {
        frmExecuteEplanAction frm = new frmExecuteEplanAction();
        frm.ShowDialog();

        return;
    }

    private void btnCancel_Click(object sender, System.EventArgs e)
    {
        this.Close();

        return;
    }

    private void frmExecuteEplanAction_Load(object sender, System.EventArgs e)
    {
        txtAction.Select();


        return;
    }

    private void btnOk_Click(object sender, System.EventArgs e)
    {
        oCLI.Execute(txtAction.Text);
        this.Close();
        
        return;
    }

    private void txtAction_TextChanged(object sender, System.EventArgs e)
    {
        bool bRet = oCLI.IsExecutable(txtAction.Text);
        if (bRet)
        {
            txtAction.BackColor = Color.LightGreen;
            btnOk.Enabled = true;
        }
        else
        {
            txtAction.BackColor = Color.LightSalmon;
            btnOk.Enabled = false;
        }

        return;
    }
}

