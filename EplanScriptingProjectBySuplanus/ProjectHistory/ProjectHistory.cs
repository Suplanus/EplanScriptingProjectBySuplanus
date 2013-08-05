using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class FrmProjectHistory : System.Windows.Forms.Form
{
    public string strUserHistory = string.Empty; 
    public string strProjectsPath = string.Empty; 
    public ArrayList arrProjectsDirectories = new ArrayList();
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripProgressBar prgBar;
    private ListView liviLastOpend;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private Button btnProjectsHistory;
    private Button btnHistory;

    // Formular (Programmdateien zur Generierung des Forms)
    #region Formular
    public FrmProjectHistory()
    {
        InitializeComponent();
    }

    // ListView: Sortierung
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
            ((ListViewItem)y).SubItems[col].Text);
            return returnVal;
        }
    }

    private System.Windows.Forms.Button btnAbbrechen;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus2;


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
        this.btnAbbrechen = new System.Windows.Forms.Button();
        this.lblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.prgBar = new System.Windows.Forms.ToolStripProgressBar();
        this.btnProjectsHistory = new System.Windows.Forms.Button();
        this.btnHistory = new System.Windows.Forms.Button();
        this.liviLastOpend = new System.Windows.Forms.ListView();
        this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.statusStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnAbbrechen
        // 
        this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnAbbrechen.Location = new System.Drawing.Point(612, 418);
        this.btnAbbrechen.Name = "btnAbbrechen";
        this.btnAbbrechen.Size = new System.Drawing.Size(120, 24);
        this.btnAbbrechen.TabIndex = 7;
        this.btnAbbrechen.Text = "Abbrechen";
        this.btnAbbrechen.UseVisualStyleBackColor = true;
        // 
        // lblStatus2
        // 
        this.lblStatus2.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
        this.lblStatus2.Name = "lblStatus2";
        this.lblStatus2.Size = new System.Drawing.Size(235, 17);
        this.lblStatus2.Text = "Letzte Änderung: 2009-10-23  - Johann Weiher";
        // 
        // statusStrip1
        // 
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgBar});
        this.statusStrip1.Location = new System.Drawing.Point(0, 450);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(744, 22);
        this.statusStrip1.SizingGrip = false;
        this.statusStrip1.TabIndex = 13;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // prgBar
        // 
        this.prgBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        this.prgBar.AutoSize = false;
        this.prgBar.Name = "prgBar";
        this.prgBar.Size = new System.Drawing.Size(740, 16);
        // 
        // btnProjectsHistory
        // 
        this.btnProjectsHistory.Enabled = false;
        this.btnProjectsHistory.Location = new System.Drawing.Point(486, 419);
        this.btnProjectsHistory.Name = "btnProjectsHistory";
        this.btnProjectsHistory.Size = new System.Drawing.Size(120, 23);
        this.btnProjectsHistory.TabIndex = 11;
        this.btnProjectsHistory.Text = "Projekt(e) öffnen";
        this.btnProjectsHistory.UseVisualStyleBackColor = true;
        this.btnProjectsHistory.Click += new System.EventHandler(this.btnProjectsHistory_Click);
        // 
        // btnHistory
        // 
        this.btnHistory.Location = new System.Drawing.Point(360, 419);
        this.btnHistory.Name = "btnHistory";
        this.btnHistory.Size = new System.Drawing.Size(120, 23);
        this.btnHistory.TabIndex = 17;
        this.btnHistory.Text = "History löschen";
        this.btnHistory.UseVisualStyleBackColor = true;
        this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
        // 
        // liviLastOpend
        // 
        this.liviLastOpend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
        this.liviLastOpend.FullRowSelect = true;
        this.liviLastOpend.GridLines = true;
        this.liviLastOpend.HideSelection = false;
        this.liviLastOpend.Location = new System.Drawing.Point(12, 12);
        this.liviLastOpend.Name = "liviLastOpend";
        this.liviLastOpend.Size = new System.Drawing.Size(720, 400);
        this.liviLastOpend.TabIndex = 10;
        this.liviLastOpend.UseCompatibleStateImageBehavior = false;
        this.liviLastOpend.View = System.Windows.Forms.View.Details;
        this.liviLastOpend.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.liviLastOpend_ColumnClick);
        this.liviLastOpend.SelectedIndexChanged += new System.EventHandler(this.liviLastOpend_SelectedIndexChanged);
        this.liviLastOpend.DoubleClick += new System.EventHandler(this.liviLastOpend_DoubleClick);
        // 
        // columnHeader4
        // 
        this.columnHeader4.Text = "Projekt";
        this.columnHeader4.Width = 76;
        // 
        // columnHeader5
        // 
        this.columnHeader5.Text = "Pfad";
        this.columnHeader5.Width = 89;
        // 
        // columnHeader6
        // 
        this.columnHeader6.Text = "Erweiterung";
        this.columnHeader6.Width = 223;
        // 
        // FrmProjectHistory
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.btnAbbrechen;
        this.ClientSize = new System.Drawing.Size(744, 472);
        this.Controls.Add(this.btnHistory);
        this.Controls.Add(this.btnProjectsHistory);
        this.Controls.Add(this.liviLastOpend);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.btnAbbrechen);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmProjectHistory";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "ProjectHistory";
        this.Load += new System.EventHandler(this.FrmSearchMacros_Load);
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion


    # endregion // Code für das Formular

    // Menü
    [DeclareMenu]
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        oMenu.AddMenuItem
            (
            "Projekt History...",
            "ProjectHistory",
            "Projekt History öffnen...",
            35002,
            1,
            false,
            false
            );
    }

    // Projekte speichern
    [DeclareEventHandler("onActionStart.String.XPrjActionProjectClose")]
    public void Function()
    {
        string dir = PathMap.SubstitutePath("$(MD_SCRIPTS)") + @"\ProjectHistory\";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        StreamWriter myFile = new StreamWriter(dir + SystemInformation.UserName + ".txt", true);
        myFile.Write(PathMap.SubstitutePath("$(P)").Replace(".edb",".elk") + "\n");
        myFile.Close();

        return;
    }

    // Action initialisieren
    [DeclareAction("ProjectHistory")]
    public void SearchMacrosVoid()
    {
        FrmProjectHistory Frm1 = new FrmProjectHistory();
        Frm1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Frm1.ShowDialog();
        return;

    }

    // Form: Load
    private void FrmSearchMacros_Load(object sender, System.EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        strProjectsPath = PathMap.SubstitutePath("$(MD_PROJECTS)");
        strUserHistory = PathMap.SubstitutePath("$(MD_SCRIPTS)") + @"\ProjectHistory\" + SystemInformation.UserName + ".txt";
        if(File.Exists(strUserHistory))
        {
            foreach (string line in File.ReadAllLines(strUserHistory))
            {
                FileInfo fi = new FileInfo(line);
                ListViewItem liviItem = new ListViewItem();
                liviItem.Text = Path.GetFileNameWithoutExtension(fi.FullName);
                liviItem.SubItems.Add(fi.Directory.ToString() + @"\");
                liviItem.SubItems.Add(fi.Extension.ToString());
                liviLastOpend.Items.Add(liviItem);
            }
        }

        // Anzeige
        liviLastOpend.BeginUpdate();

        // Anzeige
        for (int i = 0; i <= liviLastOpend.Columns.Count - 1; i++)
        {
            liviLastOpend.Columns[i].Width = -2;
        }
        liviLastOpend.EndUpdate();
        Cursor.Current = Cursors.Default;
    }

    // Button: Abbrechen
    private void btnAbbrechen_Click(object sender, System.EventArgs e)
    {
        Close();
    }

    // Button: OpenProject
    private void btnOpenProject_Click(object sender, System.EventArgs e)
    {
        OpenFileDialog openFileDlg = new OpenFileDialog();
        openFileDlg.Filter = "Projektdatei (*.el*)|*.el*|Alle Dateien anzeigen|*.*";
        openFileDlg.Multiselect = true;
        openFileDlg.InitialDirectory = strProjectsPath;

        // Fileopen
        if (openFileDlg.ShowDialog() == DialogResult.OK)
        {
            this.Update();
            prgBar.Maximum = openFileDlg.FileNames.Length;
            // Dateien einlesen
            foreach (string s in openFileDlg.FileNames)
            {
                prgBar.Value += 1;
                this.Update();
                Eplan_OpenProject(s);
            }
            prgBar.Value = 0;
        }
        this.Close();
    }

    // Methode: Eplan Action: ProjectOpen
    private void Eplan_OpenProject(string FullProjectPath)
    {
        Cursor.Current = Cursors.WaitCursor;

        ActionCallingContext AccOpen = new ActionCallingContext();
        AccOpen.AddParameter("Project", FullProjectPath);
        new CommandLineInterpreter().Execute("ProjectOpen", AccOpen);

        Cursor.Current = Cursors.Default;
    }

    public void Append(string sFilename, string sLines)
    {
        StreamWriter myFile = new StreamWriter(sFilename, true);
        myFile.Write(sLines);
        myFile.Close();
    }

    private void btnHistory_Click(object sender, EventArgs e)
    {
        if (File.Exists(strUserHistory))
        {
            File.Delete(strUserHistory);
        }
        liviLastOpend.Items.Clear();
    }


    private void liviLastOpend_DoubleClick(object sender, EventArgs e)
    {
        string s = liviLastOpend.SelectedItems[0].SubItems[1].Text + liviLastOpend.SelectedItems[0].SubItems[0].Text + liviLastOpend.SelectedItems[0].SubItems[2].Text;
        Eplan_OpenProject(s);
        this.Close();
    }

    private void liviLastOpend_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        this.liviLastOpend.ListViewItemSorter = new ListViewItemComparer(e.Column);
        liviLastOpend.Sort();
    }

    private void liviLastOpend_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (liviLastOpend.SelectedItems.Count > 0)
        {
            btnProjectsHistory.Enabled = true;
        }
    }

    private void btnProjectsHistory_Click(object sender, EventArgs e)
    {
        prgBar.Maximum = liviLastOpend.SelectedItems.Count + 1;
        foreach (ListViewItem item in liviLastOpend.SelectedItems)
        {
            prgBar.Value += 1;
            this.Update();
            string s = item.SubItems[1].Text + item.SubItems[0].Text + item.SubItems[2].Text;
            Eplan_OpenProject(s);
        }
        prgBar.Value = 0;
        this.Close();
    }


}





