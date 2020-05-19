using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMenu : MonoBehaviour
{
    public Canvas canvas;
    List<Image> complete = new List<Image>();
    List<Image> incomplete = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        Image[] images = canvas.GetComponentsInChildren<Image>(true);
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].name.Contains("Complete"))
            {
                complete.Add(images[i]);
            }
            else if (images[i].name.Contains("Incomplete"))
            {
                incomplete.Add(images[i]);
            }
        }
        updateIcons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIcons()
    {
        print("Incomplete: " + incomplete[0].enabled); 
        print("Complete: " + complete[0].enabled);
        for (int i = 1; i < complete.Count + 1; i++)
        {
            if (level.getLevelDeaths(i) != -1)
            {
                print("incomplete");
                incomplete[i - 1].enabled = false;
                complete[i - 1].enabled = true;
            }
            else
            {
                incomplete[i - 1].enabled = true;
                complete[i -1].enabled = false;
            }
        }
    }
}
