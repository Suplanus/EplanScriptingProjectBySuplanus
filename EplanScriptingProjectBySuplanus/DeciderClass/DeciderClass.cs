using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

class DeciderClass
{
    [Start]
    public void Function()
    {
        #region Decider
        Decider decider = new Decider();
        EnumDecisionReturn decision = decider.Decide(
            EnumDecisionType.eOkCancelDecision, // type
            "This is the text",
            "Title",
            EnumDecisionReturn.eOK, // selected Answer
            EnumDecisionReturn.eOK); // Answer if quite-mode on

        switch (decision)
        {
            case EnumDecisionReturn.eOK:
                // OK
                break;

            case EnumDecisionReturn.eCANCEL:
                // Cancel
                break;
        } 
        #endregion


        #region FileSelector
        FileSelectDecisionContext fileContext = new FileSelectDecisionContext("MySelector", EnumDecisionReturn.eCANCEL);
        fileContext.Title = "Title";
        fileContext.CustomDefaultPath = @"C:\MyDefaultPath";
        fileContext.OpenFileFlag = true; // true=Open, false=save
        fileContext.AllowMultiSelect = true;
        fileContext.DefaultExtension = "xml";
        fileContext.AddFilter("XML files (*.xml)", "*.xml");
        fileContext.AddFilter("All files (*.*)", "*.*");

        Decider oDecision = new Decider();
        EnumDecisionReturn eAnswer = oDecision.Decide(fileContext);
        if (eAnswer != EnumDecisionReturn.eOK)
        {
            foreach (string file in fileContext.GetFiles())
            {
                // do with file
            }
        } 
        #endregion

    }
}

