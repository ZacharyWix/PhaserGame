using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject popup;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
