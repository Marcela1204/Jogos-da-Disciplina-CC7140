using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text coinText;
    
    [Header("Configurações da Fase")]
    public int totalItemsToCollect = 5; // Quantos itens precisa coletar para ganhar
    public string nextSceneName = "Fase2"; // Próxima fase (se houver)
    
    private int currentScore = 0;
    private int currentHealth = 3;
    private bool gameOver = false;

    [Header("Sistema de Moedas")]
    public int totalCoins = 5;      // Total de moedas na fase
    private int coinsCollected = 0;  // Moedas coletadas

    void Awake()
    {
        // Singleton pattern - garante que só existe um GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantém entre cenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateScoreUI(currentScore);
        UpdateHealthUI(currentHealth);
    }

    // Atualiza o texto da pontuação
    public void UpdateScoreUI(int score)
    {
        currentScore = score;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        
        // Verifica se venceu
        if (currentScore >= 50)  // 5 moedas de 10 pontos cada
        {
            GameManager.instance.GameOver(true);  // Vitória!
        }
    }

    // Atualiza o texto das vidas
    public void UpdateHealthUI(int health)
    {
        currentHealth = health;
        if (healthText != null)
            healthText.text = "Health: " + health;  // Com emoji
        
        if (currentHealth <= 0 && !gameOver)
        {
            GameOver(false);
        }
    }

    // Adiciona pontos (chamado pelos itens)
    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreUI(currentScore);
    }

    // Chamado quando uma moeda é coletada
    public void CoinCollected()
    {
        coinsCollected++;
        Debug.Log($"Moedas coletadas: {coinsCollected}/{totalCoins}");
        
        if (coinText != null)
            coinText.text = "Moedas: " + coinsCollected + "/" + totalCoins;
        
        // Verifica vitória APENAS pelo número de moedas
        if (coinsCollected >= totalCoins && !gameOver)
        {
            Debug.Log("Todas as moedas coletadas! VITÓRIA!");
            GameOver(true);
        }
    }

    // Remove vida (chamado pelos inimigos)
    public void RemoveHealth(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI(currentHealth);
    }

    // Fim de jogo
    public void GameOver(bool victory)
    {
        if (gameOver) return;
        gameOver = true;
        
        if (victory)
        {
            Debug.Log("VITÓRIA! Você coletou todos os itens!");
            SceneManager.LoadScene("Fim");
        }
        else
        {
            Debug.Log("DERROTA! Suas vidas acabaram!");
            SceneManager.LoadScene("Fim");
        }
    }

    // Reiniciar o jogo (chamado pelos botões)
    public void RestartGame()
    {
        gameOver = false;
        currentScore = 0;
        currentHealth = 3;
        SceneManager.LoadScene("Menu");
    }

    // Carregar próxima fase
    public void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}