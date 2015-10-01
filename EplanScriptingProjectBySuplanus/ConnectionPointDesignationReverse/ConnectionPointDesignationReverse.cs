// ConnectionPointDesignationReverse.cs
//
// Erweitert das Kontextmenü von 'Anschlussbezeichnungen',
// im Dialog 'Eigenschaften (Schaltzeichen): Allgemeines Betriebsmittel',
// um den Menüpunkt 'Reihenfolge drehen'.
// Es wird die Eingabe im Feld 'Anschlussbezeichnungen' automatisch gedreht.
//
// Copyright by Frank Schöneck, 2015
// letzte Änderung:
// V1.0.0, 04.03.2015, Frank Schöneck, Projektbeginn
//
// für Eplan Electric P8, ab V2.3

using System;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class ConnectionPointDesignationReverse
{

	[DeclareMenu]
	public void ProjectCopyContextMenu()
	{
		//Context-Menüeintrag
		string menuText = getMenuText();
		Eplan.EplApi.Gui.ContextMenu oContextMenu = new Eplan.EplApi.Gui.ContextMenu();
		Eplan.EplApi.Gui.ContextMenuLocation oContextMenuLocation = new Eplan.EplApi.Gui.ContextMenuLocation("XDTDataDialog", "4006");
		oContextMenu.AddMenuItem(oContextMenuLocation, menuText, "ConnectionPointDesignationReverse", true, false);
	}

	[DeclareAction("ConnectionPointDesignationReverse")]
	public void Action()
	{
		try
		{
			string sSourceText = string.Empty;
			string sReturnText = string.Empty;
			string EplanCRLF = "¶";

			//Zwischenablage leeren
			System.Windows.Forms.Clipboard.Clear();

			//Zwischenablage füllen
			CommandLineInterpreter oCLI = new CommandLineInterpreter();
			oCLI.Execute("GfDlgMgrActionIGfWind /function:SelectAll"); // Alles markieren
			oCLI.Execute("GfDlgMgrActionIGfWind /function:Copy"); // Kopieren

			if (System.Windows.Forms.Clipboard.ContainsText())
			{
				sSourceText = System.Windows.Forms.Clipboard.GetText();
				if (sSourceText != string.Empty)
				{
					string[] sAnschlussbezeichnungen = sSourceText.Split(new string[] { EplanCRLF }, StringSplitOptions.None);

					if (sAnschlussbezeichnungen.Length > 2) // Mehr als 2 Anschlussbezeichnungen
					{
						Decider eDecision = new Decider();
						EnumDecisionReturn eAnswer = eDecision.Decide(EnumDecisionType.eYesNoDecision,
							"Sollen die Anschlussbezeichnungen paarweise gedreht werden?",
							"Reihenfolge drehen",
							EnumDecisionReturn.eYES,
							EnumDecisionReturn.eYES,
							"ConnectionPointDesignationReverse",
							true,
							EnumDecisionIcon.eQUESTION);

						if (eAnswer == EnumDecisionReturn.eYES)
						{
							// String neu aufbauen
							for (int i = 0; i < sAnschlussbezeichnungen.Length; i = i + 2)
							{
								sReturnText += sAnschlussbezeichnungen[i + 1] + EplanCRLF + sAnschlussbezeichnungen[i] + EplanCRLF;
							}
						}
						else
						{
							// String Array drehen
							Array.Reverse(sAnschlussbezeichnungen);

							// String neu aufbauen
							foreach (string sAnschluss in sAnschlussbezeichnungen)
							{
								sReturnText += sAnschluss + EplanCRLF;
							}
						}
					}
					else // Nur 2 Anschlussbezeichnungen
					{
						// String Array drehen
						Array.Reverse(sAnschlussbezeichnungen);

						// String neu aufbauen
						foreach (string sAnschluss in sAnschlussbezeichnungen)
						{
							sReturnText += sAnschluss + EplanCRLF;
						}
					}

					// letztes Zeichen wieder entfernen
					sReturnText = sReturnText.Substring(0, sReturnText.Length - 1);

					//Zwischenablage einfügen
					System.Windows.Forms.Clipboard.SetText(sReturnText);
					oCLI.Execute("GfDlgMgrActionIGfWind /function:SelectAll"); // Alles markieren
					oCLI.Execute("GfDlgMgrActionIGfWindDelete"); // Löschen
					oCLI.Execute("GfDlgMgrActionIGfWind /function:Paste"); // Einfügen
				}
			}
		}
		catch (System.Exception ex)
		{
			MessageBox.Show(ex.Message, "Reihenfolge drehen, Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		return;
	}

	// Returns the menueitem text in the gui langueage if available.
	private string getMenuText()
	{
		MultiLangString muLangMenuText = new MultiLangString();
		muLangMenuText.SetAsString(
			"de_DE@Reihenfolge drehen;" +
			"en_US@rotate order;"
			);

		ISOCode guiLanguage = new Languages().GuiLanguage;
		return muLangMenuText.GetString((ISOCode.Language)guiLanguage.GetNumber());
	}

}
