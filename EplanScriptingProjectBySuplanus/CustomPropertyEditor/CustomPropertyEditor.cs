using System.IO;
using System.Linq;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class CustomPropertyEditor : System.Windows.Forms.Form
{
    public string PathIni = @"C:\Test\CustomPropertyEditor\";

    public static CustomPropertyEditor frm = new CustomPropertyEditor();
    public static string ValueNew = string.Empty;

    #region Vom Windows Form-Designer generierter Code

    private Button btnOk;
    private Button btnCancel;
    private Label label1;
    private Label label2;
    private Label lblPropertyId;
    private Label lblPropertyIndex;
    private Label label5;
    private Label label6;
    private Label lblCurrentValue;
    private Label lblDbObjectId;
    private ListView livi;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;

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
        this.btnOk = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.lblPropertyId = new System.Windows.Forms.Label();
        this.lblPropertyIndex = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.lblCurrentValue = new System.Windows.Forms.Label();
        this.lblDbObjectId = new System.Windows.Forms.Label();
        this.livi = new System.Windows.Forms.ListView();
        this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.SuspendLayout();
        // 
        // btnOk
        // 
        this.btnOk.Location = new System.Drawing.Point(266, 227);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(100, 23);
        this.btnOk.TabIndex = 5;
        this.btnOk.Text = "OK";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(372, 227);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(100, 23);
        this.btnCancel.TabIndex = 4;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Margin = new System.Windows.Forms.Padding(5);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(90, 12);
        this.label1.TabIndex = 7;
        this.label1.Text = "Property ID:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label2
        // 
        this.label2.Location = new System.Drawing.Point(12, 29);
        this.label2.Margin = new System.Windows.Forms.Padding(3);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(90, 12);
        this.label2.TabIndex = 8;
        this.label2.Text = "Property index:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblPropertyId
        // 
        this.lblPropertyId.Location = new System.Drawing.Point(112, 9);
        this.lblPropertyId.Margin = new System.Windows.Forms.Padding(5);
        this.lblPropertyId.Name = "lblPropertyId";
        this.lblPropertyId.Size = new System.Drawing.Size(80, 12);
        this.lblPropertyId.TabIndex = 9;
        this.lblPropertyId.Text = "xxx";
        this.lblPropertyId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblPropertyIndex
        // 
        this.lblPropertyIndex.Location = new System.Drawing.Point(112, 31);
        this.lblPropertyIndex.Margin = new System.Windows.Forms.Padding(5);
        this.lblPropertyIndex.Name = "lblPropertyIndex";
        this.lblPropertyIndex.Size = new System.Drawing.Size(80, 12);
        this.lblPropertyIndex.TabIndex = 10;
        this.lblPropertyIndex.Text = "xxx";
        this.lblPropertyIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label5.Location = new System.Drawing.Point(192, 31);
        this.label5.Margin = new System.Windows.Forms.Padding(5);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(90, 12);
        this.label5.TabIndex = 14;
        this.label5.Text = "Current Value:";
        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label6
        // 
        this.label6.Location = new System.Drawing.Point(192, 9);
        this.label6.Margin = new System.Windows.Forms.Padding(5);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(90, 12);
        this.label6.TabIndex = 13;
        this.label6.Text = "DB object ID:";
        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCurrentValue
        // 
        this.lblCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblCurrentValue.Location = new System.Drawing.Point(292, 31);
        this.lblCurrentValue.Margin = new System.Windows.Forms.Padding(3);
        this.lblCurrentValue.Name = "lblCurrentValue";
        this.lblCurrentValue.Size = new System.Drawing.Size(180, 12);
        this.lblCurrentValue.TabIndex = 12;
        this.lblCurrentValue.Text = "xxx";
        this.lblCurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblDbObjectId
        // 
        this.lblDbObjectId.Location = new System.Drawing.Point(292, 9);
        this.lblDbObjectId.Margin = new System.Windows.Forms.Padding(5);
        this.lblDbObjectId.Name = "lblDbObjectId";
        this.lblDbObjectId.Size = new System.Drawing.Size(80, 12);
        this.lblDbObjectId.TabIndex = 11;
        this.lblDbObjectId.Text = "xxx";
        this.lblDbObjectId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // livi
        // 
        this.livi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
        this.livi.FullRowSelect = true;
        this.livi.GridLines = true;
        this.livi.Location = new System.Drawing.Point(12, 51);
        this.livi.Name = "livi";
        this.livi.Size = new System.Drawing.Size(460, 170);
        this.livi.TabIndex = 15;
        this.livi.UseCompatibleStateImageBehavior = false;
        this.livi.View = System.Windows.Forms.View.Details;
        this.livi.DoubleClick += new System.EventHandler(this.livi_DoubleClick);
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "Value";
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Description";
        // 
        // CustomPropertyEditor
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(484, 262);
        this.Controls.Add(this.livi);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.lblCurrentValue);
        this.Controls.Add(this.lblDbObjectId);
        this.Controls.Add(this.lblPropertyIndex);
        this.Controls.Add(this.lblPropertyId);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CustomPropertyEditor";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "CustomPropertyEditor";
        this.Load += new System.EventHandler(this.CustomPropertyEditor_Load);
        this.ResumeLayout(false);

    }

    public CustomPropertyEditor()
    {
        InitializeComponent();
    }

    #endregion

    // Setup on startup EPLAN
    [DeclareEventHandler("onMainStart")]
    public void Startup()
    {
        RegisterCustomPropertyEditor();
    }

    [DeclareRegister]
    public void RegisterCustomPropertyEditor()
    {
        LoadScript("true");
    }

    [DeclareUnregister]
    public void UnregisterCustomPropertyEditor()
    {
        LoadScript("false");
    }

    private void LoadScript(string register)
    {
        foreach (string FullFilename in Directory.GetFiles(PathIni))
        {
            try
            {
                string Filename = Path.GetFileNameWithoutExtension(FullFilename);
                if (Filename != null)
                {
                    string[] parameters = Filename.Split('.');

                    Eplan.EplApi.ApplicationFramework.ActionCallingContext acc =
                        new Eplan.EplApi.ApplicationFramework.ActionCallingContext();
                    acc.AddParameter("Register", register);
                    acc.AddParameter("Action", "CustomPropertyEditor");
                    acc.AddParameter("PropertyId", parameters[0]);
                    acc.AddParameter("PropertyIndex", parameters[1]);
                    acc.AddParameter("Editable", parameters[2]);
                    new CommandLineInterpreter().Execute("RegisterCustomPropertyEditorAction", acc);

                    BaseExceptionMessage("RegisterCustomPropertyEditorAction: " +
                                         "PropertyId:" + parameters[0] +
                                         " PropertyIndex:" + parameters[1] +
                                         " Editable:" + parameters[2]);
                }
            }
            catch (System.Exception ex)
            {
                BaseExceptionError("RegisterCustomPropertyEditorAction: " + ex.Message);
            }
        }
    }

    [DeclareAction("CustomPropertyEditor")]
    public void Function(int PropertyId, int PropertyIndex, int DbObjectId, ref string Value, out int DialogModalResult, out string DialogModified)
    {
        // form     
        frm.lblPropertyId.Text = PropertyId.ToString();
        frm.lblPropertyIndex.Text = PropertyIndex.ToString();
        frm.lblDbObjectId.Text = DbObjectId.ToString();
        frm.lblCurrentValue.Text = Value;
        frm.ShowDialog();

        // values
        DialogModified = "1";

        if (frm.DialogResult == DialogResult.OK)
        {
            DialogModalResult = 1;
            Value = ValueNew;
        }
        else
        {
            DialogModalResult = 0;
        }
    }

    private static void BaseExceptionMessage(string message)
    {
        Eplan.EplApi.Base.BaseException bexMessage = new BaseException(message, MessageLevel.Message);
        bexMessage.FixMessage();
    }

    private static void BaseExceptionError(string error)
    {
        Eplan.EplApi.Base.BaseException bexMessage = new BaseException(error, MessageLevel.Error);
        bexMessage.FixMessage();
    }

    private void CustomPropertyEditor_Load(object sender, System.EventArgs e)
    {
        // Search for INI-File
        string FileIni = string.Empty;
        foreach (string file in Directory.GetFiles(PathIni).Where(file => file.StartsWith(PathIni + lblPropertyId.Text + "." + lblPropertyIndex.Text)))
        {
            FileIni = file;
            break;
        }

        // Listview
        if (File.Exists(FileIni))
        {
            livi.Items.Clear();
            string[] lines = File.ReadAllLines(FileIni);
            foreach (string line in lines)
            {
                string[] items = line.Split('\t');
                ListViewItem item = new ListViewItem(items[0]);
                item.SubItems.Add(items[1]);
                livi.Items.Add(item);
            }
            livi.Sorting = SortOrder.Ascending;
            livi.Sort();
            livi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        else
        {
            MessageBox.Show("INI-File not found:\n" + FileIni, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void btnOk_Click(object sender, System.EventArgs e)
    {
        Ok();
    }

    private void Ok()
    {        
        try
        {
            ValueNew = livi.SelectedItems[0].SubItems[0].Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (System.Exception)
        {
            MessageBox.Show("No value selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }

    private void livi_DoubleClick(object sender, System.EventArgs e)
    {
        Ok();
    }


}

