using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    void Update()
    {
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(moveX, moveY) * speed * Time.deltaTime);

        // limitar posição
        transform.Translate(new Vector2(moveX, moveY) * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}