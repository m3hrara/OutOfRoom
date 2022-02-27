using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Menu 1");
    }
    public void GoToInstructions()
    {
        SceneManager.LoadScene("Menu 2");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
