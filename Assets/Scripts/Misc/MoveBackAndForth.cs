using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public Axes AxisToMove;
    [Tooltip("How the object moves over time")]
    public MoveWaveformType MoveType = MoveWaveformType.Sine;
    [Tooltip("The time it takes from max localPosition to min localPosition(1 = 1 sec, 2 = 2 sec etc..")]
    public float PeakAmplitudeTime = 1f;
    [Tooltip("The added localPosition gameobject will have at max localPosition(negative values possible)")]
    public float PeakAmplitudeHeight = 2f;
    private float timer = 0f;
    private bool up = true;
    private Vector3 startPos;

    public enum MoveWaveformType
    {
        Sine,
        Triangle,
        Square
    }

    // Use this for initialization
    private void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        if (MoveType != MoveWaveformType.Sine)
        {
            if (up)
            {
                timer += Time.deltaTime / PeakAmplitudeTime;

                if (timer >= 1)
                {
                    up = false;
                }
            }
            else
            {
                timer -= Time.deltaTime / PeakAmplitudeTime;
                if (timer <= 0)
                {
                    up = true;
                }
            }

            if (MoveType == MoveWaveformType.Triangle)
            {
                if (AxisToMove == Axes.y)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(startPos.y, startPos.y + PeakAmplitudeHeight, timer), startPos.z);
                }
                else if (AxisToMove == Axes.x)
                {
                    transform.localPosition = new Vector3(Mathf.Lerp(startPos.x, startPos.x + PeakAmplitudeHeight, timer), transform.localPosition.y, startPos.z);
                }
                else if (AxisToMove == Axes.xy)
                {
                    transform.localPosition = new Vector3(Mathf.Lerp(startPos.x, startPos.x + PeakAmplitudeHeight, timer), Mathf.Lerp(startPos.y, startPos.y + PeakAmplitudeHeight, timer), startPos.z);
                }
            }
            else
            {
                if (up)
                {
                    if (AxisToMove == Axes.y)
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x, startPos.y + PeakAmplitudeHeight, startPos.z);
                    }
                    else if (AxisToMove == Axes.x)
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x + PeakAmplitudeHeight, startPos.y, startPos.z);
                    }
                    else if (AxisToMove == Axes.xy)
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x + PeakAmplitudeHeight, startPos.y + PeakAmplitudeHeight, startPos.z);
                    }
                }
                else
                {
                    if (AxisToMove == Axes.y)
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x, startPos.y, startPos.z);
                    }
                    else if (AxisToMove == Axes.x)
                    {
                        transform.localPosition = new Vector3(startPos.x, transform.localPosition.y, startPos.z);
                    }
                    else if (AxisToMove == Axes.xy)
                    {
                        transform.localPosition = new Vector3(startPos.x, startPos.y, startPos.z);
                    }
                }
            }
        }
        else
        {
            timer += Time.deltaTime / PeakAmplitudeTime * Mathf.PI / 2;
            if (AxisToMove == Axes.y)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, startPos.y + PeakAmplitudeHeight * (Mathf.Sin(timer) + 1) / 2, startPos.z);
            }
            else if (AxisToMove == Axes.x)
            {
                transform.localPosition = new Vector3(startPos.x + PeakAmplitudeHeight * (Mathf.Sin(timer) + 1) / 2, transform.localPosition.y, startPos.z);
            }
            else if (AxisToMove == Axes.xy)
            {
                transform.localPosition = new Vector3(startPos.x + PeakAmplitudeHeight * (Mathf.Sin(timer) + 1) / 2, startPos.y + PeakAmplitudeHeight * (Mathf.Sin(timer) + 1) / 2, startPos.z);
            }
        }
    }
}