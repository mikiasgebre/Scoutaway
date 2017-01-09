using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirewoodCalculator : MonoBehaviour
{
    private BoxCollider2D Area;
    private List<GameObject> FirewoodList;
    // Use this for initialization
    void Start()
    {
        FirewoodList = new List<GameObject>();
        Area = GetComponent<BoxCollider2D>();
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (!FirewoodList.Contains(col.gameObject))
        {
            FirewoodList.Add(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!FirewoodList.Contains(col.gameObject))
        {
            FirewoodList.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (FirewoodList.Contains(col.gameObject))
        {
            FirewoodList.Remove(col.gameObject);
        }
    }

    public int FirewoodAmount()
    {
        return FirewoodList.Count;
    }
}