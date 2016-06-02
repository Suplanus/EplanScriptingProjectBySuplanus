//###########################################################################################
// ESS - [ESS]_Toggle_DeviceTag
//###########################################################################################
// Funktion:    Zeilenumbruch in sichtbarem BMK setzen/entfernen
//              HINWEIS: nur Standard-Trennzeichen berücksichtigt:
//                          ==  Funktionale Zuordnung
//                          =   Anlage
//                          ++  Aufstellungsort
//                          +   Einbauort
//                          -   Produktaspekt
//                          #   Benutzerdefiniert
//###########################################################################################
// ChangeLog:
//-------------------------------------------------------------------------------------------
// 2016-06-02   V1.0    nairolf  Ersterstellung Script
//########################################################################################### 

using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace EplanScriptingProjectBySuplanus.ToggleDeviceTag
{
   public class ESS_Toggle_DeviceTag
   {
      public string sQuote = "\"";
      public string sExportFileName = "$(TMP)\\TMP_Toggle_DT.txt";

      [DeclareAction("ESS_Toggle_DeviceTag")]
      public bool FuncToggleDT(string MODE)
      {
         //Modus festlegen
         string _sMode = MODE.ToUpper();

         //BMK (sichtbar) ändern      
         Eplan.EplApi.ApplicationFramework.CommandLineInterpreter oComLineInter = new Eplan.EplApi.ApplicationFramework.CommandLineInterpreter();
         #region delete DT (visible)
         if (System.IO.File.Exists(PathMap.SubstitutePath(sExportFileName)))
         {
            try
            {
               System.IO.File.Delete(PathMap.SubstitutePath(sExportFileName));
            }
            catch
            { 
               return false;
            }
         }

         //BMK (sichtbar) kann nicht direkt gesetzt werden --> Umweg über ext. Bearbeiten
         oComLineInter.Execute("XMExportFunctionAction /ConfigScheme:[ESS]_MacroScriptHelper_MultiLine_DT /CompleteProject:0 /Destination:" + sQuote + sExportFileName + sQuote + "/ExecutionMode:0");

         //Textedatei einlesen und ändern   
         #region read / change export file
         System.IO.FileInfo oFI = new System.IO.FileInfo(PathMap.SubstitutePath(sExportFileName));
         if(oFI.Exists)
         {
            string sFileContentOld = ReadFile(PathMap.SubstitutePath(sExportFileName));
            string sFileContentNew = string.Empty;
 
            string[] sAllLines = sFileContentOld.Split('\n');
            int nLineCnt = 0;
            foreach (string sTempLine in sAllLines)
            {
               nLineCnt++;
               string[] sCols = sTempLine.Split('\t');
               if (sCols.Length >= 4 && nLineCnt > 2)
               {
                  //get actual visible DT
                  string _sOldDTVisible = sCols[4];
                  string _sNewDTVisible = null;

                  //add line break (ONLY, if there is NO line-break already existing in visile DT)
                  #region add line-break
                  if (_sMode == "ADD" && !string.IsNullOrEmpty(_sOldDTVisible))
                  {
                     if (!_sOldDTVisible.Contains(@"\n"))
                     {
                        _sNewDTVisible = _sOldDTVisible.Replace("==", "$").Replace("++", "%");
                        _sNewDTVisible = _sNewDTVisible.Replace("$", @"\n$").Replace("=", @"\n=").Replace("%", @"\n%").Replace("+", @"\n+").Replace("-", @"\n-").Replace("#",@"\n#");
                        _sNewDTVisible = _sNewDTVisible.Replace("$", "==").Replace("%", "++");
                     }
                  }
                  #endregion

                  //remove line-breaks
                  #region REMOVE line-break
                  if (_sMode == "REMOVE" && !string.IsNullOrEmpty(_sOldDTVisible))
                  {
                     _sNewDTVisible = _sOldDTVisible.Replace(@"\n", string.Empty);
                  }
                  #endregion

                  //correct beginning line-break                     
                  if (!string.IsNullOrEmpty(_sNewDTVisible))
                  {
                     if (_sNewDTVisible.StartsWith(@"\n"))
                     {
                        _sNewDTVisible = _sNewDTVisible.Substring(2);
                     }
                  }

                  //create new-text-content for import of external editing
                  if (_sNewDTVisible != null)
                  {
                     sFileContentNew = sFileContentNew + sCols[0] + "\t" + sCols[1] + "\t" + sCols[2] + "\t" + sCols[3] + "\t" + _sNewDTVisible + System.Environment.NewLine;
                  }
                  else
                  {
                     sFileContentNew = sFileContentNew + sCols[0] + "\t" + sCols[1] + "\t" + sCols[2] + "\t" + sCols[3] + "\t" + _sOldDTVisible  + System.Environment.NewLine;
                  }
               }
               else
               {
                  //create new-text-content for import of external editing
                  sFileContentNew = sFileContentNew + sTempLine + System.Environment.NewLine;                    
               }
            }               
	         
            //veränderte Textdatei schreiben
            WriteFile(PathMap.SubstitutePath(sExportFileName), sFileContentNew);
           
         }
         else
         {
            Decider eDecision = new Decider();
            EnumDecisionReturn eAnswer = eDecision.Decide(Eplan.EplApi.Base.EnumDecisionType.eOkDecision, "Keine temporäre Importdatei\n'" + sExportFileName  +"'\ngefunden !\n\n(Wurden passende Funktionen markiert ?)", "Eplan Decider", Eplan.EplApi.Base.EnumDecisionReturn.eOK, Eplan.EplApi.Base.EnumDecisionReturn.eOK);            
            return false;
         }
         #endregion

         //veränderte Text-Datei wieder in EPLAN einlesen
         oComLineInter.Execute("XMActionDCImport /DataConfigurationFile:" + sQuote + sExportFileName + sQuote + " /ProgressTitle:" + sQuote + "change visible DT..." + sQuote);

         #endregion
       
         return true;
      }

      public string ReadFile(string sFilename)
      {
         string sContent = string.Empty;

         if (System.IO.File.Exists(sFilename))
         {
            System.IO.StreamReader myFile = new System.IO.StreamReader(sFilename, System.Text.Encoding.Default);
            sContent = myFile.ReadToEnd();
            myFile.Close();
         }
         return sContent;
      }   

      public void WriteFile(string sFilename,string sTextContent)
      {
         System.IO.StreamWriter myFile = new System.IO.StreamWriter(sFilename);
         myFile.Write(sTextContent);
         myFile.Close();
      }
   }
}