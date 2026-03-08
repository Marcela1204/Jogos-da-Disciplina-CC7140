using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public GameObject[] lifeIcons;

    public TMP_Text scoreText;

    public int lives = 3;

    void Awake()
    {
        instance = this;
        UpdateScore();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();

        CheckWin();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void LoseLife()
    {
        lives--;

        if(lives >= 0 && lives < lifeIcons.Length)
        {
            lifeIcons[lives].SetActive(false);
        }

        if(lives <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    void CheckWin()
    {
        if(score >= 560)
        {
            SceneManager.LoadScene("Win");
        }

        if(FindObjectsOfType<Alien>().Length == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}