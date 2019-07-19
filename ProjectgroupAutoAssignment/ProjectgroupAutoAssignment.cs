// Projectgroup_Auto_Assignment.cs
// Automatisches vergeben der Projektgruppe
//
// Beim öffnen eines Projektes wird dieses einer Projektgruppe zugeordnet,
// beim schließen des Projektes wird diese Zuordnung wieder entfernt
// Dafür muss in den Einstellung unter 'Benutzer>Darstellung>Projektgruppen (Definition)' die 'Farbe aktiviert' werden.
//
// Copyright by Frank Schöneck, 2019
// letzte Änderung:
// V1.0.0, 04.07.2019, Frank Schöneck, Projektbeginn
//
// für Eplan Electric P8, ab V2.8

using System;
using System.Windows.Forms;
using System.Xml;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class ProjectgroupAutoAssignment
{
  public string SettingsPath = "USER.Scripts.ProjectGroups.Groups";

  //Skript wird geladen
  [DeclareRegister]
  public void OnRegisterScript()
  {
    SettingsWrite();
  }

  //Skript wird entladen
  [DeclareUnregister]
  public void OnUnRegisterScript()
  {
    SettingsDelete();
  }

  //Projekt wird geöffnet
  [DeclareEventHandler("Eplan.EplApi.OnPostOpenProject")]
  public void MyEventHandlerFunction(IEventParameter iEventParameter)
  {
    try
    {
      EventParameterString oEventParameterString = new EventParameterString(iEventParameter);
      string sProjectname = oEventParameterString.String;

      //Projekt Ordner ermitteln
      var suffix = ".elk";
      string sProjectFolder = sProjectname.Substring(0, sProjectname.Length - suffix.Length);
      sProjectFolder = sProjectFolder + ".edb";

      //Wenn Makroprojekt, dann abbrechen
      string sProjectart = string.Empty;
      GetProjectProperty(sProjectFolder, 10902, "de_DE", out sProjectart);
      if (sProjectart == "2")
      {
        return;
      }

      //Einstellungen durchgehen
      Settings oSettings = new Settings();
      for (int i = 1; i <= 5; i++)
      {
        if (i == 2)
        {
          continue; // Projektgruppe 2 auslassen, da diese für Makroprojekte vorgesehen ist
        }
        string sProjectgroup = oSettings.GetStringSetting(SettingsPath, i);
        if (sProjectgroup == "frei")
        {
          //Einstellung setzen
          oSettings.SetStringSetting(SettingsPath, sProjectname, i);

          //Projekteinstellung der Projektgruppe setzen
          ActionCallingContext acctranslate = new ActionCallingContext();
          CommandLineInterpreter CLItranslate = new CommandLineInterpreter();
          acctranslate.AddParameter("Project", sProjectname);
          acctranslate.AddParameter("set", "SettingsMasterDialog.ProjectGroup.ColorMode");
          acctranslate.AddParameter("value", i.ToString());
          acctranslate.AddParameter("index", "0");
          CLItranslate.Execute("XAfActionSettingProject", acctranslate);

          //Schleife verlassen
          break;
        }
      }
    }
    catch (InvalidCastException exc)
    {
      new Decider().Decide(EnumDecisionType.eOkDecision,
                           exc.Message,
                           "OnPostOpenProject, Fehler",
                           EnumDecisionReturn.eOK,
                           EnumDecisionReturn.eOK,
                           string.Empty,
                           false,
                           EnumDecisionIcon.eFATALERROR);
    }
  }

  //Projekt wird geschlossen
  [DeclareEventHandler("Eplan.EplApi.OnUserPreCloseProject")]
  public void Test3Void(IEventParameter iEventParameter)
  {
    try
    {
      EventParameterString oEventParameterString = new EventParameterString(iEventParameter);
      string sProjectname = oEventParameterString.String;

      //Projekt Ordner ermitteln
      var suffix = ".elk";
      string sProjectFolder = sProjectname.Substring(0, sProjectname.Length - suffix.Length);
      sProjectFolder = sProjectFolder + ".edb";

      //Wenn Makroprojekt, dann abbrechen
      string sProjectart = string.Empty;
      GetProjectProperty(sProjectFolder, 10902, "de_DE", out sProjectart);
      if (sProjectart == "2")
      {
        return;
      }

      //Einstellungen durchgehen
      Settings oSettings = new Settings();
      for (int i = 1; i <= 5; i++)
      {
        if (i == 2)
        {
          continue; // Projektgruppe 2 auslassen, da diese für Makroprojekte vorgesehen ist
        }
        string sProjectgroup = oSettings.GetStringSetting(SettingsPath, i);
        if (sProjectgroup == sProjectname)
        {
          //Einstellung setzen
          oSettings.SetStringSetting(SettingsPath, "frei", i);

          //Projekteinstellung der Projektgruppe setzen
          ActionCallingContext acctranslate = new ActionCallingContext();
          CommandLineInterpreter CLItranslate = new CommandLineInterpreter();
          acctranslate.AddParameter("Project", sProjectname);
          acctranslate.AddParameter("set", "SettingsMasterDialog.ProjectGroup.ColorMode");
          acctranslate.AddParameter("value", "0");
          acctranslate.AddParameter("index", "0");
          CLItranslate.Execute("XAfActionSettingProject", acctranslate);

          //Schleife verlassen
          break;
        }
      }
    }
    catch (InvalidCastException exc)
    {
      new Decider().Decide(EnumDecisionType.eOkDecision,
                           exc.Message,
                           "OnUserPreCloseProject, Fehler",
                           EnumDecisionReturn.eOK,
                           EnumDecisionReturn.eOK,
                           string.Empty,
                           false,
                           EnumDecisionIcon.eFATALERROR);
    }
  }

  //Einstellungen speichern
  public void SettingsWrite()
  {
    Settings oSettings = new Settings();
    for (int i = 1; i <= 5; i++)
    {
      if (i == 2)
      {
        continue; // Projektgruppe 2 auslassen, da diese für Makroprojekte vorgesehen ist
      }
      if (!oSettings.ExistSetting(SettingsPath))
      {
        oSettings.AddStringSetting(SettingsPath,
                                   new string[] {},
                                   new string[] {},
                                   ISettings.CreationFlag.Insert);
      }
      oSettings.SetStringSetting(SettingsPath, "frei", i);
    }
  }

  //Einstellungen löschen
  public void SettingsDelete()
  {
    Settings oSettings = new Settings();
    if (oSettings.ExistSetting(SettingsPath))
    {
      oSettings.DeleteSetting(SettingsPath);
      new Decider().Decide(EnumDecisionType.eOkDecision,
                           "Die Einstellungen [" + SettingsPath + "] wurden gelöscht.",
                           "Projectgroups, Einstellungen löschen",
                           EnumDecisionReturn.eOK,
                           EnumDecisionReturn.eOK,
                           string.Empty,
                           false,
                           EnumDecisionIcon.eINFORMATION);
    }
    else
    {
      new Decider().Decide(EnumDecisionType.eOkDecision,
                           "Die Einstellungen wurden nicht gefunden!",
                           "Projectgroups, Einstellungen löschen",
                           EnumDecisionReturn.eOK,
                           EnumDecisionReturn.eOK,
                           string.Empty,
                           false,
                           EnumDecisionIcon.eFATALERROR);
    }
  }

  //Projekteigenschaft auslesen (wird aus Projektinfo.xml ausgelesen)
  public bool GetProjectProperty(
    string strProjectPath, int intPropertyID, string strLanguage, out string strProjectProperty)
  {
    string strXmlFilename = strProjectPath + @"\Projectinfo.xml"; // Pfad zur Infodatei des Eplan-Projektes
    string strReadProperty = string.Empty; // Variable fürs Auslesen der Projekteigenschaft
    bool bolReadSuccessful = false; // Variable Projekteigenschaft wurde gefunden

    // Prüfen ob Projekt ausgewählt wurde:
    if (strProjectPath == "")
    {
      // Fehlermeldung
      MessageBox.Show("Fehler: Es wurde kein Eplan-Projekt ausgewählt.",
                      "GetProjectProperty", MessageBoxButtons.OK, MessageBoxIcon.Error);

      strProjectProperty = string.Empty; //Leerstring zurückgeben
      return false; // Rückgabe Fehler
    }

    // Prüfen ob Übergabeparameter gültig (Werte zu klein oder zu groß):
    if ((intPropertyID < 1) | (intPropertyID > 99999))
    {
      // Fehlermeldung
      MessageBox.Show("Fehler: Übergabeparameter \"intPropertyID\" enthält ungültige Werte: " + intPropertyID,
                      "GetProjectProperty", MessageBoxButtons.OK, MessageBoxIcon.Error);

      strProjectProperty = string.Empty; //Leerstring zurückgeben
      return false; // Rückgabe Fehler
    }

    // Text aus Projectinfo.xml des Projektes auslesen
    XmlTextReader objReader = new XmlTextReader(strXmlFilename); // Diese Datei lesen

    while (objReader.Read()) // Nächsten Knoten lesen
    {
      if (objReader.HasAttributes) // Nur wenn Attribute vorhanden
      {
        while (objReader.MoveToNextAttribute()) // Zum nächsten Attribut wechseln
        {
          if (objReader.Name == "id")
          {
            if (objReader.Value == intPropertyID.ToString())
            {
              strReadProperty = objReader.ReadString();
              bolReadSuccessful = true; // Projekteigenschaft wurde gefunden
            }
          }
        }
      }
    }
    objReader.Close(); // Datei wieder schließen (sonst bleibt diese gesperrt)

    if (!bolReadSuccessful) // Eigenschaft wurde nicht gefunden
    {
      // Fehlermeldung
      MessageBox.Show("Fehler: Die Projekteigenschaft \"" + intPropertyID + "\" wurde nicht gefunden!",
                      "GetProjectProperty", MessageBoxButtons.OK, MessageBoxIcon.Error);

      strProjectProperty = string.Empty; //Leerstring zurückgeben
      return false; // Rückgabe Fehler
    }

    // Gegebenenfalls Sprache aus Multilanguage-String herausfiltern...
    if (strLanguage != "all") // Nur wenn Sprachfilter gewünscht
    {
      MultiLangString objMLText = new MultiLangString(); // Multi Language String zur Bearbeitung
      objMLText.SetAsString(strReadProperty);

      ISOCode.Language enuLanguage = ISOCode.Language.L___; // Variable für den ISOCode der gewählten Sprache

      if (!Enum.TryParse("L_" + strLanguage, out enuLanguage)) // Wandlung der Sprachkennung nicht erfolgreich? 
      {
        // Fehlermeldung 
        MessageBox.Show("Fehler: Übergabeparameter \"strLanguage\" enthält ungültige Werte: " + strLanguage,
                        "GetProjectProperty", MessageBoxButtons.OK, MessageBoxIcon.Error);

        strProjectProperty = string.Empty; //Leerstring zurückgeben
        return false; // Rückgabe Fehler
      }

      strReadProperty = objMLText.GetStringToDisplay(enuLanguage); // Einzelne Sprache auslesen
    }

    // Erfolgreich gelesene Eigenschaft zurückgeben...
    strProjectProperty = strReadProperty;
    return true; // Rückgabe OK
  }
}