using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_9;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_9);
            this.gameObject.SetActive(false);
        }
    }
}
