using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{

    public GameObject blocks;
    public GameObject clouds;
    private float bpos = 0.0f;
    private float cpos = 0.0f;
    public float bspeed;
    public float cspeed;
    // Start is called before the first frame update
    void Start()
    {
        blocks.transform.position = new Vector2(0, 0);
        clouds.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (bspeed > 0 && bpos > 0.5)
        {
            bspeed = bspeed * -1;
        }
        if (bspeed < 0 && bpos < -0.5)
        {
            bspeed = bspeed * -1;
        }
        if (cpos > 19.85)
        {
            cpos = 0;
            print("loop");
        }
        bpos += bspeed * Time.deltaTime;
        cpos += cspeed * Time.deltaTime;
        blocks.transform.position = new Vector2(0, bpos);
        clouds.transform.position = new Vector2(cpos, 0);
    }
}
