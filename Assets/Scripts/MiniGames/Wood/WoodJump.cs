using UnityEngine;
using System.Collections;

public class WoodJump : MonoBehaviour
{
    public GameObject Player;
    public float JumpCooldown = 1;
    public bool ShowGroundCheck;
    [Tooltip("Groundcheck lines determine if the player is grounded. If one line hits Ground layer, player is grounded")]
    public float GroundCheckLength = 0.6f;
    [Tooltip("Groundcheck line quantity")]
    public int GroundCheckQuantity = 2;
    [Tooltip("Width of groundcheck lines")]
    public float GroundCheckSpacing = 1;
    [Tooltip("Position for groundcheck lines.")]
    public Vector2 GroundCheckPosition = new Vector2(0, 0);
    private bool IsJumping;
    private bool Grounded;
    private bool JumpTimerRunning = false;
    private float JumpTimer;
    private RaycastHit2D leftRay;
    private RaycastHit2D rightRay;
    private AccelerationWatcher accelWatcher;
    // Use this for initialization
    void Start()
    {
        accelWatcher = Player.GetComponentInChildren<AccelerationWatcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpTimerRunning)
        {
            JumpTimer += Time.deltaTime;
            if (JumpTimer > JumpCooldown)
            {
                JumpTimer = 0;
                JumpTimerRunning = false;
            }
        }

        for (int i = 1; i < GroundCheckQuantity + 1; i++)
        {
            if (Physics2D.Linecast(new Vector2((Player.transform.position.x - (GroundCheckSpacing / 2) + (GroundCheckSpacing / (GroundCheckQuantity + 1)) * i) + GroundCheckPosition.x, Player.transform.position.y + GroundCheckPosition.y), new Vector2((Player.transform.position.x - (GroundCheckSpacing / 2) + (GroundCheckSpacing / (GroundCheckQuantity + 1)) * i) + GroundCheckPosition.x, (Player.transform.position.y - GroundCheckLength) + GroundCheckPosition.y), 1 << LayerMask.NameToLayer("Ground")))
            {
                IsJumping = false;
                Grounded = true;
                break;
            }
            else
            {
                Grounded = false;
            }
        }
        rightRay = Physics2D.Raycast(new Vector2(Player.transform.position.x + 1.5f, Player.transform.position.y + 10), -Vector2.up, 20, 1 << LayerMask.NameToLayer("Ground"));
        leftRay = Physics2D.Raycast(new Vector2(Player.transform.position.x - 1.5f, Player.transform.position.y + 10), -Vector2.up, 20, 1 << LayerMask.NameToLayer("Ground"));
        print(rightRay.distance + " : " + leftRay.distance);
        if (rightRay.collider != null && leftRay.collider != null)
        {
            if (rightRay.distance > leftRay.distance)
            {
                //oikeella pidempi --> alamäki
                accelWatcher.HillAffect = (rightRay.distance - leftRay.distance) * 10;
            }
            else
            {
                accelWatcher.HillAffect = (rightRay.distance - leftRay.distance) * 10;
            }
            //print(accelWatcher.HillAffect);
        }
    }


    private void OnDrawGizmos()
    {
        if (ShowGroundCheck)
        {
            for (int i = 1; i < GroundCheckQuantity + 1; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(new Vector2((Player.transform.position.x - (GroundCheckSpacing / 2) + (GroundCheckSpacing / (GroundCheckQuantity + 1)) * i) + GroundCheckPosition.x, Player.transform.position.y + GroundCheckPosition.y), new Vector2((Player.transform.position.x - (GroundCheckSpacing / 2) + (GroundCheckSpacing / (GroundCheckQuantity + 1)) * i) + GroundCheckPosition.x, (Player.transform.position.y - GroundCheckLength) + GroundCheckPosition.y));
            }

            Gizmos.DrawRay(new Vector2(Player.transform.position.x + 1.5f, Player.transform.position.y + 10), -Vector2.up*20);
            Gizmos.DrawRay(new Vector2(Player.transform.position.x - 1.5f, Player.transform.position.y + 10), -Vector2.up*20);
        
            Gizmos.DrawRay(new Vector2(Player.transform.position.x + 1.5f, Player.transform.position.y+10), -Vector2.up);
            
        }
    }
    public void PlayerJump()
    {
        if (Grounded && !JumpTimerRunning)
        {
            JumpTimerRunning = true;
            print(Grounded + " : " + JumpTimerRunning);
            Player.rigidbody2D.velocity = new Vector2(Player.rigidbody2D.velocity.x, Player.rigidbody2D.velocity.y + 6);
        }
    }
}