using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStatDrawer : MonoBehaviour {
    public Canvas StatCanvas;
    public string Description;
    private string text;
    private CharacterSelection charSelect;
    private string characterName;


	// Use this for initialization
	void Start () {
        charSelect = FindObjectOfType<CharacterSelection>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowCharacterStats(int character)
    {
        if (StatCanvas.enabled && character == charSelect.lastChar)
        {
            StatCanvas.enabled = false;
        }
        else
        {

            characterName = charSelect.actorList[character].Name;
            Description = charSelect.actorList[character].SpecialSkill;
            /*fishing = actorList[character].Stats.Fishing;
            music = actorList[character].Stats.Music;
            nature = actorList[character].Stats.Nature;
            craftsmanship = actorList[character].Stats.Craftsmanship;*/

            //text = "Fishing: " + fishing + "\nMusic: " + music + "\nNature: " + nature + "\nCraftsmanship: " + craftsmanship;
            //text = actorList[character].SpecialSkill;
            text = characterName + "\n" + Description;
            StatCanvas.GetComponentInChildren<Text>().text = text;

            StatCanvas.enabled = true;

        }
        charSelect.lastChar = character;


    }
}
