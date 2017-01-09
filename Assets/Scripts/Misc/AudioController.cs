using System.Collections.Generic;
using UnityEngine;

public enum AudioSourceType
{ 
    music,
    effect
}

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour 
{
    public AudioSourceType ControllerType = AudioSourceType.effect;
    
    public static List<AudioController> AudioControlList 
    {
        get;
        set;
    }

    public AudioSource AudioSourceComponent 
    {
        get; 
        set; 
    }

    public static void UpdateVolumes()
    {
        foreach (AudioController ac in AudioController.AudioControlList)
        {
            ac.SetVolume();
        }
    }

    public void SetVolume()
    {
        if (ControllerType == AudioSourceType.effect)
        {
            AudioSourceComponent.volume = GameManager.EffectVolume;
            AudioSourceComponent.mute = GameManager.EffectMuted;
        }
        else
        {
            AudioSourceComponent.volume = GameManager.MusicVolume;
            AudioSourceComponent.mute = GameManager.MusicMuted;
        }
    }

    private void Awake()
    {
        AudioSourceComponent = GetComponent<AudioSource>();
        if (AudioControlList == null)
        {
            AudioControlList = new List<AudioController>();
        }

        AudioControlList.Add(this);
    }

    private void Start()
    {
        SetVolume();
    }
}
