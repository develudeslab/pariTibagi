using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{

    public string NomeCena;
    public void Trocar()
    {
        SceneManager.LoadScene(NomeCena);
    }
}
