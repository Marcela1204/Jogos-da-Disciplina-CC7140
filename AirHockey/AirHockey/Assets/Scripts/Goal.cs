using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isTopGoal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            if (isTopGoal)
            {
                GameManager.instance.AddPointBottom();
            }
            else
            {
                GameManager.instance.AddPointTop();
            }

            GameManager.instance.ResetPuck();
        }
    }
}
