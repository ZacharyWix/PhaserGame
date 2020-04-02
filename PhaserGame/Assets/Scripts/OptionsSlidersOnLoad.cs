using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSlidersOnLoad : MonoBehaviour
{
    public bool isSoundEffects = false;
    public bool isMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        if(isSoundEffects && !isMusic)
        {
            float value = GameObject.Find("Game Manager").GetComponent<musicManager>().getSoundEffectsValue();
            gameObject.GetComponent<Slider>().value = value;
        }   
        else if (isMusic && !isSoundEffects)
        {
            float value = GameObject.Find("Game Manager").GetComponent<musicManager>().getMusicValue();
            gameObject.GetComponent<Slider>().value = value;
        }
    }
}
