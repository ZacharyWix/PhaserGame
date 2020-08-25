using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarfUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_11;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_11);
            this.gameObject.SetActive(false);
        }
    }
}
