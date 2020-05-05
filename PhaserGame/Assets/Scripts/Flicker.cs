using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Flicker : MonoBehaviour
{ 
    public GameObject green;
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    private float time = 0;
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10)
        {
            time = 0;
            if (count == 4)
            {
                count = 1;
            }
            else count += 1;
        }
        if (count == 1)
        {
            green.SetActive(true);
            blue.SetActive(false);
            red.SetActive(false);
            yellow.SetActive(false);
            set(green);
        }
        if (count == 2)
        {
            green.SetActive(false);
            blue.SetActive(true);
            red.SetActive(false);
            yellow.SetActive(false);
            set(blue);
        }
        if (count == 3)
        {
            green.SetActive(false);
            blue.SetActive(false);
            red.SetActive(true);
            yellow.SetActive(false);
            set(red);
        }
        if (count == 4)
        {
            green.SetActive(false);
            blue.SetActive(false);
            red.SetActive(false);
            yellow.SetActive(true);
            set(yellow);
        }
    }

    public void set(GameObject color)
    {
        if (time < 0.25)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        }
        if (time > 0.25 && time < 0.5)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 0.5 && time < 0.75)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 0.5 && time < 0.75)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 1 && time < 1.1)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 1.1 && time < 1.2)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 1.2 && time < 1.3)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 1.3 && time < 1.4)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 1.4 && time < 1.5)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 1.5 && time < 1.75)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 1.75 && time < 2)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 2 && time < 2.1)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 2 && time < 2.1)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 2.1 && time < 2.2)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 204);
        }
        if (time > 2.2 && time < 2.3)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 2.3 && time < 2.4)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 204);
        }
        if (time > 2.4 && time < 2.5)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        if (time > 2.5 && time < 7.5)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        if (time > 7.5 && time < 7.6)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 7.6 && time < 7.7)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        if (time > 7.7 && time < 7.8)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 7.8 && time < 7.9)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 7.9 && time < 8)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 204);
        }
        if (time > 8 && time < 8.25)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 8.25 && time < 8.5)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 8.5 && time < 8.6)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 8.6 && time < 8.7)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 8.7 && time < 8.8)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 8.8 && time < 8.9)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 8.9 && time < 9)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 9 && time < 9.25)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        if (time > 9.25 && time < 9.5)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 102);
        }
        if (time > 9.5 && time < 9.75)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 51);
        }
        if (time > 9.75 && time < 10)
        {
            color.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        }
    }
}
