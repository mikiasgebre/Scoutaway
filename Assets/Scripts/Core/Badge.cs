using UnityEngine;
using System.Collections;
using System.Xml.Serialization;


public class Badge // this was abstract
{
    public string Name; //{ get; } so were these
    public string Description; //{ get; }
    public bool Unlocked;
    public string SpritePath;

    public Badge(string name, string description, bool unlocked, string spritePath)
    {
        Name = name;
        Description = description;
        Unlocked = unlocked;
        SpritePath = spritePath;
    }

    public Badge()
    { 
    }

    public virtual void Effect()
    {
    }

    public virtual void CheckUnlock()
    {
    }
}
