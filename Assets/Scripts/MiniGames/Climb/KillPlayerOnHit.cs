using UnityEngine;
using System.Collections;

public class KillPlayerOnHit : MonoBehaviour
{
    public UnityEngine.UI.Button b;
    MoveInDirection mid;

    void Start()
    {
        mid = FindObjectOfType<MoveInDirection>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ClimbingCharacterControls stcc = col.GetComponent<ClimbingCharacterControls>();
        if (stcc != null)
        {
            GameManager.BerryAmount += 2;
            Destroy(stcc.gameObject);
            StartCoroutine(ChangeSceneTimer());
            mid.Stop();
            b.interactable = false;
        }
    }

    IEnumerator ChangeSceneTimer()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel("MainGame");
    }
}