using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject nl, rl, e, ld, td, t;
    public OptionsMenu options;
    public GameObject endgame;
    public MainMenu menu;
    public Transform respawnPoint;
    public deathCounter deathCount;
    public SoundPlayer soundPlay;
    private Rigidbody2D rb;
    private phaserManager gm;
    private SpriteRenderer sr;
    private level lv;
    public Canvas canvas;
    public EventSystem eventSys;
    public GameObject nextLevel;
    private pause pauseScript;
    private string name = "none";
    public GameObject tutorial;
    public GameObject next;
    public Unlocker unlocker;
    private bool platformStatus; //True if player is on a moving platform
    public GameObject world;
    public GameObject accessory;
    public GameObject replay, stats, speedRun, stats2, speedRun2;

    public float respawnDelay; //in seconds
    private float respawnTimer;

    private move2D moveScript; //used to enable and disable controls
    private bool isDead = false;

    public ParticleSystem deathParticles;

    private Vector3 lastPracticeCheckpointPosition;
    private bool firstPracticeCheckpoint = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        moveScript = GetComponent<move2D>();
        respawnTimer = respawnDelay;
        deathParticles = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        pauseScript = GetComponent<pause>();
        if (SpeedRunMode.getSpeedRun())
        {
            stats2.SetActive(false);
            speedRun2.SetActive(true);
        }
    }

    private void Update()
    {
        if(isDead)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer <= 0f)
            {
                moveScript.setControls(true);
                rb.simulated = true;
                isDead = false;
                respawnTimer = respawnDelay;
                accessory.gameObject.SetActive(true);
                spawn();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!isDead)
        {
            if (col.transform.CompareTag("Death"))
            {
                print("one");
                killPlayer();
            }

            if (col.transform.CompareTag("SpikePlayerKillers"))
            {
                if (!platformStatus) //Only kill the player if they aren't on a moving platform
                {
                    print("two");
                    killPlayer();
                }
            }
        }
    }

    private void killPlayer()
    {
        //Plays the death sound
        soundPlay.PlaySound("death");
        accessory.gameObject.SetActive(false);

        //Plays death particles and makes the player disappear
        deathParticles.Play();
        sr.enabled = false;

        //disables controls and disables physics for the player
        moveScript.setControls(false);
        rb.simulated = false;
        isDead = true;
        respawnTimer = respawnDelay;

        //increases the death counter and updates the text
        gm.incDeathCount();
        deathCount.updateDeathCounter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            pauseScript.togglePause();
            soundPlay.PlaySound("win");
            if (SpeedRunMode.getSpeedRun())
            {
                SpeedRunMode.incLevel(1);
                SpeedRunMode.setDeaths(gm.getDeathCount());
                float time = deathCount.getTime();
                time = (float)Math.Round(time * 100f) / 100f;
                SpeedRunMode.setTime(time);
                deathCount.updateDeathCounter();
                menu.SaveGame();
                replay.SetActive(false);
                stats.SetActive(false);
                speedRun.SetActive(true);
                unlocker.updateUnlocks();
            }
            if (SceneManager.GetActiveScene().buildIndex == 1 && options.getIsOn() && !SpeedRunMode.getSpeedRun())
            {
                endgame.gameObject.SetActive(true);
                ld.SetActive(false);
                nl.SetActive(false);
                rl.SetActive(false);
                e.SetActive(false);
                td.SetActive(false);
                t.SetActive(false);
                tutorial.gameObject.SetActive(true);
                eventSys.SetSelectedGameObject(next);
            }
            else if ((SceneManager.GetActiveScene().buildIndex == 10 && level.getLevelDeaths(10) == -1) || (SceneManager.GetActiveScene().buildIndex == 20 && level.getLevelDeaths(20) == -1) || (SceneManager.GetActiveScene().buildIndex == 30 && level.getLevelDeaths(30) == -1))
            {
                world.gameObject.SetActive(true);
                endgame.gameObject.SetActive(true);
                eventSys.SetSelectedGameObject(next);
            }
            else
            {
                endgame.gameObject.SetActive(true);
                eventSys.SetSelectedGameObject(nextLevel);
            }
            if (!MainMenu.getPractice() && !SpeedRunMode.getSpeedRun())
            {
                level.removeActiveLevel(SceneManager.GetActiveScene().buildIndex);
                CreateLevel(false);
                unlocker.updateUnlocks();
                deathCount.updateDeathCounter();
                menu.SaveGame();
            }
            else if (!MainMenu.getPractice())
            {
                unlocker.updateUnlocks();
            }
        }
    
        if (collision.transform.CompareTag("Checkpoint") && !PracticeMode.isPracticeMode())
        {
            if(name != collision.gameObject.name)
              {
                 soundPlay.PlaySound("checkpoint");
              }
            respawnPoint = collision.transform;
            name = collision.gameObject.name;
        }

        if (collision.transform.CompareTag("PracticeCheckpoint"))
        {
            if(firstPracticeCheckpoint) //So the checkpoint sound doesn't happen when you start a level
            {
                lastPracticeCheckpointPosition = collision.transform.position;
                firstPracticeCheckpoint = false;
            }

            if (lastPracticeCheckpointPosition != collision.transform.position) //If you moved the checkpoint before colliding with it
            {
                soundPlay.PlaySound("checkpoint");
            }
            respawnPoint = collision.transform;
            name = collision.gameObject.name;

            lastPracticeCheckpointPosition = collision.transform.position;
        }
    }

    void OnApplicationQuit()
    {
        if (!MainMenu.getPractice())
        {
            if (SpeedRunMode.getSpeedRun())
            {
                deathCount.saveStats();
            }
            else
            {

                if (endgame.gameObject.activeSelf)
                {
                    CreateLevel(false);
                }
                else
                {
                    CreateLevel(true);
                }
            }
        }
        menu.SaveGame();
    }

    //respawns the player at their current respawnPoint
    private void spawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = new Vector2(0, 0);
        sr.enabled = true;
    }

    public void CreateLevel(bool active)
    {
        if (!MainMenu.getPractice())
        {
            float time = deathCount.getTime();
            time = (float)Math.Round(time * 100f) / 100f;
            lv = new level(SceneManager.GetActiveScene().buildIndex, gm.getDeathCount(), active, time);
        }
    }
    public void resetDeaths()
    {
        gm.resetDeathCount();
    }

    public void setPlatformStatus(bool status)
    {
        platformStatus = status;
    }
}
