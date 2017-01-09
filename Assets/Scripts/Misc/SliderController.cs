using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour 
{
    public enum AudioType
    {
        Effect, 
        Music
    }

    public AudioType type;
    public void SetVolume(float Volume)
    {
        if (type == AudioType.Effect)
        {
            GameManager.EffectVolume = Volume;
        }
        else
        {
            GameManager.MusicVolume = Volume;
        }
    }
}
