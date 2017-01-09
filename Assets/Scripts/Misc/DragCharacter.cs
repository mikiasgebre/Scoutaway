using UnityEngine;
using System.Collections;

public class DragCharacter : MonoBehaviour {
    private RectTransform rekt;
    private Camera cam;
    private Vector3 initialPosition;
    private GameObject initialParent;
    private Vector3 lastPosition;
    private GameObject lastParent;
    private bool dragTimerOn;
    private float dragTimer;
    private bool draggable;
    private CharacterSelection charSelect;
	// Use this for initialization
	void Start () {
        rekt = GetComponent<RectTransform>();
        cam = FindObjectOfType<Camera>();
        initialPosition = rekt.position;
        initialParent = rekt.parent.gameObject;
        charSelect = FindObjectOfType<CharacterSelection>();
        transform.parent.GetComponent<RectTransform>().offsetMax = new Vector2(341.51f, 0);
        transform.parent.GetComponent<RectTransform>().offsetMin = new Vector2(341.51f, 0);
	}


    /*public void Drag()
    {
        rekt.position = Input.mousePosition;
    }

    public void EndDrag()
    {
        draggable = false;
        dragTimerOn = false;
        dragTimer = 0;
    }

    public void StartDrag()
    {
        rekt.parent = initialParent.transform;
        lastParent = rekt.parent.gameObject;
        lastPosition = rekt.position;
    }*/

    public void MoveCharacter()
    {
        if (transform.parent.gameObject == initialParent)
        {
            foreach (GameObject go in charSelect.CharacterSlotList)
            {
                if (go.transform.childCount == 0)
                {
                    transform.parent = go.transform;
                    transform.position = go.transform.position;
                    break;
                }
            }
        }
        else
        {
            rekt.parent = initialParent.transform;
            rekt.localPosition = initialPosition;
            rekt.offsetMax = Vector2.zero;
            rekt.offsetMin = Vector2.zero;
        }


        /*rekt.parent = initialParent.transform;
        lastParent = rekt.parent.gameObject;
        lastPosition = rekt.position;*/
    }

}
