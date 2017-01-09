using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("ActorStats")]
public struct ActorStats
{
    [XmlElement(typeof(float))]
    public float Fishing;
    [XmlElement(typeof(float))]
    public float Music;
    [XmlElement(typeof(float))]
    public float Nature;
    [XmlElement(typeof(float))]
    public float Craftsmanship;

    public ActorStats(float fishingBoost, float musicBoost, float natureBoost, float craftsmanshipBoost)
    {
        this.Fishing = 100 + fishingBoost;
        this.Music = 100 + musicBoost;
        this.Nature = 100 + natureBoost;
        this.Craftsmanship = 100 + craftsmanshipBoost;
    }
}
