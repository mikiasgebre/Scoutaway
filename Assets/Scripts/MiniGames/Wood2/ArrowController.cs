using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
    private Acceleromet accel;
	// Use this for initialization
	void Start () {
        accel = FindObjectOfType<Acceleromet>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0,0,accel.TargetAngle);
	}
}
