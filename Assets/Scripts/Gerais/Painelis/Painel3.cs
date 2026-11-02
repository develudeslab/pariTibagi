using UnityEngine;
using UnityEngine.UI;

public class Painel3 : MonoBehaviour
{
    public GameObject painel;
    public AudioSource UI;
    void Start()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = false;
        GetComponentInChildren<Spawner>().enabled = false;
    }
    // danm
    public void Ativar()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = true;
        GetComponentInChildren<Spawner>().enabled = true;
        painel.SetActive(false);
        UI.Play();
    }
}
