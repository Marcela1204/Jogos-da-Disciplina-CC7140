using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configuração")]
    public float speed = 1f;
    public int damage = 1;
    public float lifetime = 3f;  // Destroi após 3 segundos
    
    private Vector2 direction;
    
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        
        // Vira a bala na direção correta (opcional)
        if (dir.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (dir.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        
        Destroy(gameObject, lifetime);
    }
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Debug.Log("Player atingido pela bala!");
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            // Bateu no chão, some
            Destroy(gameObject);
        }
    }
}