using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    private move2D moveScript;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<move2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
            pauseMenu.SetActive(!pauseMenu.gameObject.activeSelf);
        }
    }

    public void togglePause()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        moveScript.setControls(isPaused);
        isPaused = !isPaused;
    }
}
