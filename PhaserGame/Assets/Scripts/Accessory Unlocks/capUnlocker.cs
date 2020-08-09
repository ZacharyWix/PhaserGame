using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_4);
            this.gameObject.SetActive(false);
        }
    }
}
