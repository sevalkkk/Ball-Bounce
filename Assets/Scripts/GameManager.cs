using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject GameStartUI;
    public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameStart()
    {
        GameStartUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void ScoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
