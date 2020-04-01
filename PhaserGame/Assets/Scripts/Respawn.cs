using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject endgame;
    public Transform respawnPoint;
    public deathCounter deathCount;
    public SoundPlayer soundPlay;
    private Rigidbody2D rb;
    private phaserManager gm;
    private SpriteRenderer sr;
    private level lv;
    public Canvas canvas;
    private pause pauseScript;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            pauseScript.togglePause();
            level.removeActiveLevel(SceneManager.GetActiveScene().buildIndex);
            CreateLevel(false);
            deathCount.updateDeathCounter();
            endgame.gameObject.SetActive(true);
        }
    
        if (collision.transform.CompareTag("Checkpoint"))
        {
            respawnPoint = collision.transform;
        }
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
        lv = new level(SceneManager.GetActiveScene().buildIndex, gm.getDeathCount(), active);
    }
    public void resetDeaths()
    {
        gm.resetDeathCount();
    }
}
