using UnityEngine;
using System.Collections;

public class StoneThrowCharacterControls : MonoBehaviour
{
    public GameObject Stone;
    public float ThrowPower = 12;
    ArrowControl ac;
    public int Stones;
    float shootCooldown;
    bool shooting;
    bool arrowMoving;
    bool arrowIncreasing;
    float arrowTimer;
    Vector3 startScale;
    public int fruitsDropped;
    Transform child;

    public void Shoot()
    {
        if (shooting && Stones > 0)
        {
            if (shootCooldown <= 0)
            {
                GameObject go = (GameObject)Instantiate(Stone, transform.position, transform.rotation);
                go.rigidbody2D.velocity = new Vector2(ThrowPower * arrowTimer, 0).Rotate(ac.angle);
                go.rigidbody2D.angularVelocity = Random.Range(-100f, 100f);
                shootCooldown = 0.2f;
                Stones--;
                arrowMoving = false;
                ac.StartMoving();
                shooting = false;
                child.localScale = startScale;
                if (Stones <= 0)
                {
                    ac.Hide();
                    GameManager.FruitAmount += fruitsDropped + 2;
                }
            }
        }
        else if (Stones > 0)
        {
            if (shootCooldown <= 0)
            {
                ac.StopMoving();
                arrowTimer = Random.Range(0f, 1f);
                arrowMoving = true;
                shooting = true;
            }
        }
    }

    public IEnumerator ChangeSceneTimer()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("MainGame");
    }

    void Start()
    {
        child = transform.GetChild(0);
        ac = GetComponentInChildren<ArrowControl>();
        Stones = 3;
        startScale = child.localScale;
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;
        if (arrowMoving)
        {
            if (arrowIncreasing)
            {
                arrowTimer += Time.deltaTime;
                if (arrowTimer >= 1)
                {
                    arrowIncreasing = false;
                }
            }
            else
            {
                arrowTimer -= Time.deltaTime;
                if (arrowTimer <= 0)
                {
                    arrowIncreasing = true;
                }
            }

            child.localScale = startScale * arrowTimer; 
        }
    }
}