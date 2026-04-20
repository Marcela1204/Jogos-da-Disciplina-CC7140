using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    
    [Header("Vidas e Pontos")]
    public int maxHealth = 3;
    private int currentHealth;
    
    [Header("Verificação de Chão")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;
    
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float moveInput;

    private int currentScore = 0;  // Pontuação atual
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        
        // Inicializa UI via GameManager
        if (GameManager.instance != null)
        {
            GameManager.instance.UpdateHealthUI(currentHealth);
            GameManager.instance.UpdateScoreUI(currentScore);
        }
        else
        {
            Debug.LogWarning("GameManager não encontrado na cena!");
        }
    }
    
    void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        
        // Movimento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        
        // Atualiza animação
        if (anim != null)
        {
            anim.SetFloat("MoveX", moveInput);
        }
        
        // Vira o sprite
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (GameManager.instance != null)
            GameManager.instance.UpdateHealthUI(currentHealth);
        
        StartCoroutine(DamageFlash());
        StartCoroutine(InvincibilityFrames());
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private System.Collections.IEnumerator InvincibilityFrames()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }
    
    private System.Collections.IEnumerator DamageFlash()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color originalColor = sr.color;
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = originalColor;
        }
    }
    
    void Die()
    {
        if (GameManager.instance != null)
            GameManager.instance.GameOver(false);
        else
            Debug.Log("Jogador morreu!");
    }
    
    public void AddScore(int points)
    {
        currentScore += points;
        Debug.Log($"Score: {currentScore}");
        
        // Atualiza UI
        if (GameManager.instance != null)
        {
            GameManager.instance.UpdateScoreUI(currentScore);
            
            // Verifica se coletou todas as moedas (5 moedas * 10 pontos = 50 pontos)
            // Ou você pode contar o número de moedas coletadas
            if (currentScore >= 50)  // 5 moedas de 10 pontos cada
            {
                GameManager.instance.GameOver(true);  // Vitória!
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}