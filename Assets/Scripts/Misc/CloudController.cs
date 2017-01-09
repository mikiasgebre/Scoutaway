using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
    private float DistanceToTeleport;
    public float MoveSpeed;
    private Transform parent;
    private Camera camera;
	// Use this for initialization
	void Start () 
    {
        parent = this.transform.parent;
        DistanceToTeleport = 15;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.transform.position.x < parent.position.x - DistanceToTeleport)
        {
            this.transform.position = new Vector3(parent.position.x + DistanceToTeleport, this.transform.position.y, this.transform.position.z);
        }
        this.transform.position = new Vector3(this.transform.position.x - MoveSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
	}
}
