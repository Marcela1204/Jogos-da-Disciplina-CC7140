using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scoreTop;
    public int scoreBottom;

    public TextMeshProUGUI scoreTopText;
    public TextMeshProUGUI scoreBottomText;

    public Transform puck;
    private Rigidbody2D puckRb;

    public AudioSource goalSound;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        puckRb = puck.GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    public void AddPointTop()
    {
        scoreTop++;
        goalSound.Play();
        UpdateUI();
    }

    public void AddPointBottom()
    {
        scoreBottom++;
        goalSound.Play();
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreTopText.text = scoreTop.ToString();
        scoreBottomText.text = scoreBottom.ToString();
    }

    public void ResetPuck()
    {
        puckRb.linearVelocity = Vector2.zero;
        puck.position = Vector2.zero;
    }
}
