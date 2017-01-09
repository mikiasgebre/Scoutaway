using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    private FirewoodCalculator calc;
	// Use this for initialization
	void Start () {
        calc = FindObjectOfType<FirewoodCalculator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player")
        {
            GameManager.WoodAmount += calc.FirewoodAmount() * 4 + 20;
            print(calc.FirewoodAmount());
            Application.LoadLevel("MainGame");
        }
    }

}
