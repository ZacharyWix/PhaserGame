using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextMeshProUGUI welcome;
    public TextMeshProUGUI jump;
    public TextMeshProUGUI spike;
    public TextMeshProUGUI spikeBack;
    public TextMeshProUGUI checkpoint;
    public TextMeshProUGUI platforms;
    public TextMeshProUGUI spikeShooters;
    public TextMeshProUGUI end;
    public TextMeshProUGUI colorful;
    public TextMeshProUGUI colors;
    public TextMeshProUGUI red;
    public TextMeshProUGUI blue;
    public TextMeshProUGUI green;
    public TextMeshProUGUI yellow;
    public TextMeshProUGUI colorSpike;
    public TextMeshProUGUI colorSpike2;
    private bool checkp = false;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            setupOne();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            setupTwo();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            setupThree();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setupOne()
    {
        jump.enabled = false;
        spike.enabled = false;
        spikeBack.enabled = false;
        checkpoint.enabled = false;
        platforms.enabled = false;
        spikeShooters.enabled = false;
        end.enabled = false;
        colorful.enabled = false;
    }
    private void setupTwo()
    {
        print("setup2");
        colors.enabled = true;
        red.enabled = false;
        blue.enabled = false;
        green.enabled = false;
        yellow.enabled = false;
    }

    private void setupThree()
    {
        colorSpike.enabled = true;
        colorSpike2.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Text Trigger"))
        {
            if (collision.gameObject.name == "Welcome")
            {
                welcome.enabled = false;
                jump.enabled = true;
                checkp = false;
            }
            if (collision.gameObject.name == "Spike")
            {
                jump.enabled = false;
                spike.enabled = true;
            }
            if (collision.gameObject.name == "SpikeBack")
            {
                spike.enabled = false;
                spikeBack.enabled = true;
            }
            if (collision.gameObject.name == "Checkpoint")
            {
                spikeBack.enabled = false;
                checkpoint.enabled = true;
                checkp = true;
            }
            if (collision.gameObject.name == "Moving Platform")
            {
                checkpoint.enabled = false;
                platforms.enabled = true;
            }
            if (collision.gameObject.name == "Spike Shooters")
            {
                platforms.enabled = false;
                spikeShooters.enabled = true;
            }
            if (collision.gameObject.name == "End")
            {
                spikeShooters.enabled = false;
                end.enabled = true;
                colorful.enabled = true;
            }
            if (collision.gameObject.name == "Colors")
            {
                colors.enabled = false;
                red.enabled = true;

            }
            if (collision.gameObject.name == "Red")
            {
                red.enabled = false;
                blue.enabled = true;
            }
            if (collision.gameObject.name == "Blue")
            {
                blue.enabled = false;
                green.enabled = true;
            }
            if (collision.gameObject.name == "Green")
            {
                green.enabled = false;
                yellow.enabled = true;
            }
            if (collision.gameObject.name == "Yellow")
            {
                yellow.enabled = false;
            }
            if (collision.gameObject.name == "ColorSpikes")
            {
                colorSpike.enabled = false;
                colorSpike2.enabled = true;
            }
            if (collision.gameObject.name == "Off")
            {
                colorSpike2.enabled = false;
            }
        }
        if (collision.transform.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                end.enabled = false;
                colorful.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Death"))
        {

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                setupOne();
                if (checkp)
                {
                    welcome.enabled = false;
                    checkpoint.enabled = true;
                }
                else
                {
                    welcome.enabled = true;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                setupTwo();
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                setupThree();
            }
        }
    }
}
