using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public void SetSoundEffectsVolume(float volume)
    {
        GameObject.Find("Game Manager").GetComponent<musicManager>().setSoundEffectsValue(volume, volume);
    }

    public void SetMusicVolume(float volume)
    {
        GameObject.Find("Game Manager").GetComponent<musicManager>().setMusicValue(volume, volume);
    }
}
