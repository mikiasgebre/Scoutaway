using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadValuesToOptions : MonoBehaviour 
{
    public Slider SoundSlider;
    public Slider MusicSlider;
    public Toggle SoundToggle;
    public Toggle MusicToggle;
    public Toggle English;
    public Toggle Finnish;
    public Toggle Swedish;

	// Use this for initialization
	void Start () 
    {
        SaveData.Load();
        SoundSlider.value = GameManager.EffectVolume;
        MusicSlider.value = GameManager.MusicVolume;
        SoundToggle.isOn = !GameManager.EffectMuted;
        MusicToggle.isOn = !GameManager.MusicMuted;
        if (GameManager.SelectedLanguage == Language.English)
        {
            English.isOn = true;
            Finnish.isOn = false;
            Swedish.isOn = false;
        }
        else if (GameManager.SelectedLanguage == Language.Finnish)
        {
            English.isOn = false;
            Finnish.isOn = true;
            Swedish.isOn = false;
        }
        else
        {
            English.isOn = false;
            Finnish.isOn = false;
            Swedish.isOn = true;
        }
	}
}
