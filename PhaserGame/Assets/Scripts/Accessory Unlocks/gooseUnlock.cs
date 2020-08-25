using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gooseUnlock : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_8);
            this.gameObject.SetActive(false);
        }
    }
}
