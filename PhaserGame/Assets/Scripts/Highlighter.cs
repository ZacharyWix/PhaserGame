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
        char[] arrChar = { 'A', 'c', 'c' };
        string skinNum = "";
        if (this.gameObject.name.Contains("Skin"))
        {
            skinNum = this.gameObject.name.TrimStart(MyChar);
        }
        if (this.gameObject.name.Contains("Acc"))
        {
            skinNum = this.gameObject.name.TrimStart(arrChar);
        }
        num = Int32.Parse(skinNum);

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name.Contains("Skin"))
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
        if (this.gameObject.name.Contains("Acc"))
        {
            if (MainMenu.GetAccessory() == num)
            {
                frame.SetActive(true);
            }
            else
            {
                frame.SetActive(false);
            }
        }
    }
}
