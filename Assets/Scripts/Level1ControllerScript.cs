using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ControllerScript : MonoBehaviour
{

    private static Level1ControllerScript instance;
    public static Level1ControllerScript Instance
    {
        get => instance;
    }

    [SerializeField]
    private GameObject pausePanel, gameOverPanel, nextLevelPanel;

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

    public void NextLevel()
    {
        Application.LoadLevel("");
    }

    public void Replay()
    {
        Application.LoadLevel("Level1");
    }

    public void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void showNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
    }
}
