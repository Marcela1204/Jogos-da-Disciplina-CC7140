using UnityEngine;

public class PowerUp2 : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float duration = 5f;
    public float speedMultiplier = 1.5f; // NOVO

    void Update()
    {
        // Faz o power-up cair
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Se sair da tela, destrói
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            PaddleMovement2 paddle = collision.GetComponent<PaddleMovement2>();

            if (paddle != null)
            {
                paddle.ActivateSpeedPowerUp(speedMultiplier, duration);
            }

            Destroy(gameObject);
        }
    }
}