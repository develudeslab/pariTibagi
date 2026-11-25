using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{

    public string NomeCena;
    public AudioSource efeito;
    [SerializeField] Animator Fade;

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
