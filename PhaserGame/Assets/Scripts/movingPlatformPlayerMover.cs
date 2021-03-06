﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformPlayerMover : MonoBehaviour
{
    // Start is called before the first frame update
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(GameObject.Find("Player").transform);
        }
    } */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Respawn>().setPlatformStatus(true);
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Respawn>().setPlatformStatus(false);
            collision.transform.SetParent(GameObject.Find("Player").transform);
        }
    }

    
}
