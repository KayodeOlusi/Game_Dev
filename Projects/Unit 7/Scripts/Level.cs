using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // TODO make an assertion and/or get automatically
    //public Grid grid;
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    public Grid grid;
    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES
    }

    protected LevelType type;

    public LevelType Type {
        get { return type; } 
    }
    protected int currentScore;

    private bool didWin;

    private void Start()
    {
        hud.SetScore(currentScore);
    }

    public virtual void GameWin()
    {
        hud.OnGameWin(currentScore);
        grid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {
        hud.OnGameLose();
        grid.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {
        Debug.Log("You moved!");
    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }

    protected virtual IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return null;
        }

        if (didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
