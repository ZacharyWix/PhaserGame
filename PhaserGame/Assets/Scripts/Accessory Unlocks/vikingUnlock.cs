using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vikingUnlock : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_10);
            this.gameObject.SetActive(false);
        }
    }
}
