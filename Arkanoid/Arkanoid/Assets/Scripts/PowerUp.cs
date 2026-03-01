using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float duration = 5f;

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
            Paddle paddle = collision.GetComponent<Paddle>();

            if (paddle != null)
            {
                paddle.ActivatePowerUp(duration);
            }

            Destroy(gameObject);
        }
    }
}