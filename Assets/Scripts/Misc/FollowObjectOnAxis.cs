using UnityEngine;
using System.Collections.Generic;

public enum Axes 
{
    x,
    y,
    xy
}

public class FollowObjectOnAxis : MonoBehaviour
{
    [Tooltip("The target this gameobject will follow. If none, follows Main Camera")]
    public Transform Target;
    [Tooltip("Whether to follow the target only on X or Y axes, or both")]
    public Axes AxesToFollow;
    [Tooltip("Keep the starting distance to the target object")]
    public bool KeepStartOffset;
    public bool TargetIsMouse;
    [HideInInspector]
    public float offsetX, offsetY;
    private Vector3 targetPosition;

    private void Start()
    {
        if (Target == null)
        {
            Target = Camera.main.transform;
        }
        offsetX = transform.position.x - Target.transform.position.x;
        offsetY = transform.position.y - Target.transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (TargetIsMouse)
        {
            targetPosition = Input.mousePosition;
            targetPosition.z = transform.position.z - Camera.main.transform.position.z;
            targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        }
        else
        {
            targetPosition = Target.position;
        }

        if (KeepStartOffset)
        {
            targetPosition += new Vector3(offsetX, offsetY);
        }

        if (AxesToFollow == Axes.xy)
        {
            transform.position = targetPosition;
        }
        else if (AxesToFollow == Axes.x)
        {
            transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
        }
    }
}