using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("GetWood")]
public class GetWood : Operation 
{
    public override string Name
    {
        get { return "Get Wood"; }
    }

    public override void Execute()
    {
        base.Execute();

        if (doact)
        {
            Debug.Log("Got wood");
            InfoText = "You have gained 20 wood. Use it wisely.";
            //UIBar.ChangeInfoText("You have gained 20 wood. Use it wisely.");
            GameManager.WoodAmount += 20;
            OPC.DecreaseActionsAvailable();
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}
