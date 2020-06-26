﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public int menuSceneNumber;
    public int blandLandSceneNumber; //The scene number of the first level of Bland Land
    public int vibrantValleySceneNumber; //The scene number of the first level of Vibrant Valley
    public AudioSource musicPlayer;
    private int currScene;
    private int prevScene;
    public AudioClip mainMenuMusic;
    public AudioClip blandLandMusic;
    public AudioClip vibrantValleyMusic;

    private void Awake()
    {
        currScene = SceneManager.GetActiveScene().buildIndex;
        chooseSong();
    }

    private void chooseSong()
    {
        print("Current Scene number:" + currScene);
        print("Previous Scene number:" + prevScene);
        if (currScene >= vibrantValleySceneNumber && prevScene < vibrantValleySceneNumber)
        {
            transitionMusic(vibrantValleyMusic);
            musicPlayer.volume = 1f;
        }
        else if (currScene >= blandLandSceneNumber && !(prevScene >= blandLandSceneNumber))
        {
            transitionMusic(blandLandMusic);
            musicPlayer.volume = .35f;
        }
        else if (currScene == menuSceneNumber)
        {
            transitionMusic(mainMenuMusic);
            musicPlayer.volume = .35f;
        }
    }

    private void Update()
    {
        if(currScene != SceneManager.GetActiveScene().buildIndex)
        {
            prevScene = currScene;
            currScene = SceneManager.GetActiveScene().buildIndex;
            chooseSong();
        }
    }

    private void transitionMusic(AudioClip song)
    {
        musicPlayer.clip = song;
        musicPlayer.Play();
    }
}
