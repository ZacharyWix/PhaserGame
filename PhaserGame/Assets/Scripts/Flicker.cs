using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{ 
    public GameObject title;
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        print(rend.material.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
