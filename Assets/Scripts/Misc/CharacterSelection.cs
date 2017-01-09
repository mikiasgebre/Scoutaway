using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour
{

    public Canvas StatCanvas;
    private Actor actor;
    private string characterName;
    public int lastChar;
    public List<Actor> actorList;
    public GameObject SelectedCharacter1;
    public GameObject SelectedCharacter2;
    public GameObject SelectedCharacter3;
    public GameObject SelectedCharacter4;
    public GameObject[] CharacterSlotList;
    List<Operation> steveline;
    List<Operation> josephine;
    List<Operation> linda;
    List<Operation> steve;
    List<Operation> vuohi;
    List<Operation> edward;
    List<Operation> ernest;
    List<Operation> unicorn;

    void Start()
    {
        CreateCharacters();
        CharacterSlotList = new GameObject[4];
        CharacterSlotList[0] = SelectedCharacter1;
        CharacterSlotList[1] = SelectedCharacter2;
        CharacterSlotList[2] = SelectedCharacter3;
        CharacterSlotList[3] = SelectedCharacter4;
    }

    public void CreateCharacters()
    {
        InitializeCharacters();
        actorList = new List<Actor>();
        actorList.Add(new Actor("Steveline", steveline, "Powah", new Sprite(), "Sprites/Characters/character4", new List<Badge>(), 0, 0.9f, 1.2f, 1, 1.1f, 0.8f));
        actorList.Add(new Actor("Josèphine", josephine, "Sombrero", new Sprite(), "Sprites/Characters/character3", new List<Badge>(), 0, 1.1f, 0.7f, 0.8f, 1.4f, 1.05f));
        actorList.Add(new Actor("Steve", steve, "Ropes", new Sprite(), "Sprites/Characters/character1", new List<Badge>(), 0, 0.5f, 0.75f, 1.2f, 1.3f, 1.1f));
        actorList.Add(new Actor("Linda", linda, "Cooking", new Sprite(), "Sprites/Characters/character2", new List<Badge>(), 0, 1.25f, 1.05f, 0.9f, 0.85f, 1.15f));
        actorList.Add(new Actor("Edward", edward, "Sparkling", new Sprite(), "Sprites/Characters/knight_stand_2", new List<Badge>(), 0, 1.3f, 1f, 0.95f, 0.7f, 1f));        
        actorList.Add(new Actor("Vuohi", vuohi, "Lawnmower",new Sprite(), "Sprites/Characters/knight_stand_2", new List<Badge>(), 0, 1f, 0.65f, 1.35f, 1.01f, 0.99f));
        actorList.Add(new Actor("Ernest", ernest, "Skiing", new Sprite(), "Sprites/Characters/knight_stand_2", new List<Badge>(), 0, 0.9f, 0.95f, 0.87f, 1.13f, 1.43f));
        actorList.Add(new Actor("The Unicorn", unicorn, "Robots", new Sprite(), "Sprites/Characters/knight_stand_2", new List<Badge>(), 0, 1.18f, 1.08f, 0.68f, 1.02f, 0.88f));

        foreach (Actor a in actorList)
        {
            GameManager.LoadSprite(a);
        }
    }

    private void InitializeCharacters()
    {
        steveline = new List<Operation>();
        steveline.Add(new GetWood());
        steveline.Add(new GetWater());
        steveline.Add(new PlayHarmonica());
        steveline.Add(new Forage());

        josephine = new List<Operation>();
        josephine.Add(new GetWood());
        josephine.Add(new BuildBoat());
        josephine.Add(new PlayHarmonica());
        josephine.Add(new Forage());

        linda = new List<Operation>();
        linda.Add(new PlayHarmonica());
        linda.Add(new CreateCampfire());
        linda.Add(new BuildHut());
        linda.Add(new BuildBoat());

        steve = new List<Operation>();
        steve.Add(new GoFishing());
        steve.Add(new CreateCampfire());
        steve.Add(new PrepareFood());
        steve.Add(new BuildBoat());

        vuohi = new List<Operation>();
        vuohi.Add(new Forage());
        vuohi.Add(new CreateCampfire());
        vuohi.Add(new BuildHut());
        vuohi.Add(new PrepareFood());

        edward = new List<Operation>();
        edward.Add(new GetWood());
        edward.Add(new CreateCampfire());
        edward.Add(new BuildBoat());
        edward.Add(new GetWater());

        ernest = new List<Operation>();
        ernest.Add(new Forage());
        ernest.Add(new CreateCampfire());
        ernest.Add(new BuildBoat());
        ernest.Add(new GetWater());

        unicorn = new List<Operation>();
        unicorn.Add(new GetWood());
        unicorn.Add(new CreateCampfire());
        unicorn.Add(new PrepareFood());
        unicorn.Add(new GetWater());
    }
}