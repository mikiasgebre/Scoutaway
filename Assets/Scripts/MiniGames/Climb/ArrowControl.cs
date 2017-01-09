using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour 
{
    public float movingspeed;
    public float angle;
    bool showing;
    bool increasing;
    GameObject go;
    bool moving;

    void Start () 
    {
        increasing = true;
        moving = true;
        go = transform.GetChild(0).gameObject;
        angle = 20f;
    }

    public void Hide()
    {
        go.renderer.enabled = false;
    }

    public void Show()
    {
        go.renderer.enabled = true;
    }

    public void StartMoving()
    {
        moving = true;
    }

    public void StopMoving()
    {
        moving = false;
    }

    void Update()
    {
        if (moving)
        {
            if (increasing)
            {
                angle += Time.deltaTime * movingspeed;

                if (angle >= 160)
                {
                    increasing = false;
                }
            }
            else
            {
                angle -= Time.deltaTime * movingspeed;
                if (angle <= 20)
                {
                    increasing = true;
                }
            }

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
