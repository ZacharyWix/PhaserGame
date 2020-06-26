using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSwitcher : MonoBehaviour
{

    public bool red;
    public bool blue;
    public bool green;
    public bool yellow;
    public bool isSpike;
    public Sprite onSprite;
    public Sprite offSprite;
    private SpriteRenderer spriteRen;
    private EdgeCollider2D[] edgeCol;
    private BoxCollider2D[] boxCol;
    private colorController colorCon;
    private int lastPressed;
    bool redPress;
    bool bluePress;
    bool greenPress;
    bool yellowPress;

    public void ColorSelect(string color)
    {
        redPress = false;
        bluePress = false;
        greenPress = false;
        yellowPress = false;
        if (color == "red")
        {
            redPress = true;
        }
        if (color == "blue")
        {
            bluePress = true;
        }
        if (color == "green")
        {
            greenPress = true;
        }
        if (color == "yellow")
        {
            yellowPress = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        colorCon = GameObject.Find("Player").GetComponent<colorController>();
        lastPressed = colorCon.getLastPressed();
        if (isSpike)
        {
            spriteRen = GetComponent<SpriteRenderer>();
            spriteRen.sprite = onSprite;

            boxCol = GetComponents<BoxCollider2D>();
            int boxColSize = boxCol.Length;
            for (int x = 0; x < boxColSize; x++)
            {
                boxCol[x].enabled = true;
            }

            edgeCol = GetComponents<EdgeCollider2D>();
            int edgeColSize = edgeCol.Length;
            for (int x = 0; x < edgeColSize; x++)
            {
                edgeCol[x].enabled = true;
            }

            if (red && lastPressed == 1)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
            }
            else if (blue && lastPressed == 2)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
            }
            else if (green && lastPressed == 3)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
            }
            else if (yellow && lastPressed == 4)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
            }
        }
        else
        {
            spriteRen = GetComponent<SpriteRenderer>();
            spriteRen.sprite = offSprite;

            boxCol = GetComponents<BoxCollider2D>();
            int boxColSize = boxCol.Length;
            for (int x = 0; x < boxColSize; x++)
            {
                boxCol[x].enabled = false;
            }

            edgeCol = GetComponents<EdgeCollider2D>();
            int edgeColSize = edgeCol.Length;
            for (int x = 0; x < edgeColSize; x++)
            {
                edgeCol[x].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        lastPressed = colorCon.getLastPressed();
        if (isSpike)
        {
            ColoredSpikes();
        }
        else
        {
            ColoredBlocks();
        }
    }

    void ToggleBlock(BoxCollider2D[] boxColliders, EdgeCollider2D[] edgeColliders, bool isActive, Sprite switchSprite)
    {
        int numBoxColliders = boxColliders.Length;
        for (int x = 0; x < numBoxColliders; x++)
        {
            boxColliders[x].enabled = isActive;
        }

        int numEdgeColliders = edgeColliders.Length;
        for (int x = 0; x < numEdgeColliders; x++)
        {
            edgeColliders[x].enabled = isActive;
        }
        spriteRen.sprite = switchSprite;
    }

    void ColoredSpikes()
    {
        if (red)
        {
            if (redPress && !bluePress && !greenPress && !yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(1);
            }
            else if (bluePress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(2);
            }
            else if (greenPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(3);
            }
            else if (yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(4);
            }
        }
        else if (blue)
        {
            if (bluePress && !redPress && !greenPress && !yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(2);
            }
            else if (redPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(1);
            }
            else if (greenPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(3);
            }
            else if (yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(4);
            }
        }
        else if (green)
        {
            if (greenPress && !bluePress && !redPress && !yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(3);

            }
            else if (bluePress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(2);
            }
            else if (redPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(1);
            }
            else if (yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(4);
            }
        }
        else if (yellow)
        {
            if (yellowPress && !bluePress && !redPress && !greenPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(4);
            }
            else if (bluePress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(2);
            }
            else if (greenPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(3);
            }
            else if (redPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(1);
            }
        }
    }

    void ColoredBlocks()
    {
        if (red)
        {
            if (redPress && !bluePress && !greenPress && !yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(1);
            }
            else if (bluePress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(2);
            }
            else if (greenPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(3);
            }
            else if (yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(4);
            }
        }
        else if (blue)
        {
            if (bluePress && !redPress && !greenPress && !yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(2);
            }
            else if (redPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(1);
            }
            else if (greenPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(3);
            }
            else if (yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(4);
            }
        }
        else if (green)
        {
            if (greenPress && !bluePress && !redPress && !yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(3);
            }
            else if (bluePress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(2);
            }
            else if (redPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(1);
            }
            else if (yellowPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(4);
            }
        }
        else if (yellow)
        {
            if (yellowPress && !bluePress && !redPress && !greenPress)
            {
                ToggleBlock(boxCol, edgeCol, true, onSprite);
                colorCon.setLastPressed(4);
            }
            else if (bluePress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(2);
            }
            else if (greenPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(3);
            }
            else if (redPress)
            {
                ToggleBlock(boxCol, edgeCol, false, offSprite);
                colorCon.setLastPressed(1);
            }
        }
    }

    public int getLastPressed() { return lastPressed; }
}