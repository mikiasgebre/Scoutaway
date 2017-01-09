using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System;

public static class SaveData
{
    public static MiniGameData MiniGameData;

    public static  void Save()
    {
            SaveBlob sb = new SaveBlob();
            ReadGamemanager(sb);
            XmlSerializer ser = new XmlSerializer(typeof(SaveBlob));
            var s = new StringWriter();
            ser.Serialize(s, sb);
            PlayerPrefs.SetString("ScoutGameSave", s.ToString());
            s.Close();  
    }

    public static void Load()
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SaveBlob));
            var s = new StringReader(PlayerPrefs.GetString("ScoutGameSave"));
            SaveBlob container = serializer.Deserialize(s) as SaveBlob;
            WriteGamemanager(container);
            s.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public static void Clear()
    {
        // PlayerPrefs.DeleteKey("ScoutGameSave");
    }

    public static void CheckUnlockedBadges()
    {
    }

    public static void ReadGamemanager(SaveBlob blob)
    {
        if (GameManager.Party != null)
            blob.Party = new List<Actor>(GameManager.Party);
        blob.Days = GameManager.Days;
        blob.HutCompletion = GameManager.HutCompletion;
        blob.BoatCompletion = GameManager.BoatCompletion;
        blob.WoodAmount = GameManager.WoodAmount;
        blob.MealAmount = GameManager.MealAmount;
        blob.FishAmount = GameManager.FishAmount;
        blob.BerryAmount = GameManager.BerryAmount;
        blob.FruitAmount = GameManager.FruitAmount;
        blob.MushroomAmount = GameManager.MushroomAmount;
        blob.WaterAmount = GameManager.WaterAmount;
        blob.SelectedLanguage = GameManager.SelectedLanguage;
        blob.EffectVolume = GameManager.EffectVolume;
        blob.MusicVolume = GameManager.MusicVolume;
        blob.EffectMuted = GameManager.EffectMuted;
        blob.MusicMuted = GameManager.MusicMuted;
    }

    public static void WriteGamemanager(SaveBlob blob)
    {
        GameManager.Party = new List<Actor>(blob.Party);
        GameManager.Days = blob.Days;
        GameManager.HutCompletion = blob.HutCompletion;
        GameManager.BoatCompletion = blob.BoatCompletion;
        GameManager.WoodAmount = blob.WoodAmount;
        GameManager.MealAmount = blob.MealAmount;
        GameManager.FishAmount = blob.FishAmount;
        GameManager.FruitAmount = blob.FruitAmount;
        GameManager.BerryAmount = blob.BerryAmount;
        GameManager.MushroomAmount = blob.MushroomAmount;
        GameManager.WaterAmount = blob.WaterAmount;
        GameManager.SelectedLanguage = blob.SelectedLanguage;
        GameManager.EffectVolume = blob.EffectVolume;
        GameManager.MusicVolume = blob.MusicVolume;
        GameManager.EffectMuted = blob.EffectMuted;
        GameManager.MusicMuted = blob.MusicMuted;
    }
}


[XmlRoot("SaveBlob")]
public class SaveBlob
{
    [XmlArray("Party")]
    [XmlArrayItem(typeof(Actor))]
    public List<Actor> Party;
    [XmlElement(typeof(int))]
    public int Days;
    [XmlElement(typeof(int))]
    public int HutCompletion;
    [XmlElement(typeof(int))]
    public int BoatCompletion;
    [XmlElement(typeof(int))]
    public int WoodAmount;
    [XmlElement(typeof(int))]
    public int MealAmount;
    [XmlElement(typeof(int))]
    public int FishAmount;
    [XmlElement(typeof(int))]
    public int MushroomAmount;
    [XmlElement(typeof(int))]
    public int BerryAmount;
    [XmlElement(typeof(int))]
    public int WaterAmount;
    [XmlElement(typeof(int))]
    public int FruitAmount;
    [XmlElement(typeof(Language))]
    public Language SelectedLanguage;
    [XmlElement(typeof(float))]
    public float EffectVolume;
    [XmlElement(typeof(float))]
    public float MusicVolume;
    [XmlElement(typeof(bool))]
    public bool EffectMuted;
    [XmlElement(typeof(bool))]
    public bool MusicMuted;
}
