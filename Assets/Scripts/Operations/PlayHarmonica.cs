using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("PlayHarmonica")]
public class PlayHarmonica : Operation
{
    public override string Name
    {
        get { return "Play Paranoid on harmonica"; }
    }
    public override void Execute()
    {
        base.Execute();

        if (doact)
        {
            Debug.Log("Dynn dynn dynn dydydydidydydydi");
            InfoText = "Dynn dynn dynn dydydydidydydydi";
            //UIBar.ChangeInfoText("Dynn dynn dynn dydydydidydydydi");
            //OperationPanelControl oPC = GameObject.FindObjectOfType<OperationPanelControl>();
            OPC.DecreaseActionsAvailable();
            foreach (Actor a in GameManager.Party)
            {
                a.Needs.Entertainment += 20;
                if (a.Needs.Entertainment > 100)
                {
                    a.Needs.Entertainment = 100;
                }
            }
            StatsPanelController.SetBarValue("Entertainment", GameManager.Party[OPC.Act.IndexInParty].Needs.Entertainment);
        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }
    }
}
