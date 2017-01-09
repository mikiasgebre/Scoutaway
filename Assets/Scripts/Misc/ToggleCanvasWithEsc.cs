using UnityEngine;
using System.Collections;

public class ToggleCanvasWithEsc : BlockEscape 
{
    public Canvas PopupCanvas;
    public bool EscClosesOnly;

    public void Toggle(bool On)
    {
        if (!IsBlocked())
        {
            if (On)
            {
                PopupCanvas.enabled = true;
                Blocking = true;
            }
            else
            {
                PopupCanvas.enabled = false;
                Blocking = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(SleepForAFrame());
        }
    }

    private IEnumerator SleepForAFrame()
    {
        yield return new WaitForEndOfFrame();
        if (!IsBlocked())
        {
            if (EscClosesOnly)
            {
                PopupCanvas.enabled = false;
                Blocking = false;
            }
            else
            {
                PopupCanvas.enabled = !PopupCanvas.enabled;
                Blocking = PopupCanvas.enabled;
            }
        }
    }
}
