using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoThroughNight : MonoBehaviour 
{
    Text daysText;
    private GameObject nightPanel;
    private Text nightPanelText;
    string eventText;

    private void Start()
    {
        daysText = GameObject.Find("Days").GetComponent<Text>();
        nightPanel = GameObject.Find("NightlyEvent");
        nightPanelText = nightPanel.GetComponentInChildren<Text>();
        nightPanel.SetActive(false);
    }
    public void Night()
    {
        GameManager.Days += 1;
        daysText.text = "Day " + GameManager.Days;

        foreach (Actor a in GameManager.Party)
        {
            a.OperationsAvailable = 1;
            a.Needs.Thirst -= (int)((15 - GameManager.WaterAmount*0.3f)*a.ThirstFactor);
            a.Needs.Warmth += (int)((GameManager.FirePower + GameManager.HutLevel * 4 - 10*GameManager.Days*0.01)*a.WarmthFactor);
            a.Needs.Hunger -= (int)((15 - GameManager.MealAmount*0.3f*a.HungerFactor)*a.HungerFactor);
            a.Needs.Entertainment -= (int)((15 + GameManager.WaterAmount * 0.1f + GameManager.FirePower * 0.1f + GameManager.MealAmount * 0.1f)*a.EntertainmentFactor);
            a.Needs.Motivation += (int)((a.Needs.Warmth + a.Needs.Thirst + a.Needs.Hunger + a.Needs.Entertainment - 100)*a.MotivationFactor);
        }
        if (GameManager.FirePower > 0)
        {
            GameManager.FirePower -= 5;

            if (GameManager.FirePower < 0)
            {
                GameManager.FirePower = 0;
            }
        }
        if (FindObjectOfType<CampfireController>())
        {
            FindObjectOfType<CampfireController>().UpdateCampfire();
        }

        if (GameManager.MealAmount > 0)
        {
            GameManager.MealAmount -= 5;

            if (GameManager.MealAmount < 0)
            {
                GameManager.MealAmount = 0;
            }
        }

        if (GameManager.WaterAmount > 0)
        {
            GameManager.WaterAmount -= 5;

            if (GameManager.WaterAmount < 0)
            {
                GameManager.WaterAmount = 0;
            }
        }

        int randomInt = Random.Range(0, 100);

        if (randomInt < 50)
        {
            nightPanel.SetActive(true);
            PanelControl.GUIPanelOn = true;

            if (randomInt < 10)
            {
                eventText = TextManager.GetText("NightHunger", GameManager.SelectedLanguage);

                for (int i = 0; randomInt < GameManager.Party.Count; randomInt++)
                {
                    GameManager.Party[i].Needs.Hunger -= (int)Random.Range(1, 10);
                }
            }
            else if (randomInt < 20 && randomInt > 10)
            {
                eventText = TextManager.GetText("NightWarmth", GameManager.SelectedLanguage);

                for (int i= 0; randomInt < GameManager.Party.Count; randomInt++)
                {
                    GameManager.Party[i].Needs.Warmth -= (int)Random.Range(1, 10);
                }
            }
            else if (randomInt < 30 && randomInt > 20)
            {
                eventText = TextManager.GetText("NightThirst", GameManager.SelectedLanguage);

                for (int i = 0; randomInt < GameManager.Party.Count; randomInt++)
                {
                    GameManager.Party[i].Needs.Thirst -= (int)Random.Range(1, 10);
                }
            }
            else if (randomInt < 50 && randomInt > 30)
            {
                eventText = TextManager.GetText("Night", GameManager.SelectedLanguage);
            }
            nightPanelText.text = eventText;
        }

        SaveData.Save();
        print("Night is dark and full of errors");

        if (FindObjectOfType<OperationPanelControl>() != null)
        {
            FindObjectOfType<OperationPanelControl>().HidePanel();
        }
    }
}
