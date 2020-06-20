using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour
{
    public GameObject popup;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == button)
        {
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
        }
    }
    public void OnMouseEnter()
    {
        popup.SetActive(true);
    }
    public void OnMouseExit()
    {
        popup.SetActive(false);
    }
}
