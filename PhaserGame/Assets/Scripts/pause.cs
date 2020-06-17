using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject endMenu;
    public EventSystem eventSys;
    private bool isPaused = false;
    private move2D moveScript;
    private Rigidbody2D rb;
    public GameObject resume;
    private bool isResuming;
    public GameObject boundary;
    public GameObject pauseCol;
    public GameObject endCol;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<move2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7") && !endMenu.gameObject.activeSelf)
        {

            if (!optionsMenu.gameObject.activeSelf)
            {
                togglePause();
                if (!pauseMenu.gameObject.activeSelf)
                {
                    pauseMenu.SetActive(true);
                    eventSys.SetSelectedGameObject(resume);
                }
                else
                {
                    pauseMenu.SetActive(false);
                    rb.WakeUp();
                    eventSys.SetSelectedGameObject(null);
                }
            }
            else
            {
                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);
                eventSys.SetSelectedGameObject(resume);
            }
        }
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        if (!isPaused)
        {
            UnityEngine.Cursor.visible = false;
        }
        if (isResuming)
        {
            pauseMenu.SetActive(false);
            rb.WakeUp();
            togglePause();
            isResuming = false;
        }
        if (endMenu.activeSelf || pauseMenu.activeSelf || optionsMenu.activeSelf)
        {
            boundary.SetActive(false);
            UnityEngine.Cursor.visible = true;
        }
        else
        {
            boundary.SetActive(true);
        }
        if (pauseMenu.activeSelf)
        {
            pauseCol.SetActive(true);
        }
        else
        {
            pauseCol.SetActive(false);
        }
        if (endMenu.activeSelf)
        {
            endCol.SetActive(true);
        }
        else
        {
            endCol.SetActive(false);
        }
    }

    public void togglePause()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        moveScript.setControls(isPaused);
        isPaused = !isPaused;
        Time.timeScale = 1;
    }

    public bool getPause()
    {
        return isPaused;
    }

    public void space()
    {
        isResuming = true;
    }
}
