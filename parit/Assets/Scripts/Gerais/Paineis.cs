using UnityEngine;
using UnityEngine.UI;

public class Paineis : MonoBehaviour
{
    public GameObject botao;
    public GameObject painel;
    public GameObject texto;
    void Start()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = false;
        GetComponentInChildren<Fome>().enabled = false;
        GetComponentInChildren<Spawner>().enabled = false;
    }
    public void Ativar()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = true;
        GetComponentInChildren<Fome>().enabled = true;
        GetComponentInChildren<Spawner>().enabled = true;
        painel.SetActive(false);
        botao.SetActive(false);
        texto.SetActive(false);
    }
}
