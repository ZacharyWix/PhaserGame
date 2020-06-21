using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XForSwap : MonoBehaviour
{
    public GameObject xmenu;
    public GameObject xbutton;
    EventSystem x_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        x_EventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            this.gameObject.SetActive(false);
            xmenu.SetActive(true);
            x_EventSystem.SetSelectedGameObject(xbutton);
        }
    }
}
