﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowboyHatUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_5);
            this.gameObject.SetActive(false);
        }
    }
}
