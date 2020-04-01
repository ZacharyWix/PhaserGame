using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextMeshProUGUI colors;
    // Start is called before the first frame update
    void Start()
    {
        colors.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.transform.CompareTag("Text Trigger"))
    //    {
    //        colors.enabled = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Text Trigger"))
        {
            print(collision.gameObject.name);
            colors.enabled = true;
        }
    }
}
