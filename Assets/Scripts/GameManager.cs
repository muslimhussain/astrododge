using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject meteorSpawners;

    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private float increment = 1f;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverUI;
    
    private float score;
    private float highScore;

    void Start()
    {   
        gameOverUI.SetActive(false);

        score = 0;
        highScore = 0;

        highScore = PlayerPrefs.GetFloat("HighScore");
        highScoreText.text = "Best: " + Mathf.FloorToInt(highScore).ToString();
    }

    void Update()
    {
        IncrementScore();

        if (!player.GetComponent<Player>().isAlive)
        {
            EndGame();
        }
    }

    private void IncrementScore()
    {
        if (!player.GetComponent<Player>().isAlive) { return; }

        score += increment * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();

        if (score >= highScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScoreText.text = "Best: " + Mathf.FloorToInt(score).ToString();
        }
    }

    // Game End

    private void EndGame()
    {
        gameOverUI.SetActive(true);
        meteorSpawners.SetActive(false);
    }

    public void OnReplayButtonClicked()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
