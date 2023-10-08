using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ControllerScript : MonoBehaviour
{
    public static Level1ControllerScript instance;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    void Awake()
    {
        makeInstance();
    }
    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void backMenu()
    {
        Application.LoadLevel("MainMenu");
        Time.timeScale = 1f;
    }

    public void newGame()
    {
        Application.LoadLevel("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
