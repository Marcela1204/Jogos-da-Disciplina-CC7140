using UnityEngine;

public class SlowPowerUp : MonoBehaviour
{
    public float slowFactor = 0.5f;   // metade da velocidade
    public float slowDuration = 3f;   // 3 segundos

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(SlowTime());
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator SlowTime()
    {
        Time.timeScale = slowFactor;

        yield return new WaitForSecondsRealtime(slowDuration);

        Time.timeScale = 1f;
    }
}