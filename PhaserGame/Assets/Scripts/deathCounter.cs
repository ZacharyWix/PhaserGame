using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathCounter : MonoBehaviour
{
    public Text deathCountText;
    public Text lowestDeathsText;
    public Text lowestDeathsText1;
    public Text totalDeathsText;
    public Text totalDeathsText1;
    private phaserManager gm;

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        updateDeathCounter();
    }

    public void updateDeathCounter()
    {
        deathCountText.text = gm.getDeathCount().ToString();
        //lowestDeathsText.text = "Hello";
        if (level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex) != 13084723)
        {
            lowestDeathsText.text = level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex).ToString();
        }
        else
        {
            lowestDeathsText.text = "";
        }
        totalDeathsText.text = level.getTotalDeaths().ToString();
        //lowestDeathsText.text = lowestDeathsText.text; //lowestDeathsText1.text = lowestDeathsText.text;
        int d = 0;
        if (level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex) != 13084723)
        {
            d = level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex);
        }
        totalDeathsText.text = (level.getTotalDeaths() - d + gm.getDeathCount()).ToString(); //totalDeathsText1.text = (level.getTotalDeaths() - d + gm.getDeathCount()).ToString();
        lowestDeathsText1.text = lowestDeathsText.text;
        totalDeathsText1.text = totalDeathsText.text;
    }
}
