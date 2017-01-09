using UnityEngine;
using System.Collections.Generic;

public class FishingFishAI : MonoBehaviour
{
    public static List<FishingFishAI> FishList;
    float timer;
    float speed;
    FishingControl fc;

    void Awake()
    {
        fc = FindObjectOfType<FishingControl>();
    }

    void Start()
    {
        RandomSpeed();
        timer = Random.Range(1.5f, 4f);
        FishList.Add(this);
    }

    void Update()
    {
        #region timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            RandomSpeed();
            timer = Random.Range(1.5f, 4f);
        }
        #endregion
        transform.position += transform.right * speed * 4 * Time.deltaTime;
        if (transform.position.x < -12 || transform.position.x > 12)
        {
            fc.KillFish();
            FishList.Remove(this);
            gameObject.Destroy();
        }
    }

    void RandomSpeed()
    {
        speed = Random.Range(0.4f, 1.4f);    
    }
}