using System.Collections;
using UnityEngine;

public class DestroyIfTooFarFromTarget : MonoBehaviour
{
    [Tooltip("Gameobject from which the distance is measured, if none, finds the Camera")]
    public Transform Target;
    public float DeleteDistance;
    [Tooltip("Delete gameobject if higher than target")]
    public bool DeleteUp;
    [Tooltip("Delete gameobject if lower than target")]
    public bool DeleteDown;
    [Tooltip("Delete gameobject if left from target")]
    public bool DeleteLeft;
    [Tooltip("Delete gameobject if right from target")]
    public bool DeleteRight;

    private void Start()
    {
        if (Target == null)
        {
            Target = Camera.main.transform;
        }
    }

    private void Update()
    {
        /* if the object is further than the maximum distance, destroy it */
        if (((transform.position.y < Target.transform.position.y - DeleteDistance) && DeleteDown) ||
            ((transform.position.y > Target.transform.position.y + DeleteDistance) && DeleteUp) ||
            ((transform.position.x > Target.transform.position.x + DeleteDistance) && DeleteRight) ||
            ((transform.position.x < Target.transform.position.x - DeleteDistance) && DeleteLeft))
        {
            Destroy(this.gameObject);
        }
    }
}