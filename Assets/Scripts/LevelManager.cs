using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance
    {
        get;
        set;
    }
    
    // Level Spawning
    
    // list of Pieces
    public List<Piece> ramps = new List<Piece>();
    public List<Piece> longBlocks = new List<Piece>();
    public List<Piece> jumps = new List<Piece>();
    public List<Piece> slides = new List<Piece>();
    public List<Piece> pieces = new List<Piece>(); // All Pieces in the pool

    public Piece GetPiece(PieceType pt, int visualIndex)
    {
        Piece p = pieces.Find(x => x.type == pt && x.visualIndex == visualIndex && !x.gameObject.activeSelf);

        if (p == null)
        {
            GameObject go = null;
            if (pt == PieceType.Ramp)
            {
                go = ramps[visualIndex].gameObject;
            }
            else if (pt == PieceType.Jump)
            {
                go = jumps[visualIndex].gameObject;
            }
            else if (pt == PieceType.LongBlock)
            {
                go = longBlocks[visualIndex].gameObject;
            }
            else if (pt == PieceType.Slide)
            {
                go = slides[visualIndex].gameObject;
            }

            go = Instantiate(go);
            p = go.GetComponent<Piece>();
            pieces.Add(p);
        }
        
        return p;
    }
}














