using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class deathStats : MonoBehaviour
{
    public TextMeshProUGUI W1L1, W1L2, W1L3, W1L4, W1L5, W1L6, W1L7, W1L8, W1L9, W1L10;
    public TextMeshProUGUI W2L1, W2L2, W2L3, W2L4, W2L5, W2L6, W2L7, W2L8, W2L9, W2L10;
    public TextMeshProUGUI W3L1, W3L2, W3L3, W3L4, W3L5, W3L6, W3L7, W3L8, W3L9, W3L10;
    // Start is called before the first frame update
    void Start()
    {
        updateDeathStats();
    }

    public void updateDeathStats(){
        W1L1.text = getDeathText(1);
        W1L2.text = getDeathText(2);
        W1L3.text = getDeathText(3);
        W1L4.text = getDeathText(4);
        W1L5.text = getDeathText(5);
        W1L6.text = getDeathText(6);
        W1L7.text = getDeathText(7);
        W1L8.text = getDeathText(8);
        W1L9.text = getDeathText(9);
        W1L10.text = getDeathText(10);
        W2L1.text = getDeathText(11);
        W2L2.text = getDeathText(12);
        W2L3.text = getDeathText(13);
        W2L4.text = getDeathText(14);
        W2L5.text = getDeathText(15);
        W2L6.text = getDeathText(16);
        W2L7.text = getDeathText(17);
        W2L8.text = getDeathText(18);
        W2L9.text = getDeathText(19);
        W2L10.text = getDeathText(20);
        W3L1.text = getDeathText(21);
        W3L2.text = getDeathText(22);
        W3L3.text = getDeathText(23);
        W3L4.text = getDeathText(24);
        W3L5.text = getDeathText(25);
        W3L6.text = getDeathText(26);
        W3L7.text = getDeathText(27);
        W3L8.text = getDeathText(28);
        W3L9.text = getDeathText(29);
        W3L10.text = getDeathText(30);
    }

    public string getDeathText(int num) {
        string text = "X";
        if(level.getLevelDeaths(num) != -1) {
            text = level.getLevelDeaths(num).ToString();
        }
        return text;
    }
}
