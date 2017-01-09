using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("BuildBoat")]
public class BuildBoat : Operation
{
    public override string Name
    {
        get { return "Build boat"; }
    }

    public override void Execute()
    {
        base.Execute();

        if (doact)
        {
            Debug.Log("Got boat");
            InfoText = "You have repaired the boat by 5. Progress: " + GameManager.BoatCompletion + "/100";
            //UIBar.ChangeInfoText("You have repaired the boat by 5. Progress: " + GameManager.BoatCompletion + "/100");
            GameManager.BoatCompletion += 5;
            foreach (Actor a in GameManager.Party)
            {
                a.Needs.Motivation += 5;
                if (a.Needs.Motivation > 100)
                {
                    a.Needs.Motivation = 100;
                }
            }
            OPC.DecreaseActionsAvailable();
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}