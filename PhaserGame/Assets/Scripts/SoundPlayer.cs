using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip deathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound (string clip)
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
