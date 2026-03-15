using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        score += value;

        scoreText.text = "Score: " + score;

        if(score >= 100)
        {
            SceneManager.LoadScene("Win");
        }
    }
}