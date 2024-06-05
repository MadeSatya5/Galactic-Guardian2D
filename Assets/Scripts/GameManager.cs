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
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
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
