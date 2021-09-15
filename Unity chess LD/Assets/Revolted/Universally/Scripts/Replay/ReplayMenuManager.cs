using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenuManager : MonoBehaviour
{
    public void LoadScene(string scena)
    {
        SceneManager.LoadScene(scena);
    }
}
