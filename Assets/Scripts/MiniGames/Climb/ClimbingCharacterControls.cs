using UnityEngine;
using System.Collections;

public class ClimbingCharacterControls : MonoBehaviour 
{
    public float jumpPower;
    public float arrowSpeed;
    public bool hanging;
    public ArrowControl ac;
    public UnityEngine.UI.Button b;
    MoveInDirection mid;
    float startGravity;

    public void Jump()
    {
        mid.Move();
        ac.movingspeed += 3f;
        if (hanging)
        {
            ac.Hide();
            rigidbody2D.velocity = new Vector2(jumpPower, 0).Rotate(ac.angle);
            hanging = false;
        }
    }

	void Start()
    {
        startGravity = rigidbody2D.gravityScale;
        ac = FindObjectOfType<ArrowControl>();
        hanging = true;
        mid = FindObjectOfType<MoveInDirection>();
	}

    void Update()
    {
        if (transform.position.y > 60)
        {
            GameManager.BerryAmount += 2;
            StartCoroutine(ChangeSceneTimer());
            mid.Stop();
            b.interactable = false;
            hanging = true;
            ac.Hide();
        }
    }

    IEnumerator ChangeSceneTimer()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel("MainGame");
    }

    void FixedUpdate()
    {
        if (hanging)
        {
            rigidbody2D.gravityScale = 0;
            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            rigidbody2D.gravityScale = startGravity;
        }
    }
}
