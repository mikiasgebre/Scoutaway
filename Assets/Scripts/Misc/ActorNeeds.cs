using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("ActorNeeds")]
public struct ActorNeeds
{
    [XmlElement(typeof(float))]
    public float Warmth;
    [XmlElement(typeof(float))]
    public float Hunger;
    [XmlElement(typeof(float))]
    public float Entertainment;
    [XmlElement(typeof(float))]
    public float Thirst;
    [XmlElement(typeof(float))]
    public float Motivation;

    /*public ActorNeeds()
    {
        this.Warmth = -1f;
        this.Hunger = -1f;
        this.Thirst = -1f;
        this.Entertainment = -1f;
        this.Motivation = -1f;
    }*/
}
