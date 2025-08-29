using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private bool Paused;
    public void RestarctCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if (Paused)
            Time.timeScale = 1;
        else 
            Time.timeScale = 0;
        Paused =!Paused;
    }
}
