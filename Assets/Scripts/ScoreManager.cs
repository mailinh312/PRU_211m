using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get => instance; 
    }

    [SerializeField]
    public float highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField]
    protected float currentScore;

    [SerializeField] 
    protected TextMeshProUGUI scoreTxt;

    void Start()
    {
        this.currentScore = 0;
    }

    void Update()
    {
        scoreTxt.text = currentScore + "";
        if(currentScore > PlayerPrefs.GetFloat("highScore")) {
            PlayerPrefs.SetFloat("highScore", currentScore);
        }

        highScore = PlayerPrefs.GetFloat("highScore");
    }

    public void addScore(float score)
    {
        this.currentScore += score;
    }
}
