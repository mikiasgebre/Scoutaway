using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Acceleromet : MonoBehaviour
{
    public float MaximumAcceleration = 0.4f;
    public int FrameCount = 40;
    public float HillAffect;
    public float TargetAngle;
    public GameObject arrow;
    public float StartingWoodAmount;
    public float WoodAmount;
    public float DegenRate;
    public float minRandTime;
    public float maxRandTime;
    public float RandTime;
    public float minRandForce;
    public float maxRandForce;
    public Text text;
    private float RandForce;
    private float zeroAngle;
    private float last_x;
    private float x;
    /*private float total_x;
    private float avg_x;*/
    private List<float> acceleration;
    private float timer;
    private float lastPoint;


    // Use this for initialization
    void Start()
    {
        acceleration = new List<float>();
        RandForce = Random.Range(minRandForce, maxRandForce);
        RandTime = Random.Range(minRandTime, maxRandTime);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Wood amount: " + Mathf.RoundToInt(WoodAmount);
        if (timer > 15)
        {
            GameManager.WoodAmount += 20 + Mathf.RoundToInt(WoodAmount)/5;
            Application.LoadLevel("MainGame");
        }

        if (WoodAmount < 0)
        {
            print("All lost is wood");
            GameManager.WoodAmount += 20;
            Application.LoadLevel("MainGame");
        }

        timer += Time.deltaTime;

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
        /*total_x = 0;
        foreach (float f in acceleration)
        {
            total_x += f;
        }*/

        if (transform.rotation.eulerAngles.z > 330)
        {
            transform.rotation = Quaternion.Euler(0,0,1);
        }
        else if (transform.rotation.eulerAngles.z > 179)
        {
            transform.rotation = Quaternion.Euler(0, 0, 179);
        }

        TargetAngle = 90 - (last_x * 0.1f + x * 0.9f) * 100;

        /*avg_x = total_x / acceleration.Count;

        TargetAngle = 90 - (avg_x*3) * 100;*/

        //transform.rotation = Quaternion.Euler(0, 0, TargetAngle);

        arrow.transform.rotation = Quaternion.Euler(0, 0, TargetAngle-90);

        //print(arrow.transform.rotation.eulerAngles.z);

        zeroAngle = arrow.transform.rotation.eulerAngles.z;

        if (arrow.transform.rotation.eulerAngles.z > 180)
        {
            zeroAngle = arrow.transform.rotation.eulerAngles.z - 360;
        }

        WoodAmount -= DegenRate * Time.deltaTime;
        //print(WoodAmount);
        //print(Mathf.Abs(zeroAngle/20));

        //DegenRate = (Mathf.Abs(zeroAngle / 3));
        DegenRate = Mathf.Abs(90 - transform.rotation.eulerAngles.z)/2.5f;
        Debug.Log(DegenRate);

        //rigidbody2D.angularVelocity += ((TargetAngle - transform.rotation.eulerAngles.z) * 20) * Time.deltaTime;
        rigidbody2D.AddTorque((TargetAngle - transform.rotation.eulerAngles.z) * 5 * Time.deltaTime);
        //print(rigidbody2D.angularVelocity);

        //transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, TargetAngle), 0.1f));

        if (timer > lastPoint + RandTime)
        {
            lastPoint += RandTime;
            RandForce = Random.Range(minRandForce, maxRandForce);
            RandTime = Random.Range(minRandTime, maxRandTime);

            //rigidbody2D.angularVelocity += RandForce;
            //rigidbody2D.AddTorque(RandForce);
            //transform.Rotate(new Vector3(0, 0, RandForce));
            StartCoroutine("Nudge");
        }
        last_x = x;

    }

    IEnumerator Nudge()
    {
        for (int i = 0; i <= 10; i++)
        {
            yield return new WaitForFixedUpdate();
            rigidbody2D.AddTorque(RandForce);
        }
    }
}