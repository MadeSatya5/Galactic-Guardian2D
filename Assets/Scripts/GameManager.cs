using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMP_Text scoreText;
    private ScoreManager scoreManager;
    public static bool isGameOver;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void GameOver()
    {
        audioManager.PlaySFX(audioManager.die);
        isGameOver = true;
        gameOverUI.SetActive(true);
        scoreText.text = "Score: " + (int)scoreManager.Score;
    }
    public void Restart()
    {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
