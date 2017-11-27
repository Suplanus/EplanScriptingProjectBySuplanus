using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class BackupOnClosingProject
{
	[DeclareEventHandler("onActionStart.String.XPrjActionProjectClose")]
	public void Function()
	{
		string strProjectname = PathMap.SubstitutePath("$(PROJECTNAME)");
		string strFullProjectname = PathMap.SubstitutePath("$(P)");
		string strDestination = strFullProjectname;
		
		DialogResult Result = MessageBox.Show(
			"Soll eine Sicherung für das Projekt\n'"
			+ strProjectname +
			"'\nerzeugt werden?",
			"Datensicherung",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Question
			);

		if (Result == DialogResult.Yes)

		  {

				string myTime = System.DateTime.Now.ToString("yyyy.MM.dd");
				string hour = System.DateTime.Now.Hour.ToString();
				string minute = System.DateTime.Now.Minute.ToString();

				Progress progress = new Progress("SimpleProgress");
				progress.BeginPart(100, "");
				progress.SetAllowCancel(true);

				if (!progress.Canceled())
				{
					progress.BeginPart(33, "Backup");
					ActionCallingContext backupContext = new ActionCallingContext();
					backupContext.AddParameter("BACKUPMEDIA", "DISK");
					backupContext.AddParameter("BACKUPMETHOD", "BACKUP");
					backupContext.AddParameter("COMPRESSPRJ", "0");
					backupContext.AddParameter("INCLEXTDOCS", "1");
					backupContext.AddParameter("BACKUPAMOUNT", "BACKUPAMOUNT_ALL");
					backupContext.AddParameter("INCLIMAGES", "1");
					backupContext.AddParameter("LogMsgActionDone", "true");
					backupContext.AddParameter("DESTINATIONPATH", strDestination);
					backupContext.AddParameter("PROJECTNAME", strFullProjectname);
					backupContext.AddParameter("TYPE", "PROJECT");
					backupContext.AddParameter("ARCHIVENAME", strProjectname + "_" + myTime + "_" + hour + "." + minute + ".");
					new CommandLineInterpreter().Execute("backup", backupContext);
					progress.EndPart();
					
				}
				progress.EndPart(true);
			}
			
			return;
		}
	}