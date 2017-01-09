using UnityEngine;
using System.Collections;

public static class ResourceManager
{
    public static AudioClip ButtonSound;
    private static bool initialized = false;

    public static void Initialize()
    {
        if (!initialized)
        {
            ButtonSound = Resources.Load<AudioClip>("Audio/ButtonSound");
            initialized = true;
        }
    }

    public static AudioClip GetRandomMainGameBackgroundSound()
    {
        return null;
    }
}
