using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip winSound;
    public AudioClip checkpointSound;
    public AudioClip jumpLandSound;
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
                audioSrc.PlayOneShot(jumpSound, 0.3f);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound, 0.5f);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound, 0.5f);
                break;
            case "checkpoint":
                audioSrc.PlayOneShot(checkpointSound, 0.5f);
                break;
            //case "land":
                //audioSrc.PlayOneShot(jumpLandSound, 0.5f);
                //break;
        }
    }
}
