using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_6);
            this.gameObject.SetActive(false);
        }
    }
}
