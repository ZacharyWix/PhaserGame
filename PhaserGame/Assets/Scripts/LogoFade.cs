using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFade : MonoBehaviour
{
    private static bool loaded = false;
    public GameObject logo;
    public GameObject logoPanel;
    private float timer = 0;
    private Vector3 inc;
    // Start is called before the first frame update
    void Start()
    {
        inc = new Vector3(0.001f, 0.001f, 0.001f);
        if (!loaded)
        {
            logoPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (logoPanel.activeSelf)
        {
            logo.transform.localScale += inc;
            timer += Time.deltaTime;
            if(timer > 3)
            {
                logoPanel.SetActive(false);
            }
        }
    }
}
