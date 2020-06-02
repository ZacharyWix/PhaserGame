using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public Unlocker unlocks;
    public GameObject mysteryAchievement;
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
            print("Gun Collision");
            unlocks.unlock(mysteryAchievement);
            this.gameObject.SetActive(false);
        }
    }
}
