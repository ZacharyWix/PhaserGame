using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class deathCounter : MonoBehaviour
{
    public TextMeshProUGUI deathCountText;
    public TextMeshProUGUI lowestDeathsText;
    public TextMeshProUGUI lowestDeathsText1;
    public TextMeshProUGUI totalDeathsText;
    public TextMeshProUGUI totalDeathsText1;

    private phaserManager gm;

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<phaserManager>();
        updateDeathCounter();
    }

    public void updateDeathCounter()
    {
        deathCountText.text = gm.getDeathCount().ToString();
        if (level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex) != -1)
        {
            lowestDeathsText.text = level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex).ToString();
        }
        else
        {
            lowestDeathsText.text = "";
        }
        totalDeathsText.text = level.getTotalDeaths().ToString();
        int d = 0;
        if (level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex) != -1)
        {
            d = level.getLevelDeaths(SceneManager.GetActiveScene().buildIndex);
        }
        totalDeathsText.text = (level.getTotalDeaths() - d + gm.getDeathCount()).ToString();
        lowestDeathsText1.text = lowestDeathsText.text;
        totalDeathsText1.text = totalDeathsText.text;
    }
}
