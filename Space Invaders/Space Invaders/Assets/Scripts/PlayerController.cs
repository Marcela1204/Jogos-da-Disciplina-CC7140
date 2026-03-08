using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject missilePrefab;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missilePrefab, transform.position, Quaternion.identity);
        }
    }
}