using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HirePartyMember : MonoBehaviour
{
    public Text CharacterCount;
    public Button NextButton;
    private CharacterSelection charSelect;

    public void HireOrFire(int character)
    {
        if (GameManager.Party == null)
        {
            GameManager.Reset();
        }

        if (GameManager.Party.Contains(charSelect.actorList[character]))
        {
            GameManager.Party.Remove(charSelect.actorList[character]);
        }
        else
        {
            if (GameManager.Party.Count >= 4)
            {
                print("Partywagon is full, cannot add " + charSelect.actorList[character].Name + " to party!");
            }
            else
            {
                GameManager.Party.Add(charSelect.actorList[character]);
            }
        }
        print(charSelect.actorList[character].Name + " knows " + charSelect.actorList[character].SpecialSkill);
        UpdatePartySize();
    }

    public void UpdatePartySize()
    {
        if (GameManager.Party == null)
        {
            GameManager.Reset();
        }

        if (GameManager.Party.Count == 4)
        {
            NextButton.enabled = true;
        }
        else
        {
            NextButton.enabled = false;
        }
        GameManager.Party.TrimExcess();
        CharacterCount.text = "Party size: " + GameManager.Party.Count + "/4";
    }

    // Use this for initialization
    private void Start()
    {
        charSelect = FindObjectOfType<CharacterSelection>();
        UpdatePartySize();
    }
}