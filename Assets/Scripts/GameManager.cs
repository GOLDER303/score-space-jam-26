using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] LeaderboardManager leaderboardManager;

    private int score;

    public void GameOver()
    {
        gameOverScreen.Setup(score);
        StartCoroutine(leaderboardManager.SubmitScoreRoutine(score));
        StartCoroutine(leaderboardManager.FetchTopHighScoresRoutine());
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
