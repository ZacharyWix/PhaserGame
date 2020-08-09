using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tophatUnlocker : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject accessory_3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlockAccessory(accessory_3);
            this.gameObject.SetActive(false);
        }
    }
}
