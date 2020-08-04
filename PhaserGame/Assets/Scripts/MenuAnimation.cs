using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{

    public GameObject blocks;
    public GameObject clouds;
    public GameObject c1;
    public GameObject c2;
    private float bpos = 0.0f;
    private float cpos = 0.0f;
    private float bspeed = 0.1f;
    private float cspeed = 0.15f;
    private float init = 0;
    // Start is called before the first frame update
    void Start()
    {
        init = c1.transform.position.x;
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
        if (c2.transform.position.x > init)
        {
            cpos = 0;
        }
        bpos += bspeed * Time.deltaTime;
        cpos += cspeed * Time.deltaTime;
        blocks.transform.position = new Vector2(0, bpos);
        clouds.transform.position = new Vector2(cpos, 0);
    }
}
