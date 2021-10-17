using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [Header("Game Canvas")]
    public Animator gameCanvas;
    [Header("Score")]
    public Text scoreText;
    [Header("Coins")]
    public Text coinText;
    [Header("Modifier")]
    public Text modifierText;
    
    // Game Over Menu
    [Header("Game Over Panel")]
    public Animator gameOverAnim;
    public Text gameOverScore;
    public Text gameOverCoins;

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
            FindObjectOfType<GlacierSpawner>().IsScrolling = true; //

            FindObjectOfType<CameraMotor>().IsMoving = true;
            gameCanvas.SetTrigger("Show");
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

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        IsDead = true;
        FindObjectOfType<GlacierSpawner>().IsScrolling = false; //
        gameOverScore.text = score.ToString("0");
        gameOverCoins.text = coinScore.ToString("0");
        gameOverAnim.SetTrigger("gameOver");
    }
}

























