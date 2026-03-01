using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;

    public int score = 0;
    public TMP_Text scoreText;

    private int brickCount;

    [Header("PowerUp Spawn")]
    public GameObject powerUpPrefab;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 10f;
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 4f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
        StartCoroutine(SpawnPowerUps());
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void BrickDestroyed()
    {
        brickCount--;

        if (brickCount <= 0 || score == 230)
        {
            PlayerPrefs.SetInt("FinalScore", score);
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
}