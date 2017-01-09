using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AccelerationWatcher : MonoBehaviour
{
    public float MaximumAcceleration = 0.4f;
    public int FrameCount = 40;
    public float HillAffect;
    private float TargetAngle;
    private float x;
    private float total_x;
    private float avg_x;
    private List<float> acceleration;

    // Use this for initialization
    void Start()
    {
        acceleration = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.acceleration.x;

        if (acceleration.Count < FrameCount)
        {
            acceleration.Add(x);
        }
        else
        {
            acceleration.RemoveAt(0);
            acceleration.TrimExcess();
            acceleration.Add(x);
        }
        total_x = 0;
        foreach (float f in acceleration)
        {
            total_x += f;
        }

        TargetAngle = 90 - (avg_x) * 100;

        /*if (TargetAngle > 330)
        {
            TargetAngle = 360;
        }
        else if (TargetAngle > 180)
        {
            TargetAngle = 180;
        }*/

        avg_x = total_x / acceleration.Count;

        if (x > MaximumAcceleration)
        {
            x = MaximumAcceleration;
        }
        else if (x < -MaximumAcceleration)
        {
            x = -MaximumAcceleration;
        }

        /*if (TargetAngle > transform.parent.transform.rotation.eulerAngles.z)
        {
            print(TargetAngle + " > " + transform.parent.transform.rotation.eulerAngles.z);
            transform.parent.transform.rigidbody2D.angularVelocity = (TargetAngle-transform.parent.transform.rotation.eulerAngles.z)*10;
            //transform.parent.transform.rigidbody2D.angularVelocity = TargetAngle - transform.rotation.eulerAngles.z;
        }
        else
        {
            print(TargetAngle + " < " + transform.parent.transform.rotation.eulerAngles.z);
            transform.parent.transform.rigidbody2D.angularVelocity = (TargetAngle - transform.parent.transform.rotation.eulerAngles.z) * 10;
            //transform.parent.transform.rigidbody2D.angularVelocity = TargetAngle - transform.rotation.eulerAngles.z;
        }*/

        /*if (transform.parent.transform.rotation.eulerAngles.z > 180)
        {
            GameManager.WoodAmount += 20;
            Application.LoadLevel("MainGame");
        }*/

        //transform.parent.transform.rigidbody2D.angularVelocity = ((TargetAngle - transform.parent.transform.rotation.eulerAngles.z) * 20) * Time.deltaTime;
        transform.parent.transform.rigidbody2D.angularVelocity = HillAffect * Time.deltaTime * 80;
        print(HillAffect + " : " + ((TargetAngle - transform.parent.transform.rotation.eulerAngles.z) * 10) * Time.deltaTime + " : " + transform.parent.transform.rigidbody2D.angularVelocity);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        //transform.parent.rigidbody2D.AddForce(new Vector2(avg_x * 100 * Time.deltaTime, 0));
        
    }
}