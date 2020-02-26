using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentLevel = 0;
    private bool showWinScreen = false;
    public int winScreenWidth, winScreenHeight;
    void Start()
    {
        {
            if (PlayerPrefs.GetInt("Level Completed") > 0)
            {
                currentLevel = PlayerPrefs.GetInt("Level Completed");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SaveGame()
    {
        PlayerPrefs.SetInt("Level Completed", currentLevel);
    }


    public void CompleteLevel()
    {
        showWinScreen = true;
    }
    public void LoadNextLevel()
    {
        if (currentLevel < 2)
        {
            currentLevel += 1;
            print(currentLevel);
            SaveGame();
            PlayerPrefs.SetInt("Level Completed", currentLevel);
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            print("YOU WIN!");
        }
    }

    private void OnGUI()
    {
        if (showWinScreen)
        {
            Rect winScreenRect = new Rect(Screen.width / 2 - (Screen.width * .5f / 2), Screen.height / 2 - (Screen.height * .5f / 2), Screen.width * .5f, Screen.height * .5f);
            GUI.Box(winScreenRect, "Level Complete");
        }
    }
}
