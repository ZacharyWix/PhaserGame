using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathStats : MonoBehaviour
{
    public Text W1L1, W1L2, W1L3, W1L4, W1L5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateDeathStats(){
        W1L1.text = getDeathText(1);
        W1L2.text = getDeathText(2);
        W1L3.text = getDeathText(3);
        W1L4.text = getDeathText(4);
        W1L5.text = getDeathText(5);
    }

    public string getDeathText(int num) {
        string text = "Unfinished";
        if(level.getLevelDeaths(num) != -1) {
            text = level.getLevelDeaths(num).ToString();
        }
        print(text);
        return text;
    }
}
