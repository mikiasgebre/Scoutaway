using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("GetWater")]
public class GetWater : Operation
{
    public override string Name
    {
        get { return "Get Water"; }
    }

    public override void Execute()
    {
        base.Execute();

        if (doact)
        {
            Debug.Log("Got one water");
            GameManager.WaterAmount += 20;
            InfoText = "You gained 20 water.";
            //UIBar.ChangeInfoText("You gained 20 water.");
            OPC.DecreaseActionsAvailable();
           // OperationPanelControl oPC = GameObject.FindObjectOfType<OperationPanelControl>();
            int rnd = Random.Range(0, 100);
            if (rnd > 20)
            {
                Application.LoadLevel("Climbing");
            }
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}
