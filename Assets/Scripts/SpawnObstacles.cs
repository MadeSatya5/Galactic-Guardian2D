using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject flyingMonster;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float minTimeBetweenSpawn = 0.5f;
    private float spawnTime;
    private ScoreManager scoreManager;
    private float spawnRateIncreaseFactor = 0.08f;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        if (scoreManager != null && !GameManager.isGameOver)
        {
            // Mengurangi timeBetweenSpawn berdasarkan skor pemain
            float decreaseAmount = scoreManager.Score * spawnRateIncreaseFactor;
            timeBetweenSpawn = Mathf.Max(2f - decreaseAmount, minTimeBetweenSpawn);
        }
        if (Time.time > spawnTime && !GameManager.isGameOver)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        if(!GameManager.isGameOver) 
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            GameObject toSpawn = Random.value > 0.5f ? obstacle : flyingMonster;
            Instantiate(toSpawn, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
    }
}
