using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class BadgeControl : MonoBehaviour
{
    public GameObject BadgePrefab;
    private List<Badge> allBadges;
    private GameObject badgeParent;
    // Use this for initialization
    void Start()
    {
        SetBadgesToPanel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetBadgesToPanel()
    {
        FindObjectOfType<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 3.1f, Screen.height / 3f);
        badgeParent = FindObjectOfType<BadgeControl>().gameObject;
        allBadges = new List<Badge>();
        allBadges.Add(new Badge(TextManager.GetText("Badge of Fishing", GameManager.SelectedLanguage), TextManager.GetText("Badge of FishingDesc", GameManager.SelectedLanguage), true, "Sprites/fishy"));
        allBadges.Add(new Badge(TextManager.GetText("Badge of Campfiring", GameManager.SelectedLanguage), TextManager.GetText("Badge of CampfiringDesc", GameManager.SelectedLanguage), true, "Sprites/Checkpoint"));
        allBadges.Add(new Badge(TextManager.GetText("Badge of Foraging", GameManager.SelectedLanguage), TextManager.GetText("Badge of ForagingDesc", GameManager.SelectedLanguage), true, "Sprites/stone"));
        allBadges.Add(new Badge(TextManager.GetText("Badge of Cooking", GameManager.SelectedLanguage), TextManager.GetText("Badge of CookingDesc", GameManager.SelectedLanguage), true, "Sprites/ammus1"));
      
        for (int i = 0; i < allBadges.Count; i++)
        {
            GameObject go = (GameObject)GameObject.Instantiate(BadgePrefab);
            go.transform.parent = badgeParent.transform;
            go.transform.FindChild("BadgeImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(allBadges[i].SpritePath);
            go.transform.FindChild("Text").GetComponent<Text>().text = allBadges[i].Description;
            go.transform.FindChild("Title").GetComponent<Text>().text = allBadges[i].Name;

            allBadges[i].Description = TextManager.GetText((string)allBadges[i].Name + "Desc", GameManager.SelectedLanguage);
        }
    }
}
