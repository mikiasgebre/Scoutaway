using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("BuildHut")]
public class Eat : Operation 
{
    public override string Name
    {
        get { return "Eat a meal"; }
    }
    public override void Execute()
    {
        base.Execute();

        if (doact && GameManager.MealAmount >= 1)
        {
            Debug.Log("nomnomnom");
            InfoText = "You have consumed 1 delicious meal.";
            //UIBar.ChangeInfoText("You have consumed 1 delicious meal.");
            GameManager.MealAmount--;
            OPC.Act.Needs.Hunger += 50f;
            OPC.DecreaseActionsAvailable();
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}
