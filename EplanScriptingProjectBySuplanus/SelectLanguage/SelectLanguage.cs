using System;
using System.Collections;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class SelectLanguage : System.Windows.Forms.Form
{
    //public string LanguageType = string.Empty;
    readonly ArrayList aryLanguages = new ArrayList();
    public CommandLineInterpreter oCLI = new CommandLineInterpreter();
    public ActionCallingContext acc = new ActionCallingContext();

    #region Vom Windows Form-Designer generierter Code
    private Label label1;
    private ListView liviLanguages;
    private ColumnHeader columnHeader1;
    private Button btnCancel;
    private Button btnOk;
    private ColumnHeader columnHeader2;

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

    private void AddLanguages()
    {
        aryLanguages.Add("af_ZA;Afrikaans");
        aryLanguages.Add("am_AM;Armenisch");
        aryLanguages.Add("ar_AE;Arabisch (Vereinigte Arabische Emirate)");
        aryLanguages.Add("ar_BH;Arabisch (Bahrein)");
        aryLanguages.Add("ar_DZ;Arabisch (Algerien)");
        aryLanguages.Add("ar_EG;Arabisch (Ägypten)");
        aryLanguages.Add("ar_IQ;Arabisch (Irak)");
        aryLanguages.Add("ar_JO;Arabisch (Jordanien)");
        aryLanguages.Add("ar_KW;Arabisch (Kuwait)");
        aryLanguages.Add("ar_LB;Arabisch (Libanon)");
        aryLanguages.Add("ar_LY;Arabisch (Libyen)");
        aryLanguages.Add("ar_MA;Arabisch (Marokko)");
        aryLanguages.Add("ar_OM;Arabisch (Oman)");
        aryLanguages.Add("ar_QA;Arabisch (Katar)");
        aryLanguages.Add("ar_SA;Arabisch (Saudi-Arabien)");
        aryLanguages.Add("ar_SY;Arabisch (Syrien)");
        aryLanguages.Add("ar_TN;Arabisch (Tunesien)");
        aryLanguages.Add("ar_YE;Arabisch (Jemen)");
        aryLanguages.Add("bg_BG;Bulgarisch");
        aryLanguages.Add("bs_BA;Bosnisch (Lateinisch, Bosnien und Herzegowina)");
        aryLanguages.Add("ca_ES;Katalanisch");
        aryLanguages.Add("cs_CZ;Tschechisch");
        aryLanguages.Add("da_DK;Dänisch");
        aryLanguages.Add("de_DE;Deutsch (Deutschland)");
        aryLanguages.Add("dz_BT;Bhutani");
        aryLanguages.Add("el_GR;Griechisch");
        aryLanguages.Add("en_AU;Englisch (Australien)");
        aryLanguages.Add("en_CA;Englisch (Kanada)");
        aryLanguages.Add("en_EN;Englisch (Großbritannien)");
        aryLanguages.Add("en_IE;Englisch (Irland)");
        aryLanguages.Add("en_NZ;Englisch (Neuseeland)");
        aryLanguages.Add("en_US;Englisch (USA)");
        aryLanguages.Add("en_ZA;Englisch (Südafrika)");
        aryLanguages.Add("es_AR;Spanisch (Argentinien)");
        aryLanguages.Add("es_BO;Spanisch (Bolivien)");
        aryLanguages.Add("es_CL;Spanisch (Chile)");
        aryLanguages.Add("es_CO;Spanisch (Kolumbien)");
        aryLanguages.Add("es_CR;Spanisch (Costa Rica)");
        aryLanguages.Add("es_DO;Spanisch (Dominikanische Republik)");
        aryLanguages.Add("es_EC;Spanisch (Ecuador)");
        aryLanguages.Add("es_ES;Spanisch (Spanien)");
        aryLanguages.Add("es_GT;Spanisch (Guatemala)");
        aryLanguages.Add("es_HN;Spanisch (Honduras)");
        aryLanguages.Add("es_MX;Spanisch (Mexiko)");
        aryLanguages.Add("es_NI;Spanisch (Nicaragua)");
        aryLanguages.Add("es_PA;Spanisch (Panama)");
        aryLanguages.Add("es_PE;Spanisch (Peru)");
        aryLanguages.Add("es_PR;Spanisch (Puerto Rico)");
        aryLanguages.Add("es_PY;Spanisch (Paraguay)");
        aryLanguages.Add("es_SV;Spanisch (El Salvador)");
        aryLanguages.Add("es_UY;Spanisch (Uruguay)");
        aryLanguages.Add("es_VE;Spanisch (Venezuela)");
        aryLanguages.Add("et_EE;Estnisch");
        aryLanguages.Add("fa_IR;Persisch");
        aryLanguages.Add("fi_FI;Finnisch");
        aryLanguages.Add("fo_FO;Färöisch");
        aryLanguages.Add("fr_BE;Französisch (Belgien)");
        aryLanguages.Add("fr_CA;Französisch (Kanada)");
        aryLanguages.Add("fr_FR;Französisch (Frankreich)");
        aryLanguages.Add("he_IL;Hebräisch");
        aryLanguages.Add("hi_IN;Hindi");
        aryLanguages.Add("hr_BA;Kroatisch (Bosnien und Herzegowina)");
        aryLanguages.Add("hr_HR;Kroatisch");
        aryLanguages.Add("hu_HU;Ungarisch");
        aryLanguages.Add("id_ID;Indonesisch");
        aryLanguages.Add("is_IS;Isländisch");
        aryLanguages.Add("it_IT;Italienisch (Italien)");
        aryLanguages.Add("ja_JP;Japanisch");
        aryLanguages.Add("ka_GE;Georgisch");
        aryLanguages.Add("kk_KZ;Kasachisch");
        aryLanguages.Add("kl_GL;Grönländisch");
        aryLanguages.Add("km_KH;Kambodschanisch");
        aryLanguages.Add("ko_KR;Koreanisch");
        aryLanguages.Add("ky_CY;Kirgisisch (Kyrillisch)");
        aryLanguages.Add("lt_LT;Litauisch");
        aryLanguages.Add("lv_LV;Lettisch");
        aryLanguages.Add("mk_MK;Mazedonisch (FYROM)");
        aryLanguages.Add("ms_BN;Malaiisch (Brunei Darussalam)");
        aryLanguages.Add("ms_MY;Malaiisch (Malaysia)");
        aryLanguages.Add("mt_MT;Maltesisch");
        aryLanguages.Add("my_BU;Burmesisch");
        aryLanguages.Add("nl_BE;Niederländisch (Belgien)");
        aryLanguages.Add("nl_NL;Niederländisch (Niederlande)");
        aryLanguages.Add("no_NO;Norwegisch ");
        aryLanguages.Add("pl_PL;Polnisch");
        aryLanguages.Add("pt_BR;Portugiesisch (Brasilien)");
        aryLanguages.Add("pt_PT;Portugiesisch (Portugal)");
        aryLanguages.Add("ro_RO;Rumänisch");
        aryLanguages.Add("ru_RU;Russisch");
        aryLanguages.Add("sk_SK;Slowakisch");
        aryLanguages.Add("sl_SI;Slowenisch");
        aryLanguages.Add("so_SO;Somalisch");
        aryLanguages.Add("sq_AL;Albanisch");
        aryLanguages.Add("sr_BA;Serbisch (Lateinisch, Bosnien und Herzegowina)");
        aryLanguages.Add("sr_CY;Serbisch (Kyrillisch)");
        aryLanguages.Add("sr_LT;Serbisch (Lateinisch)");
        aryLanguages.Add("ss_SZ;Swasiländisch");
        aryLanguages.Add("su_SD;Sudanesisch");
        aryLanguages.Add("sv_FI;Schwedisch (Finnland)");
        aryLanguages.Add("sv_SE;Schwedisch");
        aryLanguages.Add("sy_SY;Syrisch");
        aryLanguages.Add("th_TH;Thai");
        aryLanguages.Add("tr_TR;Türkisch");
        aryLanguages.Add("uk_UA;Ukrainisch");
        aryLanguages.Add("ur_IN;Urdu (Indien)");
        aryLanguages.Add("ur_PK;Urdu (Pakistan)");
        aryLanguages.Add("uz_CY;Usbekisch (Kyrillisch)");
        aryLanguages.Add("uz_LT;Usbekisch (Lateinisch)");
        aryLanguages.Add("vi_VN;Vietnamesisch");
        aryLanguages.Add("zh_CN;Chinesisch (VR China)");
        aryLanguages.Add("zh_HK;Chinesisch (Hongkong S.A.R.)");
        aryLanguages.Add("zh_MO;Chinesisch (Macao S.A.R.)");
        aryLanguages.Add("zh_SG;Chinesisch (Singapur)");
        aryLanguages.Add("zh_TW;Chinesisch (Taiwan)");
    }


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
        this.label1 = new System.Windows.Forms.Label();
        this.liviLanguages = new System.Windows.Forms.ListView();
        this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.btnCancel = new System.Windows.Forms.Button();
        this.btnOk = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(104, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Sprache auswählen:";
        // 
        // liviLanguages
        // 
        this.liviLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
        this.liviLanguages.FullRowSelect = true;
        this.liviLanguages.GridLines = true;
        this.liviLanguages.HideSelection = false;
        this.liviLanguages.Location = new System.Drawing.Point(15, 25);
        this.liviLanguages.MultiSelect = false;
        this.liviLanguages.Name = "liviLanguages";
        this.liviLanguages.Size = new System.Drawing.Size(300, 140);
        this.liviLanguages.TabIndex = 1;
        this.liviLanguages.UseCompatibleStateImageBehavior = false;
        this.liviLanguages.View = System.Windows.Forms.View.Details;
        this.liviLanguages.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.liviLanguages_ColumnClick);
        this.liviLanguages.DoubleClick += new System.EventHandler(this.liviLanguages_DoubleClick);
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "Kürzel";
        this.columnHeader1.Width = 51;
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Beschreibung";
        this.columnHeader2.Width = 245;
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(195, 171);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(120, 23);
        this.btnCancel.TabIndex = 3;
        this.btnCancel.Text = "Abbrechen";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnOk
        // 
        this.btnOk.Location = new System.Drawing.Point(69, 171);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(120, 23);
        this.btnOk.TabIndex = 2;
        this.btnOk.Text = "OK";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // SelectLanguage
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(329, 202);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.liviLanguages);
        this.Controls.Add(this.label1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "SelectLanguage";
        this.ShowInTaskbar = false;
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "### - SelectLanguage";
        this.Load += new System.EventHandler(this.SelectProjectLanguage_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    public SelectLanguage()
    {
        InitializeComponent();
    }

    #endregion

    [DeclareAction("SelectLanguage")]
    public void SelectProjectLanguageVoid(string DialogName, ref string Language)
    {
        SelectLanguage fSelectProjectLanguage = new SelectLanguage();
        fSelectProjectLanguage.Tag = Language;
        fSelectProjectLanguage.Text = DialogName + " - SelectLanguage";
        fSelectProjectLanguage.ShowDialog();
        Language = fSelectProjectLanguage.Tag.ToString();
    }

    public void SelectProjectLanguage_Load(object sender, System.EventArgs e)
    {
        // Add all EPLAN languages
        AddLanguages();

        // Choose which language-type
        liviLanguages.SuspendLayout();
        string ActionReturnParameterValue = string.Empty;
        switch (this.Tag.ToString())
        {
            case "Project":
                oCLI.Execute("GetProjectLanguages", acc);
                break;

            case "Display":
                oCLI.Execute("GetDisplayLanguages", acc);
                break;

            default:
                this.Tag = "FALSE";
                this.Close();
                return;
        }
        acc.GetParameter("LANGUAGELIST", ref ActionReturnParameterValue);

        // Add Languages
        string[] ProjectLanguages = ActionReturnParameterValue.Split(';');
        foreach (string language in ProjectLanguages)
        {
            foreach (string allLanguages in aryLanguages)
            {
                string[] liviValues = allLanguages.Split(';');
                if (liviValues[0].Equals(language))
                {
                    ListViewItem livi = new ListViewItem();
                    livi.Text = liviValues[0];
                    livi.SubItems.Add(liviValues[1]);
                    liviLanguages.Items.Add(livi);
                    break;
                }
            }
        }

        liviLanguages.Select();
        liviLanguages.Items[0].Selected = true;
        liviLanguages.ResumeLayout();

    }

    public void btnCancel_Click(object sender, System.EventArgs e)
    {
        this.Tag = "FALSE";
        this.Close();
    }

    public void btnOk_Click(object sender, System.EventArgs e)
    {
        if (liviLanguages.SelectedItems.Count > 0)
        {
            this.Tag = liviLanguages.SelectedItems[0].Text;
        }
        this.Close();
    }

    public void liviLanguages_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        this.liviLanguages.ListViewItemSorter = new ListViewItemComparer(e.Column);
        liviLanguages.Sort();
    }

    private void liviLanguages_DoubleClick(object sender, EventArgs e)
    {
        if (liviLanguages.SelectedItems.Count > 0)
        {
            this.Tag = liviLanguages.SelectedItems[0].Text;
        }
        this.Close();
    }


}

