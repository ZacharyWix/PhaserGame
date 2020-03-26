using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static AudioClip jumpSound;
    public static AudioClip deathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/jump_11.wav", typeof(AudioClip));
        deathSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/crumble.wav", typeof(AudioClip));

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "jump":
                audioSrc.PlayOneShot(jumpSound, 0.5f);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound, 0.5f);
                break;
        }
    }
}
