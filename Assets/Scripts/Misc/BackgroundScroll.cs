using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float ScrollSpeedX = 1;
    public float ScrollSpeedY = 1;
    private Vector2 size;
    private Renderer myRenderer;

    private void Start()
    {
        size = new Vector2(-ScrollSpeedX / 100, -ScrollSpeedY / 100);

        if (renderer == null)
        {
            enabled = false;
        }
    }

    private void Update()
    {
        Vector2 offset = new Vector2(Camera.main.transform.position.x * size.x, 1 + (size.y * Camera.main.transform.position.y));

        if (offset.x > 1)
        {
            offset = new Vector2(offset.x - (float)System.Math.Truncate(offset.x), offset.y);
        }

        if (offset.x < -1)
        {
            offset = new Vector2(offset.x - (float)System.Math.Truncate(offset.x), offset.y);
        }

        if (offset.y > 1)
        {
            offset = new Vector2(offset.x, offset.y - (float)System.Math.Truncate(offset.y));
        }

        if (offset.y < -1)
        {
            offset = new Vector2(offset.x, offset.y - (float)System.Math.Truncate(offset.y));
        }

        renderer.material.SetTextureOffset("_MainTex", offset);
    }
}