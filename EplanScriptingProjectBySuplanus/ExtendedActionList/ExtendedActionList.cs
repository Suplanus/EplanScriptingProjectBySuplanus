// Einstellungen-ExtendedActionList.cs
//
// Schaltet einen More-Button im Fenster "Schaltfläche einstellen"
// (Symbolleiste anpassen) neben dem Eingabefeld "Befehlszeile" frei.
// Dieser öffnet ein Fenster mit allen verfügbaren Actions.
//
// Standardmäßig auf 0 gesetzt
//
// Copyright by Frank Schöneck, 2015
// letzte Änderung: Frank Schöneck, 08.07.2015 V1.0.0, Projektbeginn
//
// für Eplan Electric P8, ab V2.5
//
//

using System.Windows.Forms;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.ExtendedActionList
{
  public class ExtendedActionList
  {
    [Start]
    public void MyFunction()
    {
      Eplan.EplApi.Base.Settings oSettings = new Eplan.EplApi.Base.Settings();
      //Einstellung auslesen
      bool bolSetting = oSettings.GetBoolSetting("USER.ModalDialogs.XSdCustomToolbarComponent.ExtendedActionList", 0);
      //wenn nicht gesetzt, setzen
      if (bolSetting == false)
      {
        oSettings.SetBoolSetting("USER.ModalDialogs.XSdCustomToolbarComponent.ExtendedActionList", true, 0);
        MessageBox.Show("Die Einstellung wurde 'aktiviert'.", "USER.ModalDialogs.XSdCustomToolbarComponent.ExtendedActionList", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      //wenn gesetzt, zurücksetzen
      else if (bolSetting == true)
      {
        oSettings.SetBoolSetting("USER.ModalDialogs.XSdCustomToolbarComponent.ExtendedActionList", false, 0);
        MessageBox.Show("Die Einstellung wurde 'deaktiviert'.", "USER.ModalDialogs.XSdCustomToolbarComponent.ExtendedActionList", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      return;
    }
  }
}
