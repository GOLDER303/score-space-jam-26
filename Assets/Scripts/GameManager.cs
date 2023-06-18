using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;

    private int score;

    public void GameOver()
    {
        gameOverScreen.Setup(score);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
