﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public int maxCoin = 5;
    public float chanceToSpawn = 0.5f;
    public bool forceSpawnAll = true;

    private GameObject[] coins;

    private void Awake()
    {
        coins = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            coins[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        if (Random.Range(0.0f, 1.0f) < chanceToSpawn)
        {
            return;
        }

        if (forceSpawnAll)
        {
            foreach (GameObject go in coins)
            {
                go.SetActive(true);
            }
        }
        else
        {
            int r = Random.Range(0, maxCoin);
            for (int i = 0; i < r; i++)
            {
                coins[i].SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject go in coins)
        {
            go.SetActive(false);           
        }
    }
}










