using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float spawnInterval = 5f;
    public float height = 4f;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 2f, spawnInterval);
    }

    void SpawnPowerUp()
    {
        float randomY = Random.Range(-height, height);

        Vector3 spawnPos = new Vector3(10f, randomY, 0);

        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }
}