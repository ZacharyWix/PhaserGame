using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public EventSystem eventSys;
    private bool isPaused = false;
    private move2D moveScript;
    private Rigidbody2D rb;
    public GameObject resume;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<move2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.Escape))
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
            UnityEngine.Cursor.visible = true;
        }
    }

    public void togglePause()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        moveScript.setControls(isPaused);
        isPaused = !isPaused;
    }
}
