using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;              // 👈 declaração
    public float speed = 10f;    // 👈 velocidade da paddle

    Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // 👈 inicializa aqui
        originalScale = transform.localScale;
    }

    public void ActivatePowerUp(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ExpandPaddle(duration));
    }

    IEnumerator ExpandPaddle(float duration)
    {
        transform.localScale = new Vector3(
            originalScale.x * 1.5f,
            originalScale.y,
            originalScale.z
        );

        yield return new WaitForSeconds(duration);

        transform.localScale = originalScale;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, 0f);
    }
}