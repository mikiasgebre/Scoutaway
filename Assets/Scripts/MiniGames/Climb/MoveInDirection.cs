using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [Tooltip("Choose which way to move the object")]
    public ForcedMoveDirection ForcedMovement = ForcedMoveDirection.Right;
    [Tooltip("Moving speed")]
    public float Speed = 4;
    bool moving;

    public enum ForcedMoveDirection
    {
        Left,
        Right,
        Up,
        Down,
        Angle
    }

    public void Move()
    {
        moving = true;
    }

    public void Stop()
    {
        moving = false;
    }

    private void Update()
    {
        if (moving)
        {
            if (ForcedMovement == ForcedMoveDirection.Right)
            {
                transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
            }
            else if (ForcedMovement == ForcedMoveDirection.Left)
            {
                transform.position += new Vector3(-1, 0, 0) * Speed * Time.deltaTime;
            }
            else if (ForcedMovement == ForcedMoveDirection.Up)
            {
                transform.position += new Vector3(0, 1, 0) * Speed * Time.deltaTime;
            }
            else if (ForcedMovement == ForcedMoveDirection.Down)
            {
                transform.position += new Vector3(0, -1, 0) * Speed * Time.deltaTime;
            }
        }
    }
}