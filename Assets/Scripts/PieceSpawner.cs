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
    private Piece currentPiece;
    
    public void Spawn()
    {
        //currentPiece = // get me a new Piece from the pool
        currentPiece.gameObject.SetActive(true);
        currentPiece.transform.SetParent(transform, false);
    }

    public void DeSpawn()
    {
        currentPiece.gameObject.SetActive(false);
    }
}
