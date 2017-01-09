using UnityEngine;
using System.Collections;

public static class StatsPanelController
{
    public static GameObject StatsPanel;
    public static void SetBarValue(string stat, float width)
    {
        RectTransform rect = GameObject.Find(stat).GetComponent<RectTransform>();
        //rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        rect.anchorMax = new Vector2(width * 0.01f, rect.anchorMax.y);
    }

    public static void ViewPanel(bool show, GameObject go)
    {
        StatsPanel.SetActive(show);

        if (go != null)
        {
            foreach (ShowPanel s in GameObject.FindObjectsOfType<ShowPanel>())
            {
                s.panelOn = show;
            }
        }
    }

    public static void SetGameObject(GameObject go)
    {
        StatsPanel = go;
    }
}
