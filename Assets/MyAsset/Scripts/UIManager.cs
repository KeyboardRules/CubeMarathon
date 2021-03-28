using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI score1,score2,highScore;
    public GameObject pauseMenu, gameOverMenu, pauseButton,scoreUI;


    private void Awake()
    {
        instance = this;
        highScore.text = "High Score: " + PlayerPrefs.GetFloat("highScore").ToString();
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void ReturnGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        scoreUI.SetActive(false);
        gameOverMenu.SetActive(true);
    }
    public void SetScore(int score,int highScore)
    {
        score1.text = score.ToString();
        score2.text = "Score: "+ score.ToString();
        this.highScore.text = "High Score: " + score.ToString();
    }
}
