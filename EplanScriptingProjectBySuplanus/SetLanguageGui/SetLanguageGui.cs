using System;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class SetLanguageGui : System.Windows.Forms.Form
{
    public CommandLineInterpreter oCLI = new CommandLineInterpreter();
    public ActionCallingContext acc = new ActionCallingContext();

    #region LanguageMapping
    public string[] EplanLanguageList = new[]
                                            {
                                                "af_ZA;Afrikaans",
                                                "am_AM;Armenisch",
                                                "ar_AE;Arabisch (Vereinigte Arabische Emirate)",
                                                "ar_BH;Arabisch (Bahrein)",
                                                "ar_DZ;Arabisch (Algerien)",
                                                "ar_EG;Arabisch (Ägypten)",
                                                "ar_IQ;Arabisch (Irak)",
                                                "ar_JO;Arabisch (Jordanien)",
                                                "ar_KW;Arabisch (Kuwait)",
                                                "ar_LB;Arabisch (Libanon)",
                                                "ar_LY;Arabisch (Libyen)",
                                                "ar_MA;Arabisch (Marokko)",
                                                "ar_OM;Arabisch (Oman)",
                                                "ar_QA;Arabisch (Katar)",
                                                "ar_SA;Arabisch (Saudi-Arabien)",
                                                "ar_SY;Arabisch (Syrien)",
                                                "ar_TN;Arabisch (Tunesien)",
                                                "ar_YE;Arabisch (Jemen)",
                                                "bg_BG;Bulgarisch",
                                                "bs_BA;Bosnisch (Lateinisch, Bosnien und Herzegowina)",
                                                "ca_ES;Katalanisch",
                                                "cs_CZ;Tschechisch",
                                                "da_DK;Dänisch",
                                                "de_DE;Deutsch (Deutschland)",
                                                "dz_BT;Bhutani",
                                                "el_GR;Griechisch",
                                                "en_AU;Englisch (Australien)",
                                                "en_CA;Englisch (Kanada)",
                                                "en_EN;Englisch (Großbritannien)",
                                                "en_IE;Englisch (Irland)",
                                                "en_NZ;Englisch (Neuseeland)",
                                                "en_US;Englisch (USA)",
                                                "en_ZA;Englisch (Südafrika)",
                                                "es_AR;Spanisch (Argentinien)",
                                                "es_BO;Spanisch (Bolivien)",
                                                "es_CL;Spanisch (Chile)",
                                                "es_CO;Spanisch (Kolumbien)",
                                                "es_CR;Spanisch (Costa Rica)",
                                                "es_DO;Spanisch (Dominikanische Republik)",
                                                "es_EC;Spanisch (Ecuador)",
                                                "es_ES;Spanisch (Spanien)",
                                                "es_GT;Spanisch (Guatemala)",
                                                "es_HN;Spanisch (Honduras)",
                                                "es_MX;Spanisch (Mexiko)",
                                                "es_NI;Spanisch (Nicaragua)",
                                                "es_PA;Spanisch (Panama)",
                                                "es_PE;Spanisch (Peru)",
                                                "es_PR;Spanisch (Puerto Rico)",
                                                "es_PY;Spanisch (Paraguay)",
                                                "es_SV;Spanisch (El Salvador)",
                                                "es_UY;Spanisch (Uruguay)",
                                                "es_VE;Spanisch (Venezuela)",
                                                "et_EE;Estnisch",
                                                "fa_IR;Persisch",
                                                "fi_FI;Finnisch",
                                                "fo_FO;Färöisch",
                                                "fr_BE;Französisch (Belgien)",
                                                "fr_CA;Französisch (Kanada)",
                                                "fr_FR;Französisch (Frankreich)",
                                                "he_IL;Hebräisch",
                                                "hi_IN;Hindi",
                                                "hr_BA;Kroatisch (Bosnien und Herzegowina)",
                                                "hr_HR;Kroatisch",
                                                "hu_HU;Ungarisch",
                                                "id_ID;Indonesisch",
                                                "is_IS;Isländisch",
                                                "it_IT;Italienisch (Italien)",
                                                "ja_JP;Japanisch",
                                                "ka_GE;Georgisch",
                                                "kk_KZ;Kasachisch",
                                                "kl_GL;Grönländisch",
                                                "km_KH;Kambodschanisch",
                                                "ko_KR;Koreanisch",
                                                "ky_CY;Kirgisisch (Kyrillisch)",
                                                "lt_LT;Litauisch",
                                                "lv_LV;Lettisch",
                                                "mk_MK;Mazedonisch (FYROM)",
                                                "ms_BN;Malaiisch (Brunei Darussalam)",
                                                "ms_MY;Malaiisch (Malaysia)",
                                                "mt_MT;Maltesisch",
                                                "my_BU;Burmesisch",
                                                "nl_BE;Niederländisch (Belgien)",
                                                "nl_NL;Niederländisch (Niederlande)",
                                                "no_NO;Norwegisch ",
                                                "pl_PL;Polnisch",
                                                "pt_BR;Portugiesisch (Brasilien)",
                                                "pt_PT;Portugiesisch (Portugal)",
                                                "ro_RO;Rumänisch",
                                                "ru_RU;Russisch",
                                                "sk_SK;Slowakisch",
                                                "sl_SI;Slowenisch",
                                                "so_SO;Somalisch",
                                                "sq_AL;Albanisch",
                                                "sr_BA;Serbisch (Lateinisch, Bosnien und Herzegowina)",
                                                "sr_CY;Serbisch (Kyrillisch)",
                                                "sr_LT;Serbisch (Lateinisch)",
                                                "ss_SZ;Swasiländisch",
                                                "su_SD;Sudanesisch",
                                                "sv_FI;Schwedisch (Finnland)",
                                                "sv_SE;Schwedisch",
                                                "sy_SY;Syrisch",
                                                "th_TH;Thai",
                                                "tr_TR;Türkisch",
                                                "uk_UA;Ukrainisch",
                                                "ur_IN;Urdu (Indien)",
                                                "ur_PK;Urdu (Pakistan)",
                                                "uz_CY;Usbekisch (Kyrillisch)",
                                                "uz_LT;Usbekisch (Lateinisch)",
                                                "vi_VN;Vietnamesisch",
                                                "zh_CN;Chinesisch (VR China)",
                                                "zh_HK;Chinesisch (Hongkong S.A.R.)",
                                                "zh_MO;Chinesisch (Macao S.A.R.)",
                                                "zh_SG;Chinesisch (Singapur)",
                                                "zh_TW;Chinesisch (Taiwan)"
                                            };
    #endregion

    #region Vom Windows Form-Designer generierter Code

    private ListView liviLanguages;
    private ColumnHeader columnHeader2;
    private Button btnCancel;
    private Button btnOk;
    private ColumnHeader columnHeader1;

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
        this.liviLanguages = new System.Windows.Forms.ListView();
        this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.btnCancel = new System.Windows.Forms.Button();
        this.btnOk = new System.Windows.Forms.Button();
        this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.SuspendLayout();
        // 
        // liviLanguages
        // 
        this.liviLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
        this.liviLanguages.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.liviLanguages.FullRowSelect = true;
        this.liviLanguages.GridLines = true;
        this.liviLanguages.Location = new System.Drawing.Point(12, 12);
        this.liviLanguages.MultiSelect = false;
        this.liviLanguages.Name = "liviLanguages";
        this.liviLanguages.Size = new System.Drawing.Size(390, 219);
        this.liviLanguages.TabIndex = 0;
        this.liviLanguages.UseCompatibleStateImageBehavior = false;
        this.liviLanguages.View = System.Windows.Forms.View.Details;
        this.liviLanguages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.liviLanguages_MouseDoubleClick);
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Language";
        this.columnHeader2.Width = 70;
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(302, 237);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(100, 23);
        this.btnCancel.TabIndex = 1;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnOk
        // 
        this.btnOk.Location = new System.Drawing.Point(196, 237);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(100, 23);
        this.btnOk.TabIndex = 2;
        this.btnOk.Text = "OK";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "Description";
        this.columnHeader1.Width = 310;
        // 
        // SetLanguageGui
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(414, 272);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.liviLanguages);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "SetLanguageGui";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "SetLanguageGui";
        this.Load += new System.EventHandler(this.SetLanguageGui_Load);
        this.ResumeLayout(false);

    }

    public SetLanguageGui()
    {
        InitializeComponent();
    }

    #endregion

    [DeclareAction("SetLanguageGui")]
    public void Function()
    {
        SetLanguageGui frm = new SetLanguageGui();
        frm.ShowDialog();
        return;
    }

    private void SetLanguageGui_Load(object sender, System.EventArgs e)
    {
        string ActionReturnParameterValue = string.Empty;

        // Languagelist
        oCLI.Execute("GetProjectLanguages", acc);
        acc.GetParameter("LANGUAGELIST", ref ActionReturnParameterValue);
        string[] ProjectLanguages = ActionReturnParameterValue.Split(';');

        // VariableLanguage
        oCLI.Execute("GetVariableLanguage", acc);
        acc.GetParameter("LANGUAGELIST", ref ActionReturnParameterValue);
        string VariableLanguage = ActionReturnParameterValue;

        // Add languages
        foreach (string CurrentLanguage in ProjectLanguages)
        {
            if (CurrentLanguage != "")
            {
                ListViewItem liviItem = new ListViewItem();

                // Check if current language
                if (CurrentLanguage.Equals(VariableLanguage))
                {
                    liviItem.Selected = true;
                }

                liviItem.Text = CurrentLanguage;

                // LanguageMapping
                foreach(string line in EplanLanguageList)
                {
                    if(line.StartsWith(CurrentLanguage))
                    {
                        if (line.Split(';').Length > 1) liviItem.SubItems.Add(line.Split(';')[1]);
                    }
                }
                liviLanguages.Items.Add(liviItem);
            }
        }

        // Sort & resize
        liviLanguages.Sorting = SortOrder.Ascending;
        liviLanguages.Sort();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void liviLanguages_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        SetLanguage();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        SetLanguage();
    }

    private void SetLanguage()
    {
        if (liviLanguages.SelectedItems.Count > 0)
        {
            string CurrentLanguage = liviLanguages.SelectedItems[0].Text;

            // Bug
            //acc.AddParameter("varLANGUAGE", CurrentLanguage);
            //acc.AddParameter("dispLANGUAGE", CurrentLanguage);
            //oCLI.Execute("ChangeLanguage", acc);
            oCLI.Execute("ChangeLanguage /varLANGUAGE:" + CurrentLanguage + " /dispLANGUAGE:\"" + CurrentLanguage + ";\"");

            this.Close();
        }
        else
        {
            MessageBox.Show("Keine Sprache gewählt");
        }

    }




}

