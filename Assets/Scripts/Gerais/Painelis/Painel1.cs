using UnityEngine;
using UnityEngine.UI;

public class Painel1: MonoBehaviour
{
    public GameObject painel;
    public AudioSource UI;
    void Start()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = false;
        GetComponent<AudioSource>();
    }
    public void Ativar()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = true;
        UI.Play();
        painel.SetActive(false);
    }
}
