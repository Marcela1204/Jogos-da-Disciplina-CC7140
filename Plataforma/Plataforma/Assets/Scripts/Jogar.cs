using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("Intro");
    }
}
