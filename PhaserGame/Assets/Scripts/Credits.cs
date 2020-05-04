using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject screen;
    public GameObject credits;
    private float scroll = 0;
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        credits.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (screen.gameObject.activeSelf)
        {
            if (scroll <8)
            {
                scroll += speed;
                credits.transform.position = new Vector2(0, scroll);
            }
        }
    }

    public void resetScroll()
    {
        scroll = 0;
    }
}
