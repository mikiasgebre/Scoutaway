using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIbar : MonoBehaviour
{
    
    public Text Water;
    public Text Wood;
    public Text Fish;
    public Text Fruit;
    public Text Fire;
    public Text Boat;
    public Text Hut;
    public Text Day;
    public Text InfoText;
    int selected = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        Water.text = "Water: " + GameManager.WaterAmount.ToString();
        Wood.text = "Wood: " + GameManager.WoodAmount.ToString();
        Fish.text = "Fish: " + GameManager.FishAmount.ToString();
        Fruit.text = "Fruit: " + GameManager.FruitAmount.ToString();
        Fire.text = "Fire: " + GameManager.FirePower.ToString();
        Boat.text = "Boat: " + GameManager.BoatCompletion.ToString();
        if (GameManager.HutLevel == 3)
        {
            Hut.text = "Hut: 3/3";
        }
        else
        {
            Hut.text = "Hut: " + GameManager.HutCompletion.ToString() + " | " + GameManager.HutLevel.ToString() + "/3";
        }
        
        Day.text = "Day: " + GameManager.Days.ToString();
        InfoText.text = Operation.InfoText;
	}

    public void ChangeInfoText(string text)
    {
        InfoText.text = text;
    }

    public void UpdateFields()
    {
        Water.text = "Water: " + GameManager.WaterAmount.ToString();
        Wood.text = "Wood: " + GameManager.WoodAmount.ToString();
        Fish.text = "Fish: " + GameManager.FishAmount.ToString();
        Fruit.text = "Fruit: " + GameManager.FruitAmount.ToString();
        Fire.text = "Fire: " + GameManager.FirePower.ToString();
        Boat.text = "Boat: " + GameManager.BoatCompletion.ToString();
        Hut.text = "Hut: " + GameManager.HutCompletion.ToString() + " | " + GameManager.HutLevel.ToString() + "/3";
        Day.text = "Day: " + GameManager.Days.ToString();
        InfoText.text = Operation.InfoText;
    }
}
