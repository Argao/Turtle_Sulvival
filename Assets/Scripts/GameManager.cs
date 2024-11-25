
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject title;
    public int score = 0;


    private void Awake()
    {
        gameOver.SetActive(false);
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        
        playButton.SetActive(false);
        gameOver.SetActive(false);
        title.SetActive(false);
        
        Time.timeScale = 1f;
        player.enabled = true;
        
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();
        
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }
    
    public void IncreaseScore()
    {
        score ++;
        scoreText.text = score.ToString();
    }
}
