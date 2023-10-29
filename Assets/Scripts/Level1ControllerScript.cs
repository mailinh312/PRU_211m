using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private TextMeshProUGUI highScoreGameOverPanel, highScoreNextLevelPanel;

    [SerializeField]
    private ScoreManager scoreManager;

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

    public void newGame2()
    {
        Application.LoadLevel("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        Application.LoadLevel("Level2");
    }
    public void NextLevel2()
    {
        Application.LoadLevel("Level2");
    }

    public void Replay()
    {
        Application.LoadLevel("Level1");
    }

    public void Replay2()
    {
        Application.LoadLevel("Level2");
    }

    public void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        highScoreGameOverPanel.SetText("High Score: " + Convert.ToString(scoreManager.highScore));
    }

    public void showNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
        highScoreNextLevelPanel.SetText("High Score: " + Convert.ToString(scoreManager.highScore));
    }
}
