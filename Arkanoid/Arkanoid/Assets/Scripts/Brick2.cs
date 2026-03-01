using UnityEngine;

public class Brick2 : MonoBehaviour
{
    public int hits = 2;              // quantidade de hits do bloco
    public float chance = 0.5f;       // chance de dropar power-up
    public Sprite powerUpSprite;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;

        hits--;

        if (hits <= 0)
        {
            if (Random.value < chance)
            {
                CreatePowerUp();
            }

            Destroy(gameObject);
            GameManager2.instance.AddScore(10);
            GameManager2.instance.BrickDestroyed();
        }
        else
        {
            // feedback visual simples (escurece o bloco)
            sr.color *= 0.8f;
        }
    }

    void CreatePowerUp()
    {
        GameObject powerUp = new GameObject("PowerUpSpeed");

        powerUp.transform.position = transform.position;

        SpriteRenderer sr = powerUp.AddComponent<SpriteRenderer>();
        sr.sprite = powerUpSprite;
        sr.sortingOrder = 5;

        CircleCollider2D col = powerUp.AddComponent<CircleCollider2D>();
        col.isTrigger = true;

        Rigidbody2D rb = powerUp.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1f;

        powerUp.AddComponent<PowerUp>();
    }
}