using UnityEngine;

public class AlienGroupController : MonoBehaviour
{
    public float speed = 2f;

    private int direction = 1;

    public float leftLimit = -7f;
    public float rightLimit = 7f;

    public GameObject alienMissile;

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if(transform.position.x > rightLimit || transform.position.x < leftLimit)
        {
            direction *= -1;

            transform.position += Vector3.down * 0.5f;
        }
    }

    void Start()
    {
        InvokeRepeating("AlienShoot", 2f, 2f);
    }

    void AlienShoot()
    {
        Alien[] aliens = FindObjectsOfType<Alien>();

        if(aliens.Length == 0) return;

        Alien shooter = aliens[Random.Range(0, aliens.Length)];

        Instantiate(alienMissile, shooter.transform.position, Quaternion.identity);
    }
}