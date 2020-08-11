using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BForBack : MonoBehaviour
{
    public GameObject menu;
    public GameObject button;
    EventSystem m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_EventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        print(m_EventSystem.currentSelectedGameObject);
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            menu.SetActive(true);
            m_EventSystem.SetSelectedGameObject(button);
        }
    }
}
