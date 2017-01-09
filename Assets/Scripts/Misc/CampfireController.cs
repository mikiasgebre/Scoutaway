using UnityEngine;
using System.Collections;

public class CampfireController : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void UpdateCampfire()
    {
        if (GameManager.FirePower > 0)
        {
            animator.SetBool("OnFire", true);
        }
        else
        {
            animator.SetBool("OnFire", false);
        }
    }
}
