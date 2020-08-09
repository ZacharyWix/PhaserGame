using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassesUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_7);
            this.gameObject.SetActive(false);
        }
    }
}
