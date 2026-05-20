using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class Paineis : MonoBehaviour
{
    public GameObject painel;
    void Start()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = false;
        GetComponentInChildren<Fome>().enabled = false;
        GetComponentInChildren<Spawner>().enabled = false;
        GetComponentInChildren<MovimentoRio>().enabled = false;
    }
    public void Ativar()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = true;
        GetComponentInChildren<Fome>().enabled = true;
        GetComponentInChildren<Spawner>().enabled = true;
        GetComponentInChildren<MovimentoRio>() .enabled = true;
        painel.SetActive(false);
    }
}
