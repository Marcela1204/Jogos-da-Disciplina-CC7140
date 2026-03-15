using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            ScoreManager.instance.AddScore(10);
        }

        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}