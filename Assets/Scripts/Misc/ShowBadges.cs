using UnityEngine;
using System.Collections;

public class ShowBadges : MonoBehaviour 
{
    private bool show;
    private GameObject badgePanel;
	// Use this for initialization
	void Start () 
    {
        show = true;
        badgePanel = GameObject.Find("BadgePanel");
        badgePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowBadgePanel()
    {
        ToggleBadges(show);
        PanelControl.GUIPanelOn = show;
        show = !show;
    }

    private void ToggleBadges(bool toggle)
    {
        badgePanel.SetActive(toggle);
    }
}
