using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishingControl : MonoBehaviour 
{
    enum FishingState
    { 
        Ready,
        Swinging,
        Cooldown
    }

    public GameObject Haavi;
    int deadFishes;
    int fishes;
    Animator anim;
    Vector2 pos;
    bool pushIt;
    float timer;
    FishingState state;
    SpriteRenderer haaviSprite;

    void Awake()
    {
        fishes = 0;
        deadFishes = 0;
        state = FishingState.Ready;
        anim = Haavi.GetComponent<Animator>();
        haaviSprite = Haavi.GetComponent<SpriteRenderer>();
        FishingFishAI.FishList = new List<FishingFishAI>();
    }

    private void GetPos()
    {
        pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
    }

    void Update()
    {
        if (pushIt && state == FishingState.Ready)
        {
            GetPos();
            timer = 1f;
            state = FishingState.Swinging;
            anim.SetTrigger("Heilautus");
            Haavi.transform.position = pos;
            haaviSprite.enabled = true;
        }
        else if (timer <= 0 && state == FishingState.Swinging)
        {
            if (FishingFishAI.FishList != null)
            {
                foreach (FishingFishAI fish in FishingFishAI.FishList)
                {
                    if (fish.collider2D.OverlapPoint(pos))
                    {
                        FishingFishAI.FishList.Remove(fish);
                        GameObject.Destroy(fish.gameObject);
                        fishes++;
                        KillFish();
                        break;
                    }
                }
            }

            state = FishingState.Cooldown;
            timer = 0.5f;
        }
        else if (timer <= 0 && state == FishingState.Cooldown)
        {
            haaviSprite.enabled = false;
            state = FishingState.Ready;
        }

        if (state != FishingState.Ready)
        {
            timer -= Time.deltaTime;
        }
    }

    public void KillFish()
    {
        deadFishes++;
        if (deadFishes >= 4)
        {
            StartCoroutine(LoadMainGame());
        }
    }

    IEnumerator LoadMainGame()
    {
        yield return new WaitForSeconds(1.2f);
        Application.LoadLevel("MainGame");
    }

    public void ButtonReleased()
    {
        pushIt = false;
    }

    public void ButtonPressed()
    {
        pushIt = true;
    }
}