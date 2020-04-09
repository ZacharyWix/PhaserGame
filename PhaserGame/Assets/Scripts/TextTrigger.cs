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
    public OptionsMenu options;
    public pause pause;
    private bool tutorials;
    private bool isPaused;
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
        if (tutorials != options.getIsOn())
        {
            tutorials = options.getIsOn();
            Start();
        }
        isPaused = pause.getPause();
        if (isPaused)
        {
            Start();
        }
    }

    private void setupOne()
    {
        welcome.enabled = false;
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
        colors.enabled = false;
        red.enabled = false;
        blue.enabled = false;
        green.enabled = false;
        yellow.enabled = false;
    }

    private void setupThree()
    {
        colorSpike.enabled = false;
        colorSpike2.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Text Trigger") && tutorials && !isPaused)
        {
            if (collision.gameObject.name == "Welcome")
            {
                welcome.enabled = true;
            }
            if (collision.gameObject.name == "Jump")
            {
                jump.enabled = true; ;
            }
            if (collision.gameObject.name == "Spike")
            {
                spike.enabled = true;
            }
            if (collision.gameObject.name == "SpikeBack")
            {
                spikeBack.enabled = true;
            }
            if (collision.gameObject.name == "Checkpoint")
            {
                checkpoint.enabled = true;
            }
            if (collision.gameObject.name == "Moving Platform")
            {
                platforms.enabled = true;
            }
            if (collision.gameObject.name == "Spike Shooters")
            {
                spikeShooters.enabled = true;
            }
            if (collision.gameObject.name == "End")
            {
                end.enabled = true;
                colorful.enabled = true;
            }
            if (collision.gameObject.name == "Colors")
            {
                colors.enabled = true;
            }
            if (collision.gameObject.name == "Red")
            {
                red.enabled = true;
            }
            if (collision.gameObject.name == "Blue")
            {
                blue.enabled = true;
            }
            if (collision.gameObject.name == "Green")
            {
                green.enabled = true;
            }
            if (collision.gameObject.name == "Yellow")
            {
                yellow.enabled = true;
            }
            if (collision.gameObject.name == "ColorSpikes")
            {
                colorSpike.enabled = true;
            }
            if (collision.gameObject.name == "Off")
            {
                colorSpike2.enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                end.enabled = false;
                colorful.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Text Trigger") && tutorials)
        {
            if (collision.gameObject.name == "Welcome")
            {
                welcome.enabled = false;
            }
            if (collision.gameObject.name == "Jump")
            {
                jump.enabled = false;
            }
            if (collision.gameObject.name == "Spike")
            {
                spike.enabled = false;
            }
            if (collision.gameObject.name == "SpikeBack")
            {
                spikeBack.enabled = false;
            }
            if (collision.gameObject.name == "Checkpoint")
            {
                checkpoint.enabled = false;
            }
            if (collision.gameObject.name == "Moving Platform")
            {
                platforms.enabled = false;
            }
            if (collision.gameObject.name == "Spike Shooters")
            {
                spikeShooters.enabled = false;
            }
            if (collision.gameObject.name == "End")
            {
                end.enabled = false;
                colorful.enabled = false;
            }
            if (collision.gameObject.name == "Colors")
            {
                colors.enabled = false;
            }
            if (collision.gameObject.name == "Red")
            {
                red.enabled = false;
            }
            if (collision.gameObject.name == "Blue")
            {
                blue.enabled = false;
            }
            if (collision.gameObject.name == "Green")
            {
                green.enabled = false;
            }
            if (collision.gameObject.name == "Yellow")
            {
                yellow.enabled = false;
            }
            if (collision.gameObject.name == "ColorSpikes")
            {
                colorSpike.enabled = false;
            }
            if (collision.gameObject.name == "Off")
            {
                colorSpike2.enabled = false;
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
