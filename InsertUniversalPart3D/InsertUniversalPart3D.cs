using System.IO;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.InsertUniversalPart3D
{
    public class frmInsertUniversalPart3D : Form
    {
        public string MacroFileNameCabinetPart = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
            "InsertUniversalPart3D", "Macros", "CabinetPart.ema");

        public string MacroFileNamePartPlacement = Path.Combine(PathMap.SubstitutePath("$(MD_SCRIPTS)"),
            "InsertUniversalPart3D", "Macros", "PartPlacement.ema");

        #region Form-Designer-Code

        private Button btnCancel;
        private Button btnOk;
        private TextBox txtPartnumber;
        private TextBox txtDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbFunctionDef;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private TextBox txtDepth;
        private Label label5;
        private Label label6;

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
            this.txtPartnumber = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFunctionDef = new System.Windows.Forms.ComboBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(86, 187);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPartnumber
            // 
            this.txtPartnumber.Location = new System.Drawing.Point(124, 118);
            this.txtPartnumber.Name = "txtPartnumber";
            this.txtPartnumber.Size = new System.Drawing.Size(208, 20);
            this.txtPartnumber.TabIndex = 14;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 143);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(208, 20);
            this.txtDescription.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Artikelnummer:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tiefe:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Höhe:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Breite:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFunctionDef
            // 
            this.cbFunctionDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunctionDef.FormattingEnabled = true;
            this.cbFunctionDef.Items.AddRange(new object[] {
            "Artikelplatzierung, normales Bauteil",
            "Schrankbauteil, allgemein"});
            this.cbFunctionDef.Location = new System.Drawing.Point(124, 88);
            this.cbFunctionDef.Name = "cbFunctionDef";
            this.cbFunctionDef.Size = new System.Drawing.Size(208, 21);
            this.cbFunctionDef.TabIndex = 13;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(124, 9);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ShortcutsEnabled = false;
            this.txtWidth.Size = new System.Drawing.Size(208, 20);
            this.txtWidth.TabIndex = 10;
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWidth_KeyPress);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(124, 36);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShortcutsEnabled = false;
            this.txtHeight.Size = new System.Drawing.Size(208, 20);
            this.txtHeight.TabIndex = 11;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(124, 62);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.ShortcutsEnabled = false;
            this.txtDepth.Size = new System.Drawing.Size(208, 20);
            this.txtDepth.TabIndex = 12;
            this.txtDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepth_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bauteilbeschreibung:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Funktionsdefinition:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInsertUniversalPart3D_V2
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 222);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPartnumber);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbFunctionDef);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertUniversalPart3D";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertUniversalPart3D";
            this.Load += new System.EventHandler(this.frmInsertUniversalPart3D_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frmInsertUniversalPart3D()
        {
            InitializeComponent();
        }

        #endregion

        #region EPLAN menu
        [DeclareMenu]
        public void MenuFunction()
        {
            Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
            oMenu.AddMenuItem(
                "Freies Gerät...",
                "InsertUniversalPart3D",
                "Freies Gerät in den Bauraum einfügen...",
                37181,
                1,
                false,
                false
                );
        }
        #endregion

        [DeclareAction("InsertUniversalPart3D")]
        public void InsertUniversalPart3DVoid()
        {
            frmInsertUniversalPart3D frm = new frmInsertUniversalPart3D();
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            #region check_macro_to_use

            string macroFile;
            switch (cbFunctionDef.Text)
            {
                case "Artikelplatzierung, normales Bauteil":
                    macroFile = MacroFileNamePartPlacement;
                    break;
                case "Schrankbauteil, allgemein":
                    macroFile = MacroFileNameCabinetPart;
                    break;
                default:
                    macroFile = MacroFileNameCabinetPart;
                    break;
            }
            #endregion

            #region check_user_entries
            if (txtWidth.Text == string.Empty || txtHeight.Text == string.Empty || txtDepth.Text == string.Empty)
            {
                MessageBox.Show("Die folgenden Eingaben müssen gefüllt sein:\n\n'Breite'\n'Höhe'\n'Tiefe'", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region insert_eplan_macro
            if (File.Exists(macroFile))
            {
                // Read Template
                string newMacro = File.ReadAllText(macroFile);

                // Replace
                newMacro = newMacro.Replace("$(Width)", txtWidth.Text.Replace(",", "."));
                newMacro = newMacro.Replace("$(Hight)", txtHeight.Text.Replace(",", "."));
                newMacro = newMacro.Replace("$(Depth)", txtDepth.Text.Replace(",", "."));
                newMacro = newMacro.Replace("$(Partnumber)", txtPartnumber.Text);
                if (txtPartnumber.Text != string.Empty)
                {
                    newMacro = newMacro.Replace("$(PartnumberCnt)", "1");
                }
                else
                {
                    newMacro = newMacro.Replace("$(PartnumberCnt)", "0");
                }

                newMacro = newMacro.Replace("$(Description)", txtDescription.Text);

                // Macro
                string strMacroPathTemp = PathMap.SubstitutePath("$(TMP)") + @"\" + "InsertUniversalPart3D_TEMP.ema";
                File.WriteAllText(strMacroPathTemp, newMacro);
                ActionCallingContext acc = new ActionCallingContext();
                acc.AddParameter("Name", "XMIaInsertMacro");
                acc.AddParameter("filename", strMacroPathTemp);
                acc.AddParameter("variant", "0");
                new CommandLineInterpreter().Execute("XGedStartInteractionAction", acc);
            }
            else
            {
                MessageBox.Show("Vorlage nicht gefunden:\n" + macroFile, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            Close();
        }

        #region NumTextbox
        private static void NumTextbox(KeyPressEventArgs e)
        {
            if (",.1234567890\b".IndexOf(e.KeyChar.ToString()) < 0)
            {
                e.Handled = true;
            }
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumTextbox(e);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumTextbox(e);
        }

        private void txtDepth_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumTextbox(e);
        }
        #endregion

        private void frmInsertUniversalPart3D_Load(object sender, System.EventArgs e)
        {
            // Standard Werte setzen
            cbFunctionDef.Text = "Schrankbauteil, allgemein";
        }
    }
}