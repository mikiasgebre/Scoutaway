using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("Forage")]
public class Forage : Operation 
{
    public override string Name
    {
        get { return "Forage"; }
    }

    public override void Execute()
    {
        base.Execute();

        if (doact)
        {
            Debug.Log("Got mushroom. Now the world is fuzzy :O");
            InfoText = "You have gained 10 mushrooms";
            //UIBar.ChangeInfoText("You have gained 10 mushrooms");
            GameManager.MushroomAmount += 10;
            //OperationPanelControl oPC = GameObject.FindObjectOfType<OperationPanelControl>();
            OPC.DecreaseActionsAvailable();
            int rnd = Random.Range(0, 100);
            if (rnd > 20)
            {
                Application.LoadLevel("StoneThrow");
            }
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}
