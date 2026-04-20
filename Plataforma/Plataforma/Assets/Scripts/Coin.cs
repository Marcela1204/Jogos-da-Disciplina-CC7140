using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Configuração")]
    public int points = 10;
    
    private bool collected = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Algo tocou a moeda: {other.gameObject.name} - Tag: {other.tag}");
        
        // Verifica se foi o player que tocou
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            Debug.Log("MOEDA COLETADA!");
            
            // Método 1: Adiciona pontos via PlayerController
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddScore(points);
                Debug.Log($"Pontos adicionados: {points}");
            }
            else
            {
                Debug.LogError("PlayerController não encontrado no Player!");
            }
            
            // Método 2: Notifica o GameManager (opcional, só se quiser contar moedas separadamente)
            if (GameManager.instance != null)
            {
                GameManager.instance.CoinCollected();
                Debug.Log("GameManager notificado!");
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado!");
            }
            
            // Destroi a moeda (apenas uma vez!)
            Destroy(gameObject);
        }
    }
}