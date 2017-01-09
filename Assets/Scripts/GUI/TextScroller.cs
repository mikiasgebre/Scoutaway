using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScroller : MonoBehaviour 
{
    public float ScrollSpeed = 25f;
    public float ScrollTime = 20f;
    private float timer;

    void Start()
    {
        timer = ScrollTime;
    }

    // Use this for initialization
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * ScrollSpeed;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
