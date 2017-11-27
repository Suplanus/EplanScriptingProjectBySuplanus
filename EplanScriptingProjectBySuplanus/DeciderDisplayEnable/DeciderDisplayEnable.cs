// DeciderDisplayEnable, Version 1.0.0, vom 25.09.2013
//
// Zeigt alle Unterdrückten Meldungen in einer Liste an
// und ermöglicht durch entfernen der jeweiligen Checkbox
// das wiederanzeigen der unterdrückten Meldung.
//
// Copyright by Frank Schöneck, 2013
// letzte Änderung: Frank Schöneck, 25.09.2013 V1.0.0, -Projektbeginn
//
// für Eplan Electric P8, V2.2 / V2.3
//
using System.Windows.Forms;
using Eplan.EplApi.Scripting;
using Eplan.EplApi.Base;

public partial class frmDeciderDisplayEnable : System.Windows.Forms.Form
{
	private ListView listView1;
	private ColumnHeader Dialog;
	private ColumnHeader Index;
	private Button btnOK;
	private Button btnAbbrechen;

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
			this.listView1 = new System.Windows.Forms.ListView();
			this.Dialog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAbbrechen = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Dialog,
            this.Index});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(319, 202);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// Dialog
			// 
			this.Dialog.Text = "Dialog";
			this.Dialog.Width = 270;
			// 
			// Index
			// 
			this.Index.Text = "Index";
			this.Index.Width = 40;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(141, 226);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(92, 27);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnAbbrechen
			// 
			this.btnAbbrechen.Location = new System.Drawing.Point(239, 226);
			this.btnAbbrechen.Name = "btnAbbrechen";
			this.btnAbbrechen.Size = new System.Drawing.Size(92, 27);
			this.btnAbbrechen.TabIndex = 2;
			this.btnAbbrechen.Text = "Abbrechen";
			this.btnAbbrechen.UseVisualStyleBackColor = true;
			this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
			// 
			// frmDeciderDisplayEnable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 265);
			this.Controls.Add(this.btnAbbrechen);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.listView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeciderDisplayEnable";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Unterdrückte Meldungen";
			this.Load += new System.EventHandler(this.frmDeciderDisplayEnable_Load);
			this.ResumeLayout(false);

	}

	public frmDeciderDisplayEnable()
	{
		InitializeComponent();
	}

	#endregion

	[Start]
	public void Function()
	{
		//Form anzeigen
		frmDeciderDisplayEnable frm = new frmDeciderDisplayEnable();
		frm.ShowDialog();

		return;
	}

	private void frmDeciderDisplayEnable_Load(object sender, System.EventArgs e)
	{
		Settings oSettings = new Settings();
		string sDeciderNotDisplay = string.Empty;
		int iCountDeciderNotDisplay = 0;
		ListViewItem objListViewItem = new ListViewItem();

		if (oSettings.ExistSetting("USER.Decider.NotDisplay"))
		{
			//Anzahl Settings ermitteln
			iCountDeciderNotDisplay = oSettings.GetCountOfValues("USER.Decider.NotDisplay");

			//in ListView einlesen
			for (int n = 0; n < iCountDeciderNotDisplay; n++)
			{
				sDeciderNotDisplay = oSettings.GetStringSetting("USER.Decider.NotDisplay", n);
				objListViewItem = new ListViewItem();
				objListViewItem.Text = sDeciderNotDisplay;
				objListViewItem.Checked = true;
				objListViewItem.SubItems.Add(n.ToString());
				listView1.Items.Add(objListViewItem);
			}
		}
	}

	//Button OK
	private void btnOK_Click(object sender, System.EventArgs e)
	{
		Settings oSettings = new Settings();

		//Setting löschen!
		oSettings.DeleteSetting("USER.Decider.NotDisplay");

		//Setting nach löschen wieder neu anlegen
		oSettings.AddStringSetting("USER.Decider.NotDisplay",
		new string[] { },
		new string[] { }, "DeciderDisplayEnable",
		new string[] { "Default value of DeciderDisplayEnable" },
		ISettings.CreationFlag.Insert);

		int n = 0; //Zähler starten

		//Listview abarbeiten
		foreach (ListViewItem itemRow in listView1.Items)
		{
			if (itemRow.Checked) //wenn Ausgewählt Setting schreiben
			{
				//Setting schreiben
				oSettings.SetStringSetting("USER.Decider.NotDisplay", itemRow.Text, n);
				n++; //Zähler für VAL erhöhen
			}
		}

		//Beenden
		Close();
	}

	//Button Abbrechen
	private void btnAbbrechen_Click(object sender, System.EventArgs e)
	{
		Close();
	}
}