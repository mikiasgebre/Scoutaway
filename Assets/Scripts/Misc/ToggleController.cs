using UnityEngine;
using System.Collections;

public class ToggleController : MonoBehaviour 
{
    public Language Lang;

    public void SelectLanguage(bool b)
    {
        if (b)
        {
            GameManager.SelectedLanguage = Lang;
        }
    }
}
