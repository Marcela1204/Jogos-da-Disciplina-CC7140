using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public Transform puck;
    public float speed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 targetPos = new Vector2(puck.position.x, rb.position.y);

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            targetPos,
            speed * Time.fixedDeltaTime
        );

        // Limite do campo superior
        newPos.y = Mathf.Clamp(newPos.y, 0f, 4.5f);

        rb.MovePosition(newPos);
    }
}
