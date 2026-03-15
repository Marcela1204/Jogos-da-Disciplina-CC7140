using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
{
    if(col.CompareTag("Alien"))
    {
        Alien alien = col.GetComponent<Alien>();

        if(alien != null)
        {
            alien.Die();
        }

        Destroy(gameObject);
    }
}
}