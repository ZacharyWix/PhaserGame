using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuAnimation : MonoBehaviour
{

    public GameObject blocks;
    public GameObject clouds;
    public GameObject c1;
    public GameObject c2;
    public GameObject character, character2;
    private float bpos = 0.0f;
    private float cpos = 0.0f;
    private float bspeed = 0.1f;
    private float cspeed = 0.15f;
    private float charSpeed = 0.1f;
    private float charPos = 0;
    private float init = 0;
    private float x = 0;
    private float flip = 0;
    private EventSystem ev;
    public GameObject play, quit;
    private float p = 0;
    private float q = 0;
    // Start is called before the first frame update
    void Start()
    {
        init = c1.transform.position.x;
        x = character.transform.position.x;
        blocks.transform.position = new Vector2(0, 0);
        clouds.transform.position = new Vector2(0, 0);
        ev = EventSystem.current;
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
        if (charSpeed > 0 && charPos > 0.1)
        {
            charSpeed = charSpeed * -1;
        }
        if (charSpeed < 0 && charPos < -0.1)
        {
            character.transform.localRotation = Quaternion.Euler(0, flip, 0);
            character2.transform.localRotation = Quaternion.Euler(0, flip, 0);
            charSpeed = charSpeed * -1;
            if(flip == 180)
            {
                flip = 0;
            }
            else
            {
                flip = 180;
            }
        }
        if (c2.transform.position.x > init)
        {
            cpos = 0;
        }
        bpos += bspeed * Time.deltaTime;
        cpos += cspeed * Time.deltaTime;
        charPos += charSpeed * Time.deltaTime;
        blocks.transform.position = new Vector2(0, bpos);
        character.transform.position = new Vector2(x, charPos);
        character2.transform.position = new Vector2(0, charPos);
        clouds.transform.position = new Vector2(cpos, 0);
        if(EventSystem.current.currentSelectedGameObject == play)
        {
            p += Time.deltaTime;
        }
        else
        {
            p = 0;
        }
        if (EventSystem.current.currentSelectedGameObject == quit)
        {
            q += Time.deltaTime;
        }
        else
        {
            q = 0;
        }
        if (p > 0.2 && Input.GetAxis("Vertical") > 0)
        {
            ev.SetSelectedGameObject(quit);
        }
        if (q > 0.2 && Input.GetAxis("Vertical") < 0)
        {
            ev.SetSelectedGameObject(play);
        }
    }
}
