using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultilanguageText : MonoBehaviour 
{
    [Tooltip("If empty, searches with the texts text")]
    public string KeyToSearch;
    Text text;

    void Awake()
    { 
        text = GetComponent<Text>();
    }

	// Use this for initialization
    void Start()
    {
        if (KeyToSearch != string.Empty && KeyToSearch != null)
        {
            text.text = TextManager.GetText(KeyToSearch, GameManager.SelectedLanguage);
        }
        else
        {
            text.text = TextManager.GetText(text.text, GameManager.SelectedLanguage);
        }
    }
}