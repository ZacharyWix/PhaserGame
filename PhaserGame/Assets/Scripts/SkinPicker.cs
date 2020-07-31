using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinPicker : MonoBehaviour
{
    int num = 0;
    int anum = 0;
    public Sprite sp0, sp1, sp2, sp3, sp4, sp5, sp6, sp7, sp8, sp9, sp10, sp11, sp12, sp13, sp14, sp15;
    public Sprite ap1, ap2, ap3, ap4;
    public Image pic, pic1, pic2, pic3;
    public SpriteRenderer accessory;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            updateImage();
        }
        num = MainMenu.GetSkin();
        anum = MainMenu.GetAccessory();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            if (num == 0)
            {
                rend.sprite = sp0;
            }
            if (num == 1)
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

            if (anum == 1)
            {
                accessory.sprite = ap1;
            }
            if (anum == 2)
            {
                accessory.sprite = ap2;
            }
            if (anum == 3)
            {
                accessory.sprite = ap3;
            }
            if (anum == 4)
            {
                accessory.sprite = ap4;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (num != MainMenu.GetSkin() || anum != MainMenu.GetAccessory())
        {
            updateImage();
        }
    }

    public void updateImage()
    {
        num = MainMenu.GetSkin();
        anum = MainMenu.GetAccessory();
        if (num == 0)
        {
            pic.sprite = sp0;
        }
        if (num == 1)
        {
            pic.sprite = sp1;
        }
        if (num == 2)
        {
            pic.sprite = sp2;
        }
        if (num == 3)
        {
            pic.sprite = sp3;
        }
        if (num == 4)
        {
            pic.sprite = sp4;
        }
        if (num == 5)
        {
            pic.sprite = sp5;
        }
        if (num == 6)
        {
            pic.sprite = sp6;
        }
        if (num == 7)
        {
            pic.sprite = sp7;
        }
        if (num == 8)
        {
            pic.sprite = sp8;
        }
        if (num == 9)
        {
            pic.sprite = sp9;
        }
        if (num == 10)
        {
            pic.sprite = sp10;
        }
        if (num == 11)
        {
            pic.sprite = sp11;
        }
        if (num == 12)
        {
            pic.sprite = sp12;
        }
        if (num == 13)
        {
            pic.sprite = sp13;
        }
        if (num == 14)
        {
            pic.sprite = sp14;
        }
        if (num == 15)
        {
            pic.sprite = sp15;
        }
        pic2.sprite = pic.sprite;


        if (anum == 0)
        {
            pic1.enabled = false;
            pic3.enabled = false;
        }
        else {
            pic1.enabled = true;
            pic3.enabled = true;
        }


        if (anum == 1)
        {
            pic1.sprite = ap1;
        }
        if (anum == 2)
        {
            pic1.sprite = ap2;
        }
        if (anum == 3)
        {
            pic1.sprite = ap3;
        }
        if (anum == 4)
        {
            pic1.sprite = ap4;
        }
        pic3.sprite = pic1.sprite;

    }
}
