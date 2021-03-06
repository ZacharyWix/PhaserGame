﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public MainMenu menu;
    public Button on;
    public Button off;
    private static bool isOn = true;
    private level lv;

    public void Start()
    {
        SetColor(isOn);
    }
    public void SetSoundEffectsVolume(float volume)
    {
        GameObject.Find("Game Manager").GetComponent<musicManager>().setSoundEffectsValue(volume, volume);
        menu.SaveGame();
    }

    public void SetMusicVolume(float volume)
    {
        GameObject.Find("Game Manager").GetComponent<musicManager>().setMusicValue(volume, volume);
        menu.SaveGame();

    }
    public void SetColor(bool isOn)
    {
        ColorBlock onColors = on.colors;
        ColorBlock offColors = off.colors;
        if (isOn)
        {
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
        menu.SaveGame();
    }
    public bool getIsOn()
    {
        return isOn;
    }
    public float getSFXVolume()
    {
        return GameObject.Find("Game Manager").GetComponent<musicManager>().getSoundEffectsValue();
    }

    public float getMusicVolume()
    {
        return GameObject.Find("Game Manager").GetComponent<musicManager>().getMusicValue();
    }
    public static void setIsOn(bool on)
    {
        isOn = on;
    }
}
