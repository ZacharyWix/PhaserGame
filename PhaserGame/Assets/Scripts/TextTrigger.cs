using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextMeshProUGUI colors;
    public TextMeshProUGUI welcome;
    public TextMeshProUGUI jump;
    public TextMeshProUGUI spike;
    public TextMeshProUGUI spikeBack;
    public TextMeshProUGUI checkpoint;
    public TextMeshProUGUI platforms;
    public TextMeshProUGUI spikeShooters;
    public TextMeshProUGUI end;
    public TextMeshProUGUI colorful;
    private bool checkp = false;
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.transform.CompareTag("Text Trigger"))
    //    {
    //        colors.enabled = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Text Trigger"))
        {
            print(collision.gameObject.name);
            if (collision.gameObject.name == "Colors")
            {
                colors.enabled = false;
            }
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
        }
        if (collision.transform.CompareTag("Finish"))
        {
            end.enabled = false;
            colorful.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Death"))
        {
            print("died");
            Start();
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
    }
}
