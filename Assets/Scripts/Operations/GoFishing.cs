using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("GoFishing")]
public class GoFishing : Operation
{
    public override string Name
    {
        get { return "Go fishing"; }
    }
    public override void Execute()
    {
        base.Execute();
        if (doact)
        {
            Debug.Log("Got mamelukkikala");
            InfoText = "You caught 20 fish.";
            //UIBar.ChangeInfoText("You caught 20 fish.");
            GameManager.FishAmount += 20;
            //OperationPanelControl oPC = GameObject.FindObjectOfType<OperationPanelControl>();
            OPC.DecreaseActionsAvailable();
            foreach (Actor a in GameManager.Party)
            {
                a.Needs.Hunger += 20;
                if (a.Needs.Hunger > 100)
                {
                    a.Needs.Hunger = 100;
                }
            }
            StatsPanelController.SetBarValue("Hunger", GameManager.Party[OPC.Act.IndexInParty].Needs.Hunger);
            int rnd = Random.Range(0, 100);
            if (rnd > 20)
            {
                Application.LoadLevel("Fishing");
            }
            else if (!doact)
            {
                InfoText = "No actions available";
            }
        }
    }
}
