using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject screen;
    public GameObject credits;
    public GameObject placeholder;
    private float scroll = 0;
    private float speed = 0.4f;
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
            if (scroll < 16)
            {
                scroll += speed * Time.deltaTime;
                credits.transform.position = new Vector2(0, scroll);
            }
        }
        if (!credits.activeSelf)
        {
            print("inactive");
        }
    }

    public void resetScroll()
    {
        scroll = 0;
    }
}
