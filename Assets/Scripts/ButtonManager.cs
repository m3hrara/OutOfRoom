using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public GameObject panel;
    MovementComponent movementComponent;
    private void Start()
    {
        movementComponent = FindObjectOfType<MovementComponent>();
    }
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
    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        movementComponent.isPaused = true;
    }
    public void Unpause()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        movementComponent.isPaused = false;
    }
}
