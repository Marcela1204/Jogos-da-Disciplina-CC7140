using UnityEngine;
using System.Collections;

public class PaddleMovement2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;

    public float minX = -3.6f;   // limite esquerdo
    public float maxX = 3.6f;    // limite direito

    Vector3 originalScale;
    private Coroutine powerUpRoutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        // mantém movimento físico
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // limita a posição
        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.position = pos;
    }

    public void ActivateSpeedPowerUp(float multiplier, float duration)
    {
        if (powerUpRoutine != null)
            StopCoroutine(powerUpRoutine);

        powerUpRoutine = StartCoroutine(SpeedBoost(multiplier, duration));
    }

    IEnumerator SpeedBoost(float multiplier, float duration)
    {
        speed *= multiplier;
        yield return new WaitForSeconds(duration);
        speed /= multiplier;
        powerUpRoutine = null;
    }

    // seu power-up antigo (caso ainda use)
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
}   