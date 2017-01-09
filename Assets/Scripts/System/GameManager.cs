using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("Language")]
public enum Language
{
    [XmlEnum("English")]
    English,
    [XmlEnum("Finnish")]
    Finnish,
    [XmlEnum("Swedish")]
    Swedish
}

[XmlRoot("GameManager")]
public static class GameManager
{
    [XmlArray("Party")]
    [XmlArrayItem("Actor")]
    public static List<Actor> Party;
    [XmlElement(typeof(int))]
    public static int Days;
    [XmlElement(typeof(int))]
    public static int HutCompletion;
    [XmlElement(typeof(int))]
    public static int BoatCompletion;
    [XmlElement(typeof(int))]
    public static int WoodAmount;
    [XmlElement(typeof(int))]
    public static int FishAmount;
    [XmlElement(typeof(int))]
    public static int MushroomAmount;
    [XmlElement(typeof(int))]
    public static int BerryAmount;
    [XmlElement(typeof(int))]
    public static int FruitAmount;
    [XmlElement(typeof(int))]
    public static int MealAmount;
    [XmlElement(typeof(int))]
    public static int WaterAmount;
    [XmlElement(typeof(int))]
    public static int FirePower;
    [XmlElement(typeof(int))]
    public static int HutLevel;
    [XmlElement(typeof(Language))]
    public static Language SelectedLanguage;
    [XmlElement(typeof(float))]
    public static float EffectVolume;
    [XmlElement(typeof(float))]
    public static float MusicVolume;
    [XmlElement(typeof(bool))]
    public static bool EffectMuted;
    [XmlElement(typeof(bool))]
    public static bool MusicMuted;

    public static void Reset()
    {
        Party = new List<Actor>();
        Days = 1;
        HutCompletion = 0;
        BoatCompletion = 0;
        WoodAmount = 0;
        MealAmount = 0;
        FishAmount = 0;
        BerryAmount = 0;
        MushroomAmount = 0;
        WaterAmount = 0;
        FruitAmount = 0;
        FirePower = 0;
        HutLevel = 0;
    }

    public static void LoadSprite(Actor a)
    {
        a.Sprite = Resources.Load<Sprite>(a.SpritePath);
    }
}