using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("CreateCampfire")]
public class CreateCampfire : Operation
{
    public override string Name
    {
        get { return "Make campfire"; }
    }
    public override void Execute()
    {
        base.Execute();

        if (doact && GameManager.WoodAmount >= 5)
        {
            SceneManager.Campfire.SetActive(true);
            Debug.Log("Fire Water Burn");
            InfoText = "You have created a campfire.";

            GameObject.FindObjectOfType<CampfireController>().GetComponent<Animator>().SetBool("OnFire", true);
            //UIBar.ChangeInfoText("You have created a campfire.");
            //OperationPanelControl oPC = GameObject.FindObjectOfType<OperationPanelControl>();
            OPC.DecreaseActionsAvailable();
            GameManager.WoodAmount -= 10;
            GameManager.FirePower += 20;
        }
        else if (doact && GameManager.WoodAmount < 5)
        {
            InfoText = "There isn't enough wood!";
            Debug.Log("There isn't enough wood!");
        }
    }
}
