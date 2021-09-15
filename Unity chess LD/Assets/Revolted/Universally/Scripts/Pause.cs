using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public GameObject pausePanel;

    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            isPaused = true;
            Cursor.visible = false;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(KeyCode.P) && isPaused == true)
        {
            isPaused = false;
            pausePanel.SetActive(false);
            Cursor.visible = true;
            Time.timeScale = 1;
        }
    }
}
