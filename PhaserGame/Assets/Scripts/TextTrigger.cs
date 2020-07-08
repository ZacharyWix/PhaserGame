using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class TextTrigger : MonoBehaviour
{
    public GameObject welcome;
    public GameObject jump;
    public TextMeshProUGUI spike;
    public TextMeshProUGUI spikeBack;
    public TextMeshProUGUI checkpoint;
    public TextMeshProUGUI platforms;
    public TextMeshProUGUI spikeShooters;
    public TextMeshProUGUI end;
    public TextMeshProUGUI colorful;
    public TextMeshProUGUI colors;
    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject yellow;
    public TextMeshProUGUI colorSpike;
    public GameObject colorSpike2;
    public TextMeshProUGUI pTutorial;
    public pause pause;
    private bool tutorials;
    private bool isPaused;
    public OptionsMenu options;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetJoystickNames().Length != 0)
            {
                //welcome.text = "Welcome to Phaser!  Use the A and D keys (left joystick) to move left and right.";
                //jump.text = "Use the space bar (LB) to jump." + Environment.NewLine + "Hold the space bar (LB) to jump longer.";
                //pTutorial.text = "Turn the tutorial tips on and off at any point.Press ESC (Start) during a level to pause and access the options menu";
                //jump.enabled = false;
            }
            setupOne();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.GetJoystickNames().Length != 0)
            {
                //red.text = "Use the right arrow key (B) to turn on the red blocks.";
                //blue.text = "Use the left arrow key (X) to turn on the blue blocks.";
                //green.text = "Use the down arrow key (A) to turn on the green blocks.";
                //yellow.text = "Use the up arrow key (Y) to turn on the yellow blocks.";
            }
            
            setupTwo();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetJoystickNames().Length != 0)
            {
                //colorSpike2.text = "Use the left arrow key (X) to turn off the blue spikes.";
                //colorSpike2.enabled = false;
            }
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
        welcome.SetActive(false);
        jump.SetActive(false);
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
        red.SetActive(false);
        blue.SetActive(false);
        green.SetActive(false);
        yellow.SetActive(false);
    }

    private void setupThree()
    {
        colorSpike.enabled = false;
        colorSpike2.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Text Trigger") && tutorials && !isPaused)
        {
            if (collision.gameObject.name == "Welcome")
            {
                welcome.SetActive(true);
            }
            if (collision.gameObject.name == "Jump")
            {
                jump.SetActive(true);
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
                red.SetActive(true);
            }
            if (collision.gameObject.name == "Blue")
            {
                blue.SetActive(true);
            }
            if (collision.gameObject.name == "Green")
            {
                green.SetActive(true);
            }
            if (collision.gameObject.name == "Yellow")
            {
                yellow.SetActive(true);
            }
            if (collision.gameObject.name == "ColorSpikes")
            {
                colorSpike.enabled = true;
            }
            if (collision.gameObject.name == "Off")
            {
                colorSpike2.SetActive(true);
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
                welcome.SetActive(false);
            }
            if (collision.gameObject.name == "Jump")
            {
                jump.SetActive(false);
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
                red.SetActive(false);
            }
            if (collision.gameObject.name == "Blue")
            {
                blue.SetActive(false);
            }
            if (collision.gameObject.name == "Green")
            {
                green.SetActive(false);
            }
            if (collision.gameObject.name == "Yellow")
            {
                yellow.SetActive(false);
            }
            if (collision.gameObject.name == "ColorSpikes")
            {
                colorSpike.enabled = false;
            }
            if (collision.gameObject.name == "Off")
            {
                colorSpike2.SetActive(false);
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
