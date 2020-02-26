using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    private int lastPressed = 0;

    public int getLastPressed() { return lastPressed; }
    public void setLastPressed(int press) { lastPressed = press; }
    /*public enum colors { red, blue, green, yellow };

    public colors currentColor;

    public List<GameObject> coloredObjects;

    void Start()
    {
        currentColor = colors.red;
        coloredObjects = FindGameObjectsInLayer(9);
    }

    void Update()
    {
        bool redPress = Input.GetButtonDown("ColorRed");
        bool bluePress = Input.GetButtonDown("ColorBlue");
        bool greenPress = Input.GetButtonDown("ColorGreen");
        bool yellowPress = Input.GetButtonDown("ColorYellow");

        if (redPress && !bluePress && !greenPress && !yellowPress)
        {
            currentColor = colors.red;
            toggleObjects(coloredObjects);
        }
        else if (bluePress && !redPress && !greenPress && !yellowPress)
        {
            currentColor = colors.blue;
            toggleObjects(coloredObjects);
        }
        else if (greenPress && !bluePress && !redPress && !yellowPress)
        {
            currentColor = colors.green;
            toggleObjects(coloredObjects);
        }
        else if (yellowPress && !bluePress && !redPress && !greenPress)
        {
            currentColor = colors.yellow;
            toggleObjects(coloredObjects);
        }

    }

    private List<GameObject> FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList;
    }

    private void toggleObjects(List<GameObject> list)
    {
        int listLength = list.Count;
        for(int x = 0; x < listLength; x++)
        {
            colorSwitcher cs = list[x].GetComponent<colorSwitcher>();
            cs.updateBlocks();
        }
    }*/
}
