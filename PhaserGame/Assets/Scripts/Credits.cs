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
    private float x = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = credits.transform.position.y + 1.5f;
        credits.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (screen.gameObject.activeSelf)
        {
            if (placeholder.transform.position.y < x)
            {
                scroll += speed * Time.deltaTime;
                credits.transform.position = new Vector2(0, scroll);
            }
        }
    }

    public void resetScroll()
    {
        scroll = 0;
        credits.transform.position = new Vector2(0, scroll);
    }
}
