using UnityEngine;
using System.Collections;

public class StoneThrowBoundaryControl : MonoBehaviour
{
    StoneThrowCharacterControls stcc;
    int stones;

    void Start()
    {
        stones = 0;
        stcc = FindObjectOfType<StoneThrowCharacterControls>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        StoneThrowProjectileControl stpc = col.collider.GetComponent<StoneThrowProjectileControl>();
        if (stpc != null)
        {
            stpc.gameObject.Destroy();
            stones++;
            if (stones >= 3)
            {
                StartCoroutine(stcc.ChangeSceneTimer());
            }
        }
    }
}