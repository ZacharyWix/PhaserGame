using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public GameObject frame;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        char[] MyChar = { 'S', 'k', 'i', 'n'};
        string skinNum = this.gameObject.name.TrimStart(MyChar);
        num = Int32.Parse(skinNum);

    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.GetSkin() == num)
        {
            frame.SetActive(true);
        }
        else
        {
            frame.SetActive(false);
        }
    }
}
