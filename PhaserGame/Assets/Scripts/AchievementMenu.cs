using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementMenu : MonoBehaviour
{
    public Canvas canvas;
    List<Image> locked = new List<Image>();
    List<Image> unlocked = new List<Image>();
    [Header("stat String Data")]
    public string[] statStrings;

    // Start is called before the first frame update
    void Start()
    {
        Image[] images = canvas.GetComponentsInChildren<Image>(true);
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].name.Contains("Unlocked"))
            {
                unlocked.Add(images[i]);
            }
            else if (images[i].name.Contains("Locked"))
            {
                locked.Add(images[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIcons()
    {
        for (int i = 0; i < locked.Count; i++)
        {
            if (Achievement.getUnlocked(i))
            {
                locked[i].enabled = false;
                unlocked[i].enabled = true;
            }
            else
            {
                locked[i].enabled = true;
                unlocked[i].enabled = false;
            }
        }
    }
}
