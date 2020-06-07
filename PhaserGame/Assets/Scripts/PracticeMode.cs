using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeMode : MonoBehaviour
{
    private static bool practiceStatus; //true for practice mode, false for not
    public Sprite normalSprite;
    public Sprite practiceSprite;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        practiceStatus = MainMenu.getPractice();

        if(practiceStatus)
        {
            sr.sprite = practiceSprite;
        }
        else
        {
            sr.sprite = normalSprite;
        }
    }

    public static bool isPracticeMode()
    {
        return practiceStatus;
    }
}
