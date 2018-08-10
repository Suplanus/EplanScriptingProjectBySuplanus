using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

public class MultilanguageToolExamples_Settings
{
    [Start]
    public void MultilanguageToolExamples_Settings_Void()
    {
        CommandLineInterpreter oCLI = new CommandLineInterpreter();
        ActionCallingContext acc = new ActionCallingContext();

        oCLI.Execute("XTrSettingsDlgAction"); // Settings DEFAULT

        // Bei Eingabe übersetzen
        #region SetTranslationOnInput
        acc.AddParameter("ACTIVE", "YES"); // parameters: YES, NO
        oCLI.Execute("SetTranslationOnInput", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        // Groß- / Kleinschreibung beachten
        #region SetMatchCase 
        acc.AddParameter("ACTIVE", "YES"); // parameters: YES, NO
        oCLI.Execute("SetMatchCase", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        // Bereits übersetzte Texte verändern
        #region SetChangeTranslatedText
        acc.AddParameter("ACTIVE", "YES"); // parameters: YES, NO
        oCLI.Execute("SetChangeTranslatedText", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        // Manuelle Auswahl bei Mehrfachbedeutungen
        #region SetManualSelectionForMultipleMeanings
        acc.AddParameter("ACTIVE", "YES"); // parameters: YES, NO
        oCLI.Execute("SetManualSelectionForMultipleMeanings", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        // Segment
        #region SetTranslationSegment
        acc.AddParameter("SEGMENT", "ENTIRE ENTRY"); // parameters: WORD, SENTENCE, ENTIRE ENTRY
        oCLI.Execute("SetTranslationSegment", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        // Groß- / Kleinschreibung
        #region SetUpperLowerCase
        acc.AddParameter("TYPE", "ALLUPPERCASE"); // parameters: ACCORDINGTODICTIONARY, ALLUPPERCASE, ALLLOWERCASE, CAPITALIZEFIRSTLETTER
        oCLI.Execute("SetUpperLowerCase", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion

        // Fehlende Übersetzung: Anzeigen
        #region SetShowMissingTranslation
        acc.AddParameter("ACTIVE", "YES"); // parameters: YES, NO
        oCLI.Execute("SetShowMissingTranslation", acc);
        oCLI.Execute("XTrSettingsDlgAction");
        #endregion
    }
}