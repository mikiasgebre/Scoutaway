using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour
{
    public GameObject Scout;
    public List<Operation> Operations;
    public GameObject Campfire;
    private SpriteRenderer[] hutStages;
    private Vector3[] characterCoordinates; 

    // Use this for initialization
    void Awake()
    {
        GameObject.Find("Day").GetComponent<Text>().text = "Day " + GameManager.Days;
      /*  GameManager.Reset();
        List<Operation> op = new List<Operation>();
        List<Badge> b = new List<Badge>();
        op.Add(new GetWater());
        op.Add(new GetWood());
        op.Add(new GoFishing());
        op.Add(new CreateCampfire());
        op.Add(new BuildBoat());
        op.Add(new BuildHut());
        List<Operation> op2 = new List<Operation>();
        op2.Add(new GetWater());
        op2.Add(new GetWood());
        op2.Add(new GoFishing());
        op2.Add(new CreateCampfire());
        op2.Add(new PlayHarmonica());
        op2.Add(new Forage());
        Sprite sprite = Resources.Load<Sprite>("Sprites/Checkpoint");
        GameManager.Party.Add(new Actor("Jeesus", op, "morottelu", sprite, b, 0));
        GameManager.Party.Add(new Actor("Jeesus2", op2, "morottelu", sprite, b, 0));*/
        characterCoordinates = new Vector3[5];
        characterCoordinates[0] = new Vector3(-2, -1.5f);
        characterCoordinates[1] = new Vector3(-3f, 0.4f);
        characterCoordinates[2] = new Vector3(3.2f, -2);
        characterCoordinates[3] = new Vector3(-0.4f, -0.5f);
        characterCoordinates[4] = new Vector3(5.4f, -1.1f);

            for (int i = 0; i < GameManager.Party.Count; i++)
            {
                GameManager.LoadSprite(GameManager.Party[i]);
                GameObject go = (GameObject)GameObject.Instantiate(Scout);
                go.name = GameManager.Party[i].Name;
                //go.transform.position += new Vector3(-i * 5.2f + 8, 0);
                if (go.name == "Steveline")
                {
                    go.transform.position = characterCoordinates[4];
                }
                else
                {
                    go.transform.position = characterCoordinates[i];
                }
                
                go.GetComponent<SpriteRenderer>().sprite = GameManager.Party[i].Sprite;
                go.AddComponent<ShowPanel>();
                ShowPanel sP = go.GetComponent<ShowPanel>();
                sP.ActorID = i;
                GameManager.Party[i].IndexInParty = i;
                InitializeNeeds(GameManager.Party[i]);
        }
    }

    private void Start()
    {
       hutStages = GameObject.Find("Lean To").GetComponentsInChildren<SpriteRenderer>();

       for (int i = 0; i < hutStages.Length; i++)
       {
           hutStages[i].enabled = false;
       }

       Campfire = GameObject.Find("Campfire");
       Campfire.SetActive(false);


    }

    private void InitializeNeeds(Actor actor)
    {
        if (actor.Needs.Warmth == 0 && actor.Needs.Thirst == 0 && actor.Needs.Hunger == 0 && actor.Needs.Motivation == 0 && actor.Needs.Entertainment == 0)
        {
            float[] needList = GetNeeds(5, 180);

            actor.Needs.Warmth = needList[0];
            actor.Needs.Hunger = needList[1];
            actor.Needs.Thirst = needList[2];
            actor.Needs.Entertainment = needList[3];
            actor.Needs.Motivation = needList[4];
        }
    }

    private static float[] GetNeeds(int count, float total)
    {
        const float NEEDMIN = 20;
        const float NEEDMAX = 50;

        float[] needList = new float[count];
        float currentSum = 0;
        float low, high, calc;

        /*if ((NEEDMAX * count) < total ||
            (NEEDMIN * count) > total ||
            NEEDMAX < NEEDMIN)
            print("Impossibru.");*/

        for (int index = 0; index < count; index++)
        {
            calc = (total - currentSum) - (NEEDMAX * (count - 1 - index));
            low = calc < NEEDMIN ? NEEDMIN : calc;
            calc = (total - currentSum) - (NEEDMIN * (count - 1 - index));
            high = calc > NEEDMAX ? NEEDMAX : calc;

            needList[index] = Random.Range(low, high + 1);
            
            currentSum += needList[index];
        }

        int shuffleCount = Random.Range(count * 5, count * 10);
        while (shuffleCount-- > 0)
            Shuffle(ref needList[Random.Range(0, count)], ref needList[Random.Range(0, count)]);

        return needList;
    }

    private static void Shuffle(ref float item1, ref float item2)
    {
        float temp = item1;
        item1 = item2;
        item2 = temp;
    }

    public void DrawHut(int index)
    {
        //hutStages[index].enabled = true;

        if (GameManager.HutLevel < 1)
        {
            hutStages[index].enabled = true;
        }
    }
}