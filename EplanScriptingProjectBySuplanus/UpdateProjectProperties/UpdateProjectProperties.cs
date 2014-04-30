/*
 * Created by Daniel Papp.
 * Date: 28.04.2014
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

namespace RefreshProjectProperties
{
    public class UpdateProjectProps
    {
        /// <summary>
        /// Description of RefreshProjectProperties.
        /// </summary>
        public class UpdateProjectProperties
        {
            [DeclareEventHandler("onActionEnd.String.XPrjActionProjectOpen")]
            public void SetPrjBlockProperties()
            {

                string musterPrjPath = @"C:\Dokumente und Einstellungen\All Users\Anwendungsdaten\EPLAN\Data\Projekte\Firma\EPLAN-DEMO.edb";
                string activePrjPath = PathMap.SubstitutePath("$(P)");

                System.Collections.Generic.List<KeyValuePair<string, string>> PropertyList = getPropertySettings();
                CommandLineInterpreter oCLI = new CommandLineInterpreter();
                ActionCallingContext acc = new ActionCallingContext();
                DialogResult Result = MessageBox.Show("Ein oder mehrer Projekteigenschaften vom Typ Blockeigenschaft:Format sind nicht auf dem Stand des Musterprojektes. Sollen die Eigenschaften aktualisiert werden?", "Blockeigenschaften-Formate aktualisieren: " + PathMap.SubstitutePath("$(PROJECTNAME)"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, false);
                foreach (var element in PropertyList)
                {
                    string PropValue = getProjectProperty(musterPrjPath, element.Key, element.Value);
                    if (Result == DialogResult.Yes)
                    {
                        acc.AddParameter("PropertyId", element.Key);
                        acc.AddParameter("PropertyIndex", element.Value);
                        acc.AddParameter("PropertyValue", PropValue);
                        oCLI.Execute("XEsSetProjectPropertyAction", acc);
                    }
                }
            }

            private string getProjectProperty(string ProjectPath, string PropID, string PropIDindex)
            {
                string xmlFile = ProjectPath + "\\ProjectInfo.xml";
                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                xDoc.Load(xmlFile);
                string query = string.Format("//*[@id='{0}' and @index='{1}']", PropID, PropIDindex);
                string returntext;
                try
                {
                    System.Xml.XmlElement el = (System.Xml.XmlElement)xDoc.SelectSingleNode(query);
                    returntext = el.InnerText;
                }
                catch (Exception)
                {

                    returntext = string.Empty;
                }

                return returntext;
            }

            private System.Collections.Generic.List<KeyValuePair<string, string>> getPropertySettings()
            {
                System.Collections.Generic.List<KeyValuePair<string, string>> PropertyList = new List<KeyValuePair<string, string>>();
                string id = string.Empty;
                string index = string.Empty;

                XmlTextReader reader = new XmlTextReader(@"\PropertySettings.xml");
                while (reader.Read())
                {
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {


                            if (reader.Name == "id")
                            {
                                id = reader.Value;
                            }
                            if (reader.Name == "index")
                            {
                                index = reader.Value;
                            }
                        }
                    }

                    if (id.Length != 0 && index.Length != 0 && !PropertyList.Contains(new KeyValuePair<string, string>(id, index)))
                    {
                        PropertyList.Add(new KeyValuePair<string, string>(id, index));
                    }
                }

                return PropertyList;
            }


        }
    }
}
