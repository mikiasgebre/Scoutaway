using UnityEngine;
using System.Collections;

public class ForceMovement : MonoBehaviour {
    public float MovementSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.rigidbody2D.velocity = new Vector3(MovementSpeed, transform.rigidbody2D.velocity.y, 0);
	}
}
