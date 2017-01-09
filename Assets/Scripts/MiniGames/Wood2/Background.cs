using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public float scrollSpeed = 0.5F;
	
	// Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed/10;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
	}
}
