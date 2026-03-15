using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float height = 4f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(-height, height);

        Vector3 pos = new Vector3(10, randomY, 0);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}