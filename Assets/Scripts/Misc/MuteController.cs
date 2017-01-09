using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteController : MonoBehaviour 
{
    public SliderController.AudioType MuteType;
    public Image child;
    public Sprite Muted;
    public Sprite Unmuted;

    public void ToggleMute(bool b)
    {
        if (MuteType == SliderController.AudioType.Effect)
        {
            GameManager.EffectMuted = !b;
        }
        else
        {
            GameManager.MusicMuted = !b;
        }

        if (b)
        {
            child.sprite = Unmuted;
        }
        else
        {
            child.sprite = Muted;
        }
    }
}
