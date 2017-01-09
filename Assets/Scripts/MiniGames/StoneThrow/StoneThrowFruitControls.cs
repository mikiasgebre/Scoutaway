using UnityEngine;
using System.Collections;

public class StoneThrowFruitControls : MonoBehaviour
{
    StoneThrowCharacterControls stcc;

    void Start()
    {
        stcc = FindObjectOfType<StoneThrowCharacterControls>();
        transform.position = transform.position + new Vector3(Random.Range(0f, 2f), Random.Range(0f, 2f), 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StoneThrowProjectileControl stpc = col.GetComponent<StoneThrowProjectileControl>();
        if (stpc != null)
        {
            rigidbody2D.gravityScale = 1;
            rigidbody2D.velocity = col.rigidbody2D.velocity / 2f;
            rigidbody2D.angularVelocity = Random.Range(-40f, 40f);
            stcc.fruitsDropped++;
        }
    }
}