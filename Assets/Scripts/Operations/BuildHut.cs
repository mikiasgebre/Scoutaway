using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("BuildHut")]
public class BuildHut : Operation 
{
    public override string Name
    {
        get { return "Build hut"; }
    }
    public override void Execute()
    {
        base.Execute();

        if (doact && GameManager.HutLevel <= 2)
        {
            Debug.Log("Got hut");
            //UIBar.ChangeInfoText("You have built the hut by " + 20 / (GameManager.HutLevel * 5) + ". Progress: " + GameManager.HutCompletion + "/100");
            GameManager.HutCompletion += 25 - (GameManager.HutLevel+1) * 5;
            Debug.Log(SceneManager);
            SceneManager.DrawHut(GameManager.HutCompletion / 20 - 1);

            OPC.DecreaseActionsAvailable();
            if (GameManager.HutCompletion >= 100)
            {
                GameManager.HutLevel += 1;
                GameManager.HutCompletion = 0;
            }

            InfoText = "You have built the hut by " + (25 - ((GameManager.HutLevel + 1) * 5)) + ". Progress: " + GameManager.HutCompletion + "/100";

        }
        else if (!doact)
        {
            InfoText = "No actions available";
        }

        if (GameManager.HutLevel >= 3 && doact)
        {
            GameManager.HutCompletion = 100;
            InfoText = "Your hut has been already completed.";
        }
    }
}
