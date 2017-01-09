using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Actor")]
public class Actor
{
    [XmlElement(typeof(string))]
    public string SpecialSkill;
    [XmlElement(typeof(string))]
    public string Name;
    [XmlElement(typeof(ActorNeeds))]
    public ActorNeeds Needs;
    [XmlArray("AvailableOperations"), XmlArrayItem(typeof(BuildBoat)), XmlArrayItem(typeof(BuildHut)), XmlArrayItem(typeof(CreateCampfire)), XmlArrayItem(typeof(Forage)), XmlArrayItem(typeof(GetWater)), XmlArrayItem(typeof(GetWood)), XmlArrayItem(typeof(GoFishing)), XmlArrayItem(typeof(PlayHarmonica)), XmlArrayItem(typeof(PrepareFood))]
    public List<Operation> AvailableOperations;
    [XmlElement(typeof(ActorStats))]
    public ActorStats Stats;
    //[XmlArray("Badges")]
    //[XmlArrayItem(typeof(Badge))]
    [XmlIgnore]
    public List<Badge> Badges;
    [XmlElement(typeof(int))]
    public int OperationsAvailable;
    [XmlIgnore]
    public Sprite Sprite;
    [XmlElement(typeof(string))]
    public string SpritePath;
    [XmlElement(typeof(string))]
    public string SpriteString;
    [XmlElement(typeof(int))]
    public int IndexInParty;
    [XmlElement(typeof(float))]
    public float HungerFactor;
    [XmlElement(typeof(float))]
    public float ThirstFactor;
    [XmlElement(typeof(float))]
    public float WarmthFactor;
    [XmlElement(typeof(float))]
    public float EntertainmentFactor;
    [XmlElement(typeof(float))]
    public float MotivationFactor;

    public Actor()
    { }

    public Actor(string name, List<Operation> availableOperations, string specialSkill, Sprite sprite, string spritePath, List<Badge> badges, int indexInParty, float warmthFactor, float hungerFactor, float thirstFactor, float entertainmentFactor, float motivationFactor)
    {
        this.Name = name;
        this.AvailableOperations = availableOperations;
        this.SpecialSkill = specialSkill;
        this.OperationsAvailable = 1;
        this.Sprite = sprite;
        this.SpritePath = spritePath;
        this.Badges = badges;
        this.WarmthFactor = warmthFactor;
        this.HungerFactor = hungerFactor;
        this.ThirstFactor = thirstFactor;
        this.EntertainmentFactor = entertainmentFactor;
        this.MotivationFactor = motivationFactor;

        if (sprite != null)
            this.SpriteString = sprite.name;
    }
}