using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
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

    private void Awake()
    {
        Instance = this;
        UpdateScore();

        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (MobileInput.Instance.Tap && !isGameStarted)
        {
            isGameStarted = true;
            motor.StartRunning();
        }
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
        modifierText.text = modifierScore.ToString();
    }
}

























