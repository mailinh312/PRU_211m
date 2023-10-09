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
    }

    public void addScore(float score)
    {
        this.currentScore += score;
    }
}
