using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{

    public string NomeCena;
    public AudioSource efeito;

    private void Start()
    {
        GetComponent<AudioSource>();
    }

    public void Trocar()
    {
        SceneManager.LoadScene(NomeCena);
        efeito.Play();
    }
}
