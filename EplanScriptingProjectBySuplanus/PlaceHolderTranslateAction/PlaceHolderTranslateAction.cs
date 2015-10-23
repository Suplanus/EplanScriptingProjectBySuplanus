// PlaceHolderTranslateAction.cs
//
// Erweitert das Kontextmenü vom Platzhalterobjekt (Reiter Werte) um den Menüpunkt "Übersetzen"
// und um den Menüpunkt "Übersetzungen entfernen"
//
// Copyright by Frank Schöneck, 2015
// letzte Änderung:
// V1.0.0, 23.10.2015, Frank Schöneck, Projektbeginn
//
// für Eplan Electric P8, ab V2.5
//

using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.PlaceHolderTranslateAction
{
    public class PlaceHolderTranslate
    {
        [DeclareMenu]
        public void PlaceHolderTranslateContextMenu()
        {
            //Context-Menüeintrag (hier im Platzhalterobjekt)
            Eplan.EplApi.Gui.ContextMenu oContextMenu = new Eplan.EplApi.Gui.ContextMenu();
            Eplan.EplApi.Gui.ContextMenuLocation oContextMenuLocation = new Eplan.EplApi.Gui.ContextMenuLocation("PlaceHolder", "1004");
            oContextMenu.AddMenuItem(oContextMenuLocation, "Übersetzen", "PlaceHolderTranslateAction", false, false);
            oContextMenu.AddMenuItem(oContextMenuLocation, "Übersetzungen entfernen", "PlaceHolderTranslateDeleteAction", false, false);
        }

        [DeclareAction("PlaceHolderTranslateAction")]
        public void PlaceHolderTranslate_Action()
        {
            //Übersetzen
            new CommandLineInterpreter().Execute("EnfTranslateEditAction");
        }

        [DeclareAction("PlaceHolderTranslateDeleteAction")]
        public void PlaceHolderTranslateDelete_Action()
        {
            //Übersetzungen entfernen
            new CommandLineInterpreter().Execute("EnfDeleteEditTranslationsAction");
        }

    }
}
