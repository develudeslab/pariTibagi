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
    }
    public void Ativar()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = true;
        painel.SetActive(false);
        botao.SetActive(false);
        texto.SetActive(false);
    }
}
