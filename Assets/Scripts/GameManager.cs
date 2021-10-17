using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int CoinScoreAmt = 5;
    public static GameManager Instance
    {
        set;
        get;
    }

    public bool IsDead
    {
        set;
        get;
    }
    private bool isGameStarted = false;
    private PlayerMotor motor;
    
    // UI & UI Fields
    [Header("Score")]
    public Text scoreText;
    [Header("Coins")]
    public Text coinText;
    [Header("Modifier")]
    public Text modifierText;

    private float score;
    private float coinScore;
    private float modifierScore;
    private int lastScore;

    private void Awake()
    {
        Instance = this;
        modifierScore = 1;
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        
        modifierText.text = "x" + modifierScore.ToString("0.0");
        coinText.text = coinScore.ToString("0");
        scoreText.text = scoreText.text = score.ToString("0");
    }

    private void Update()
    {
        if (MobileInput.Instance.Tap && !isGameStarted)
        {
            isGameStarted = true;
            motor.StartRunning();
        }

        // Give Score to Player for continued running
        if (isGameStarted && !IsDead)
        {
            // Bump the Score
            score += (Time.deltaTime * modifierScore);
            if (lastScore != (int)score)
            {
                lastScore = (int)score;
                scoreText.text = score.ToString("0");
            }
        }
    }

    public void GetCoins()
    {
        coinScore++;
        coinText.text = coinScore.ToString("0");
        score += CoinScoreAmt;
        scoreText.text = scoreText.text = score.ToString("0");
    }

    public void UpdateModifier(float modifierAmount)
    {
        modifierScore = 1.0f + modifierAmount;
        modifierText.text = "x" + modifierScore.ToString("0.0");
    }
}

























