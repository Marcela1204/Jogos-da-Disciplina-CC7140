using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configuração de Tiro")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public int damageOnTouch = 1;
    
    [Header("Direção do Tiro")]
    public bool shootRight = true;  // true = direita, false = esquerda
    
    private float shootTimer;
    private Vector2 shootDirection;
    public float bulletSpeed = 1.5f;
    
    void Start()
    {
        // Define a direção do tiro baseada na configuração
        if (shootRight)
            shootDirection = Vector2.right;
        else
            shootDirection = Vector2.left;
        
        shootTimer = shootInterval;
    }
    
    void Update()
    {
        // Timer para atirar
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }
    
    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            
            if (bulletScript != null)
            {
                bulletScript.SetDirection(shootDirection);
                Debug.Log($"Inimigo atirou para {(shootRight ? "DIREITA" : "ESQUERDA")}");
            }
        }
        else
        {
            Debug.LogWarning("BulletPrefab ou FirePoint não configurado no inimigo!");
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damageOnTouch);
                Debug.Log("Player encostou no inimigo!");
            }
        }
    }
}