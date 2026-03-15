using UnityEngine;

public class AlienMissile : MonoBehaviour
{
    public float speed = 6f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoseLife();

            Destroy(gameObject); // destrói míssil
        }
    }
}