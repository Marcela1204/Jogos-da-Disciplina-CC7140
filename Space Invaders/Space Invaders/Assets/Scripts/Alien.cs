using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{
    public GameObject alienMissile;

    public int scoreValue = 10;

    public void Die()
    {
        GameManager.instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            GameManager.instance.LoseLife();
        }

        if(col.CompareTag("LoseZone"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}