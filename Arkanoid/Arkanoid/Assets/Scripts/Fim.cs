using UnityEngine;
using TMPro;

public class FimDeJogoUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", -1);
        Debug.Log("TELA FINAL | Score recebido = " + finalScore);

        scoreText.text = "Score: " + finalScore;
    }
}