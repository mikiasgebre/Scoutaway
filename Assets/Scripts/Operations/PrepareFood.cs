using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("PrepareFood")]
public class PrepareFood : Operation
{
    public override string Name
    {
        get { return "Prepare food"; }
    }

    public override void Execute()
    {
        base.Execute();

        if (doact && GameManager.FirePower > 0)
        {
            if (GameManager.MushroomAmount > 4)
            {
                GameManager.MushroomAmount -= 2;
                GameManager.MealAmount += 2;
                Debug.Log("Got so many mushies that are cooked");
                InfoText = "Your mushrooms turned into great meals!";
                //UIBar.ChangeInfoText("Your mushrooms turned into great meals!");
            }

            if (GameManager.FishAmount > 2)
            {
                GameManager.FishAmount -= 2;
                GameManager.MealAmount += 2;
                Debug.Log("Smeagol don't like cooked fish");
                InfoText = "You have created delicious meals from the fish.";
                //UIBar.ChangeInfoText("You have greated delicious meals from the fish.");
            }
            OPC.DecreaseActionsAvailable();
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }

    }
}
