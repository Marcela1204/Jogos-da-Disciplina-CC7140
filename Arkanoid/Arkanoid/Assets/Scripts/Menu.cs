using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jogar()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Rules");
    }
}
