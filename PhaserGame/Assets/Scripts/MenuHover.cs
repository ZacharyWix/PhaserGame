using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuHover : MonoBehaviour
{
    public GameObject button;
    EventSystem m_EventSystem;    
    // Start is called before the first frame update
    void Start()
    {
        print("starts");
        m_EventSystem = EventSystem.current;
        print(m_EventSystem.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        print("enters");
        m_EventSystem.SetSelectedGameObject(button);
    }
}
