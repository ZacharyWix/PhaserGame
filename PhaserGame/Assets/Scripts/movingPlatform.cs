using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    private Vector3 startPoint;
    public Transform endPoint;
    public float speed;
    private float lengthx;
    private float lengthy;
    // Start is called before the first frame update
    void Start()
    {
        startPoint.x = gameObject.transform.position.x;
        startPoint.y = gameObject.transform.position.y;
        startPoint.z = gameObject.transform.position.z;
        lengthx = endPoint.position.x - startPoint.x;
        lengthy = endPoint.position.y - startPoint.y;
    }

    // Update is called once per frame
    void Update()
    {
        float xOffset = 0f;
        float yOffset = 0f;
        if(lengthx != 0f && lengthy != 0f)
        {
            if (lengthx > lengthy)
            {
                float corrector = lengthy / lengthx;
                xOffset = Mathf.PingPong(Time.time * speed, lengthx);
                yOffset = Mathf.PingPong(Time.time * speed * corrector, lengthy);
            }
            else if (lengthy > lengthx)
            {
                float corrector = lengthx / lengthy;
                xOffset = Mathf.PingPong(Time.time * speed * corrector, lengthx);
                yOffset = Mathf.PingPong(Time.time * speed, lengthy);
            }
            else
            {
                xOffset = Mathf.PingPong(Time.time * speed, lengthx);
                yOffset = Mathf.PingPong(Time.time * speed, lengthy);
            }
        }
        else if(lengthx != 0f && lengthy == 0f)
        {
            xOffset = Mathf.PingPong(Time.time * speed, lengthx);
        }
        else if(lengthy != 0f && lengthx == 0f)
        {
            yOffset = Mathf.PingPong(Time.time * speed, lengthx);
        }
        
        gameObject.transform.position = startPoint + new Vector3(xOffset, yOffset, 0);
        //transform.position = new Vector3(Mathf.PingPong(Time.time * speed, lengthx) + startPoint.position.x, transform.position.y, transform.position.z);
    }
}
