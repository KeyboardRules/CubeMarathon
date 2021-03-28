using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    float score,highScore;
    bool gameOver;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
    }
    private void Update()
    {
        if (!gameOver)
        {
            score += Time.deltaTime;
            if (score > highScore)
            {
                PlayerPrefs.SetFloat("highScore", highScore);
            }
            UIManager.instance.SetScore((int)score, (int)highScore);
        }
    }
    public void GameOver()
    {
        gameOver = true;
        UIManager.instance.GameOver();
    }
    
}
