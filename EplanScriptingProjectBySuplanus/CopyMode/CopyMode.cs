/*
Copyright (c) 2013 STLM Inc.
 
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
 
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
 
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using Eplan.EplApi.Scripting;

public class STLMCopy
{
    //Add the two actions as menu points under Utilities
    [DeclareMenu]
    public void CopyNormalMenu()
    {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        oMenu.AddMenuItem("Copy (Normal Mode)", "NormalCopyAction");
        oMenu.AddMenuItem("Copy (Design Mode)", "DesignCopyAction");
    }

    //Declare the action to force copy in normal mode
    [DeclareAction("NormalCopyAction")]
    public void NormalCopyAction()
    {
        bool toggled = false;

        if (DesignModeState)
        {
            ToggleDesignMode();
            toggled = true;
        }

        Copy();

        if (toggled)
            ToggleDesignMode();
    }

    //Declare the action to force copy in design mode
    [DeclareAction("DesignCopyAction")]
    public void DesignCopyAction()
    {
        bool toggled = false;

        if (!DesignModeState)
        {
            ToggleDesignMode();
            toggled = true;
        }

        Copy();

        if (toggled)
            ToggleDesignMode();
    }

    //Helper functions and properties

    private bool DesignModeState
    {
        get
        {
            return new Eplan.EplApi.Base.Settings().GetBoolSetting("USER.GedViewer.ConstructionMode", 0);
        }
    }

    private void ToggleDesignMode()
    {
        Eplan.EplApi.ApplicationFramework.ActionManager mgr = new Eplan.EplApi.ApplicationFramework.ActionManager();

        Eplan.EplApi.ApplicationFramework.Action act = mgr.FindAction("XGedActionToggleConstructionMode");
        if (act != null)
        {
            Eplan.EplApi.ApplicationFramework.ActionCallingContext ictx = new Eplan.EplApi.ApplicationFramework.ActionCallingContext();
            act.Execute(ictx);
        }
    }

    private void Copy()
    {
        Eplan.EplApi.ApplicationFramework.ActionManager mgr = new Eplan.EplApi.ApplicationFramework.ActionManager();

        Eplan.EplApi.ApplicationFramework.Action act = mgr.FindAction("XGedStartInteractionAction");
        if (act != null)
        {
            Eplan.EplApi.ApplicationFramework.ActionCallingContext CopyCtx = new Eplan.EplApi.ApplicationFramework.ActionCallingContext();
            CopyCtx.AddParameter("Name", "XMIaClipboardCopy");
            act.Execute(CopyCtx);
        }
    }

}