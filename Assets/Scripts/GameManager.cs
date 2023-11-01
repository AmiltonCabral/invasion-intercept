using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource backgroundMusic;
    public AudioSource gameOverMusic;
    public Text actualScoreText;
    public int actualScore;
    public GameObject gameOverPanel;
    public Text finalScoreText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        backgroundMusic.Play();

        actualScore = 0;
        actualScoreText.text = "SCORE: " + actualScore;
    }

    public void addScore(int value)
    {
        actualScore += value;
        actualScoreText.text = "SCORE: " + actualScore;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        backgroundMusic.Stop();
        gameOverMusic.Play();

        gameOverPanel.SetActive(true);

        if (actualScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", actualScore);
        }

        finalScoreText.text = "SCORE: " + actualScore;
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
    }
}
