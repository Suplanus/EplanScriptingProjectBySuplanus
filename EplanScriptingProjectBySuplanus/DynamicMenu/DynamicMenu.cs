/*
	NAME....: MenuDemoRemoveEntry
	USAGE...: for EPLAN P8 (v2.09)
	AUTHOR..: S.Benner / BeDaSys
	VERSION.: 2011-05-11
	FUNC....: Demonstriert das dynamische Hinzufügen und Entfernen von Menüeinträgen per Script in EPlan P8
*/
//
using Eplan.EplApi.Scripting;

public class MenueHinzufuegen
{ 	
	// Deklarationen 
	// -------------------------------------------------
	public static uint hndHMenu = new uint(); // Variable für die ID des Hauptmenüs
	public static uint hndMenuEntryL = new uint(); // Variable für die ID des 2ten Eintrages
	public static uint hndMenuEntryR = new uint(); // Variable für die ID des 3ten Eintrages
	public Eplan.EplApi.Gui.Menu DemoHauptMenue = new Eplan.EplApi.Gui.Menu(); // Das Menüobjekt
	//
	// Anlegen der Aktionen für die Menüpunkte
	// -------------------------------------------------
	//
	// Action: Umschalten auf LINKS
	[DeclareAction("actLinks")] 
	public void actLinks() 
	{
		// Meldung ausgeben
		System.Windows.Forms.MessageBox.Show("Schalte um auf LINKS");
		// Menüeintrag "Links" entfernen
		DemoHauptMenue.RemoveMenuItem(hndMenuEntryL);
		// MenüeintragsID auf 0 setzen
		hndMenuEntryL = 0;
		// Menüeintrag "Rechts" hinzufügen falls er nicht vorhanden ist
		if (hndMenuEntryR == 0) {
			hndMenuEntryR = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Rechts", //Eintragsname,
				"actRechts", // Eintragsaktion,
				"Hiermit schalte ich um auf Rechts",//  Statustext,
				hndHMenu, //  Menü-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
	}
	//
	// Umschalten auf RECHTS
	[DeclareAction("actRechts")] 
	public void actRechts()	
	{
		// Meldung ausgeben
		System.Windows.Forms.MessageBox.Show("Schalte um auf RECHTS");
		// Menüeintrag "Rechts" entfernen
		DemoHauptMenue.RemoveMenuItem(hndMenuEntryR);
		// MenüeintragsID auf 0 setzen
		hndMenuEntryR = 0;
		// Menüeintrag "Links" hinzufügen falls er nicht vorhanden ist
		if (hndMenuEntryL == 0) {
			hndMenuEntryL = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Links", //Eintragsname,
				"actLinks", // Eintragsaktion,
				"Hiermit schalte ich um auf LINKS",//  Statustext,
				hndHMenu, //  Menü-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
	}
	//
	// Umschalten auf Links & Rechts
	[DeclareAction("actLinksRechts")]
	public void actLinksRechts()	
	{
		// Meldung ausgeben
		System.Windows.Forms.MessageBox.Show("Schalte um auf Links & Rechts");
		// Menüeintrag "Links" hinzufügen falls er nicht vorhanden ist
		if (hndMenuEntryL == 0) {
			hndMenuEntryL = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Links", //Eintragsname,
				"actLinks", // Eintragsaktion,
				"Hiermit schalte ich um auf LINKS",//  Statustext,
				hndHMenu, //  Menü-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
		// Menüeintrag "Rechts" hinzufügen falls er nicht vorhanden ist
		if (hndMenuEntryR == 0) {
			hndMenuEntryR = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Rechts", //Eintragsname,
				"actRechts", // Eintragsaktion,
				"Hiermit schalte ich um auf Rechts",//  Statustext,
				hndHMenu, //  Menü-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
	}
	//	
	// Anlegen des Menüs
	// -------------------------------------------------
	[DeclareMenu]
	public void MenuFunction()
	{
		// Hauptmenü inkl Eintrag "Links und Rechts"
		hndHMenu = DemoHauptMenue.AddMainMenu(	// .AddMainMenu(
			"Demo L/R Umschaltung",	// Menüname,
			"Fenster", //  RechtsNebenMenüName, 
			"Links und Rechts", // Eintragsname,
			"actLinksRechts", // Eintragsaktion,
			"Umschaltung auf Links & Rechts", // Statustext,
			1); //Eintragsposition(1= hinten bzw 0= vorne)		
		hndMenuEntryL = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
			"Links", //Eintragsname,
			"actLinks", // Eintragsaktion,
			"Hiermit schalte ich um auf LINKS",//  Statustext,
			hndHMenu, //  Menü-ID,
			1, // Eintragsposition(1= hinten bzw 0= vorne),
			false, // TrennerDavor,
			false); // TrennerDanach);
		hndMenuEntryR = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
			"Rechts", //Eintragsname,
			"actRechts", // Eintragsaktion,
			"Hiermit schalte ich um auf Rechts",//  Statustext,
			hndHMenu, //  Menü-ID,
			1, // Eintragsposition(1= hinten bzw 0= vorne),
			false, // TrennerDavor,
			false); // TrennerDanach);
	}
}
