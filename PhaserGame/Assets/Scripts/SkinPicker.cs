using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPicker : MonoBehaviour
{
    int num = 0;
    public Sprite sp0, sp1, sp2, sp3, sp4, sp5, sp6, sp7, sp8, sp9, sp10, sp11, sp12, sp13, sp14, sp15;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        num = MainMenu.GetSkin();
        if(num == 0)
        {
            rend.sprite = sp0;
        }
        if(num == 1)
        {
            rend.sprite = sp1;
        }
        if (num == 2)
        {
            rend.sprite = sp2;
        }
        if (num == 3)
        {
            rend.sprite = sp3;
        }
        if (num == 4)
        {
            rend.sprite = sp4;
        }
        if (num == 5)
        {
            rend.sprite = sp5;
        }
        if (num == 6)
        {
            rend.sprite = sp6;
        }
        if (num == 7)
        {
            rend.sprite = sp7;
        }
        if (num == 8)
        {
            rend.sprite = sp8;
        }
        if (num == 9)
        {
            rend.sprite = sp9;
        }
        if (num == 10)
        {
            rend.sprite = sp10;
        }
        if (num == 11)
        {
            rend.sprite = sp11;
        }
        if (num == 12)
        {
            rend.sprite = sp12;
        }
        if (num == 13)
        {
            rend.sprite = sp13;
        }
        if (num == 14)
        {
            rend.sprite = sp14;
        }
        if (num == 15)
        {
            rend.sprite = sp15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
