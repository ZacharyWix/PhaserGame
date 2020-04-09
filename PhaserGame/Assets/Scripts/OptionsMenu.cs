using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Button on;
    public Button off;
    private static bool isOn = true;

    public void Start()
    {
        SetColor(isOn);
    }
    public void SetSoundEffectsVolume(float volume)
    {
        GameObject.Find("Game Manager").GetComponent<musicManager>().setSoundEffectsValue(volume, volume);
    }

    public void SetMusicVolume(float volume)
    {
        GameObject.Find("Game Manager").GetComponent<musicManager>().setMusicValue(volume, volume);
    }
    public void SetColor(bool isOn)
    {
        ColorBlock onColors = on.colors;
        ColorBlock offColors = off.colors;
        if (isOn) {
            onColors.normalColor = new Color32(8, 25, 79, 75);
            offColors.normalColor = new Color32(8, 25, 79, 0);
        }
        else
        {
            onColors.normalColor = new Color32(8, 25, 79, 0);
            offColors.normalColor = new Color32(8, 25, 79, 75);
        }
        
        on.colors = onColors;
        off.colors = offColors;
    }

    public void Toggle(bool active)
    {
        isOn = active;
    }
    public bool getIsOn()
    {
        return isOn;
    }
}
