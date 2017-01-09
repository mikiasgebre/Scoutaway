using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OperationPanelControl : MonoBehaviour
{
    [HideInInspector]
    public List<Button> buttons;
    public List<Operation> Operations;
    public Actor Act;
    public Text ActorName;
    // Use this for initialization
    void Start()
    {
        Operations = new List<Operation>();
        Operations.Add(new GetWater());
        Operations.Add(new GetWood());
        Operations.Add(new GoFishing());
        Operations.Add(new CreateCampfire());
        Operations.Add(new BuildBoat());
        Operations.Add(new BuildHut());
        Operations.Add(new Forage());
        Operations.Add(new PlayHarmonica());
        ActorName = GameObject.Find("CharacterName").GetComponent<Text>();
        
        buttons = new List<Button>();
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            buttons.Add(b);
        }
        this.gameObject.SetActive(false);
        StatsPanelController.SetGameObject(GameObject.Find("StatsPanel"));
        StatsPanelController.ViewPanel(false, this.gameObject);
    }

    public void DoOperation(int index)
    {
        if (Act.OperationsAvailable > 0)
        {
            Act.AvailableOperations[index].Execute();
            
            HidePanel();
        }
        else
        {
            print("You're too tired!");
        }
    }

    public void HidePanel()
    {
        StatsPanelController.ViewPanel(false, this.gameObject);
        foreach (BoxCollider2D box in FindObjectsOfType<BoxCollider2D>())
        {
            box.enabled = true;
        }
        this.gameObject.SetActive(false);
    }

    public void DecreaseActionsAvailable()
    {
        Act.OperationsAvailable -= 1;
    }
}
