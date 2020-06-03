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

    public float respawnDelay; //in seconds
    private float respawnTimer;

    private move2D moveScript; //used to enable and disable controls
    private bool isDead = false;

    public ParticleSystem deathParticles;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        moveScript = GetComponent<move2D>();
        respawnTimer = respawnDelay;
        deathParticles = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        pauseScript = GetComponent<pause>();
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
                spawn();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Death"))
        {
            killPlayer();
        }

        if (col.transform.CompareTag("SpikePlayerKillers"))
        {
            if(!platformStatus) //Only kill the player if they aren't on a moving platform
            {
                killPlayer();
            }
        }
    }

    private void killPlayer()
    {
        //Plays the death sound
        soundPlay.PlaySound("death");

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
            level.removeActiveLevel(SceneManager.GetActiveScene().buildIndex);
            CreateLevel(false);
            unlocker.updateUnlocks();
            deathCount.updateDeathCounter();
            menu.SaveGame();
            if (SceneManager.GetActiveScene().buildIndex == 1 && options.getIsOn())
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
            else
            {
                endgame.gameObject.SetActive(true);
                eventSys.SetSelectedGameObject(nextLevel);
            }
        }
    
        if (collision.transform.CompareTag("Checkpoint"))
        {
            if(name != collision.gameObject.name)
              {
                 soundPlay.PlaySound("checkpoint");
              }
            respawnPoint = collision.transform;
            name = collision.gameObject.name;
        }
    }

    void OnApplicationQuit()
    {
        if (endgame.gameObject.activeSelf)
        {
            CreateLevel(false);
        }
        else
        {
            CreateLevel(true);
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
        float time = deathCount.getTime();
        time = (float)Math.Round(time * 100f) / 100f;
        lv = new level(SceneManager.GetActiveScene().buildIndex, gm.getDeathCount(), active, time);
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
