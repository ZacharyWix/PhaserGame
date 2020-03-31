using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer soundEffectsMixer;
    public AudioMixer musicMixer;

    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectsMixer.SetFloat("SoundEffects", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
}
