using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject achievement_13, accessory_2;
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.enabled = false;
            print("Gun Collision");
        }
    } */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            unlocks.unlock(achievement_13);
            unlocks.unlockAccessory(accessory_2);
            this.gameObject.SetActive(false);
        }
    }
}
