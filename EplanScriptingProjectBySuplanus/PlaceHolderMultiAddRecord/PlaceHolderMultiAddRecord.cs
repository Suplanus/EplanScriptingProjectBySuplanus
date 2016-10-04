// PlaceHolderMultiAddRecord, Version 1.1.0, vom 04.11.2014
//
// Erweitert das Kontextmenü vom Platzhalterobjekt (Reiter Werte) um den Menüpunkt "Neuer Wertesatz (Mehrfach)..."
// Erlaubt darüber das anlegen von mehreren leeren Wertesätzen.
//
// Copyright by Frank Schöneck, 2013-2014
// letzte Änderung: Frank Schöneck, 16.01.2013 V1.0.0, Projektbeginn
//					Frank Schöneck, 04.11.2014 V1.1.0, Umgestellt von SendKeys auf Action "MacrosGuiIGfWindNewRecord"
//
// für Eplan Electric P8, ab V2.2
//

using System;
using System.Drawing;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.PlaceHolderMultiAddRecord
{
   public class PlaceHolderMultiAddRecord
   {
      [DeclareMenu()]
      public void PlaceHolderMultiAddRecordContextMenu()
      {
         //Context-Menüeintrag (hier im Platzhalterobjekt)
         Eplan.EplApi.Gui.ContextMenu oContextMenu = new Eplan.EplApi.Gui.ContextMenu();
         Eplan.EplApi.Gui.ContextMenuLocation oContextMenuLocation = new Eplan.EplApi.Gui.ContextMenuLocation("PlaceHolder", "1004");
         oContextMenu.AddMenuItem(oContextMenuLocation, "Neuer Wertesatz (&Mehrfach)...", "PlaceHolderMultiAddRecord", false, false);
      }

      [DeclareAction("PlaceHolderMultiAddRecord")]
      public void PlaceHolderMultiAddRecord_Action()
      {
         string value = "2";
         if (InputBox.Show("Neuer Wertesatz (Mehrfach)", "Wieviele Wertesätze sollen angelegt werden?", ref value) == DialogResult.OK)
         {
            int iValue = Convert.ToInt32(value); // Eingabe von Typ string in ein Typ int wandeln
            for (int i = 1; i <= iValue; i++)
            {
               new CommandLineInterpreter().Execute("MacrosGuiIGfWindNewRecord");
               //SendKeys.SendWait("^+{F10}W"); //Taste Kontextmenü aufrufen und direkt Taste W
            }
         }
         return;
      }
   }

   public class InputBox
   {
      /// <summary>
      /// Displays a dialog with a prompt and textbox where the user can enter information
      /// </summary>
      /// <param name="title">Dialog title</param>
      /// <param name="promptText">Dialog prompt</param>
      /// <param name="value">Sets the initial value and returns the result</param>
      /// <returns>Dialog result</returns>
      public static DialogResult Show(string title, string promptText, ref string value)
      {
         Form form = new Form();
         Label label = new Label();
         TextBox textBox = new TextBox();
         Button buttonOk = new Button();
         Button buttonCancel = new Button();

         form.Text = title;
         label.Text = promptText;
         textBox.Text = value;

         buttonOk.Text = "OK";
         buttonCancel.Text = "Abbrechen";
         buttonOk.DialogResult = DialogResult.OK;
         buttonCancel.DialogResult = DialogResult.Cancel;

         label.SetBounds(9, 18, 372, 13);
         textBox.SetBounds(12, 36, 372, 20);
         buttonOk.SetBounds(228, 72, 75, 23);
         buttonCancel.SetBounds(309, 72, 75, 23);

         label.AutoSize = true;
         textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
         buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
         buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

         form.ClientSize = new Size(396, 107);
         form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
         form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
         form.FormBorderStyle = FormBorderStyle.FixedDialog;
         form.StartPosition = FormStartPosition.CenterScreen;
         form.MinimizeBox = false;
         form.MaximizeBox = false;
         form.AcceptButton = buttonOk;
         form.CancelButton = buttonCancel;

         DialogResult dialogResult = form.ShowDialog();
         value = textBox.Text;
         return dialogResult;
      }
   }
}