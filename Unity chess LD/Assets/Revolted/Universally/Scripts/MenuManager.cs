using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject sidePanel;


    void Start()
    {
        sidePanel.SetActive(false);
    }

    public void NewGame()
    {
        if(sidePanel.activeSelf)
        {
            sidePanel.SetActive(false);
        }
        else
        {
            sidePanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string scena)
    {
        SceneManager.LoadScene(scena);
    }
}
