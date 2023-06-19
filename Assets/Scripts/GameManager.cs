using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] LeaderboardManager leaderboardManager;
    [SerializeField] TextMeshProUGUI inGameScoreText;

    private int score;

    public void GameOver()
    {
        inGameScoreText.enabled = false;
        gameOverScreen.Setup(score);
        StartCoroutine(SubmitScore(score));
    }

    private IEnumerator SubmitScore(int score)
    {
        yield return leaderboardManager.SubmitScoreRoutine(score);
        yield return leaderboardManager.FetchTopHighScoresRoutine();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        inGameScoreText.text = "Score: " + score;
    }
}
