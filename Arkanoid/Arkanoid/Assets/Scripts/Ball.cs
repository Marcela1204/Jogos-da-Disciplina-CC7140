using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 6f;

    private Rigidbody2D rb;
    private bool launched = false;
    private Transform paddle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle").transform;
    }

    void Update()
    {
        // Antes de lançar: bola presa ao paddle
        if (!launched)
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = paddle.position + Vector3.up * 0.6f;

            // Lançar com SPACE
            if (Input.GetKeyDown(KeyCode.Space))
            {
                launched = true;
                rb.linearVelocity = Vector2.up * speed;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ajusta o ângulo ao bater no paddle (SEM matar o quique)
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitPoint =
                transform.position.x - collision.transform.position.x;

            Vector2 direction = new Vector2(hitPoint, 1).normalized;
            rb.linearVelocity = direction * speed;
        }
    }
}