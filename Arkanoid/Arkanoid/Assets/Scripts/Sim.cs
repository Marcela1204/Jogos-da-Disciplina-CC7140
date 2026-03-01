using UnityEngine;
using UnityEngine.SceneManagement;

public class Sim : MonoBehaviour
{
    public void Voltar()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Rules");
    }

    public void Sair()
    {
        // Encerra o jogo
        SceneManager.LoadScene("Menu");
    }
}
