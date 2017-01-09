using UnityEngine;
using System.Collections;

public class StoneControl : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        ClimbingCharacterControls cc = col.GetComponent<ClimbingCharacterControls>();
        if (cc != null)
        {
            cc.hanging = true;
            cc.transform.position = transform.position;
            cc.ac.Show();
        }

        Destroy(this);
    }
}
