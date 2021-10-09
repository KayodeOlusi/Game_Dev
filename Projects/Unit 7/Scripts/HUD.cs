using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // TODO get this automatically and/or make an assertion
    public Level level;
    public GameOver gameOver;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;
    public Image[] stars;
    //private bool isGamover = false;

    private int starIndex = 0;

    private void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == starIndex)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

        int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            if (i == visibleStar)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }

        starIndex = visibleStar;
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    public void SetLevelType(Level.LevelType type)
    {
        switch (type)
        {
            case Level.LevelType.MOVES:
                remainingSubText.text = "moves remaining";
                targetSubtext.text = "target score";
                break;
            case Level.LevelType.OBSTACLE:
                remainingSubText.text = "moves remaining";
                targetSubtext.text = "bubbles remaining";
                break;
            case Level.LevelType.TIMER:
                remainingSubText.text = "time remaining";
                targetSubtext.text = "target score";
                break;
        }
    }

    public void OnGameWin(int score)
    {
        //isGamover = true;
        gameOver.ShowWin(score, starIndex);
        if (starIndex > PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, starIndex);
        }
    }

    public void OnGameLose()
    {
        //isGamover = true;
        gameOver.ShowLose();
    }
}
