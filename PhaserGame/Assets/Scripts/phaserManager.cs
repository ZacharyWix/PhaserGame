using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class phaserManager : MonoBehaviour
{
    private static int deathCount;

    // Start is called before the first frame update
    void Start()
    {
        deathCount = 0;
    }

    // Keeps the game manager loaded throughout scenes
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void incDeathCount()
    {
        deathCount++;
    }

    public int getDeathCount()
    {
        return deathCount;
    }
}
*/

public class phaserManager : MonoBehaviour
{
    private static int deathCount = 0;
    private static float time;
    private static phaserManager _instance;

    public static phaserManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    public void setDeathCount(int d)
    {
        deathCount = d;
    }
    public void incDeathCount()
    {
        deathCount++;
    }

    public int getDeathCount()
    {
        return deathCount;
    }

    public void resetDeathCount()
    {
        deathCount = 0;
    }

    public float getTime()
    {
        return time;
    }

    public void setTime(float t)
    {
        time = t;
    }
}