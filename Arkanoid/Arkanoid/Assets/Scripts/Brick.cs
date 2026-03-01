using UnityEngine;

public class Brick : MonoBehaviour
{
    public float chance = 0.5f; // 50%
    public Sprite powerUpSprite; // você vai colocar no inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (Random.value < chance)
            {
                CreatePowerUp();
            }

            Destroy(gameObject);
            GameManager.instance.AddScore(10);
            GameManager.instance.BrickDestroyed();
        }
    }

    void CreatePowerUp()
    {
        GameObject powerUp = new GameObject("PowerUp");

        powerUp.transform.position = transform.position;

        SpriteRenderer sr = powerUp.AddComponent<SpriteRenderer>();
        sr.sprite = powerUpSprite;
        sr.sortingOrder = 5;

        CircleCollider2D col = powerUp.AddComponent<CircleCollider2D>();
        col.isTrigger = true;

        powerUp.AddComponent<PowerUp>(); 
    }
}