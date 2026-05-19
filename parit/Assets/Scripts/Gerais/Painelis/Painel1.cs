using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class Painel1: MonoBehaviour
{
    public GameObject painel;
    void Start()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = false;
    }
    public void Ativar()
    {
        GetComponentInChildren<SeguidorDeAlvoRigidbody2D>().enabled = true;
        painel.SetActive(false);
    }
}
