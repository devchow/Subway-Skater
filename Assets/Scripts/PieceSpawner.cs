/*
 *
 * Developer => Kelvin Mwangi
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public PieceType type;
    private Piece currentPieceSpawner;
    
    public void Spawn()
    {
        currentPieceSpawner = LevelManager.Instance.GetPiece(type, 0); // ---------- Randomize Later
        currentPieceSpawner.gameObject.SetActive(true);
        currentPieceSpawner.transform.SetParent(transform, false);
    }

    public void DeSpawn()
    {
        currentPieceSpawner.gameObject.SetActive(false);
    }
}
