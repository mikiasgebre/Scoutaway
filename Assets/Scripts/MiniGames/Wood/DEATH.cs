using UnityEngine;
using System.Collections;

public class DEATH : MonoBehaviour {
    public GameObject DeathCausingGameobject;
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject == DeathCausingGameobject)
        {
            GameManager.WoodAmount += 20;
            Application.LoadLevel("MainGame");
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject == DeathCausingGameobject)
        {
            GameManager.WoodAmount += 20;
            Application.LoadLevel("MainGame");
        }
    }
}
