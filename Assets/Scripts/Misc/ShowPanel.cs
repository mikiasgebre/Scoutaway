using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowPanel : MonoBehaviour
{
    public int ActorID;
    private List<Operation> operations;
    private Sprite initialSprite;
    private OperationPanelControl oPC;
    private Actor thisActor;
    private Camera cam;
    public bool panelOn;
    private SceneManager sceneManager;
    private Color sColor;
    // Use this for initialization
    private void Start()
    {
        thisActor = GameManager.Party[ActorID];
        if (cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }
        sceneManager = FindObjectOfType<SceneManager>();
    }

    private void Awake()
    {
        oPC = FindObjectOfType<OperationPanelControl>();
    }

    private void OnMouseDown()
    {
        if (!panelOn && !PanelControl.GUIPanelOn)
        {
            oPC.Act = GameManager.Party[ActorID];
            oPC.ActorName.text = GameManager.Party[ActorID].Name;
            foreach (BoxCollider2D box in FindObjectsOfType<BoxCollider2D>())
            {
                box.enabled = false;
            }
            ViewPanel();
            StatsPanelController.SetBarValue("Thirst", GameManager.Party[ActorID].Needs.Thirst);
            StatsPanelController.SetBarValue("Hunger", GameManager.Party[ActorID].Needs.Hunger);
            StatsPanelController.SetBarValue("Warmth", GameManager.Party[ActorID].Needs.Warmth);
            StatsPanelController.SetBarValue("Entertainment", GameManager.Party[ActorID].Needs.Entertainment);
            
            for (int i = 0; i < thisActor.AvailableOperations.Count; i++)
            {
                oPC.buttons[i].GetComponentInChildren<Text>().text = thisActor.AvailableOperations[i].Name;
            }
        }
        else
        {
            oPC.HidePanel();
            StatsPanelController.ViewPanel(false, this.gameObject);
            panelOn = false;
        }
    }


    public void SpriteSwitch(Sprite sprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void ViewPanel()
    {
        Vector3 statPanelPos;
        oPC.gameObject.SetActive(true);
        StatsPanelController.ViewPanel(true, this.gameObject);
        statPanelPos = this.gameObject.transform.position;

        if (Screen.width - cam.WorldToScreenPoint(gameObject.transform.position).x > Screen.width / 3)
        {
            oPC.GetComponent<RectTransform>().anchorMin = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width + 0.05f, 0);
            oPC.GetComponent<RectTransform>().anchorMax = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width + 0.25f, 1);
            StatsPanelController.StatsPanel.GetComponent<RectTransform>().anchorMin = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width + 0.25f, 0);
            StatsPanelController.StatsPanel.GetComponent<RectTransform>().anchorMax = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width + 0.4f, 1);
        }
        else
        {
            oPC.GetComponent<RectTransform>().anchorMin = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width - 0.25f, 0);
            oPC.GetComponent<RectTransform>().anchorMax = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width - 0.05f, 1);
            StatsPanelController.StatsPanel.GetComponent<RectTransform>().anchorMin = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width - 0.4f, 0);
            StatsPanelController.StatsPanel.GetComponent<RectTransform>().anchorMax = new Vector2(cam.WorldToScreenPoint(this.gameObject.transform.position).x / Screen.width - 0.25f, 1);
        }
        panelOn = true;
    }
}
