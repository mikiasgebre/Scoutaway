using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("BuildHut")]
public class Drink : Operation 
{
    public override string Name
    {
        get { return "Drink water"; }
    }
    public override void Execute()
    {
        base.Execute();

        if (doact && GameManager.WaterAmount >= 1)
        {
            Debug.Log("<gulp> <ahhh>");
            InfoText = "You have consumed 1 fresh water.";
            //UIBar.ChangeInfoText("You have consumed 1 fresh water.");
            GameManager.WaterAmount--;
            OPC.Act.Needs.Thirst += 50f;
            OPC.DecreaseActionsAvailable();
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}
