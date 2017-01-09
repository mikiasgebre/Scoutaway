using UnityEngine;
using System.Collections;

public class ToggleGUIElement : MonoBehaviour
{
    public bool toggle;

    public void Toggle()
    {
        this.transform.parent.gameObject.SetActive(toggle);
        PanelControl.GUIPanelOn = toggle;
    }
}
