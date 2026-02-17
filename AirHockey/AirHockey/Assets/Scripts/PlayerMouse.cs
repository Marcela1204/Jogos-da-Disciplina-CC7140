using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(mousePos.x, mousePos.y);

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            targetPos,
            speed * Time.fixedDeltaTime
        );

        // Limite: não pode passar do meio da mesa
        newPos.y = Mathf.Clamp(newPos.y, -4.5f, 0f);

        rb.MovePosition(newPos);
    }
}
