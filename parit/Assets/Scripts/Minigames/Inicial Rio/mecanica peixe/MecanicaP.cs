using UnityEngine;
using System.Collections;

public class MecanicaP : MonoBehaviour
{
    public Transform local;
    public Transform origem;
    public float velocidade = 2f;

    public GameObject AreaPegar;

    private Transform destino;
    private bool Movendo;

    void Start()
    {
        destino = local;
        AreaPegar.SetActive(false);
    }

    void Update()
    {
        if (Movendo)
            Mover();
    }

    public void Pegar()
    {
        destino = local;
        Movendo = true;
        if (Vector3.Distance(transform.position, destino.position) < 0.01f)
        {
            AreaPegar.SetActive(true);
            StartCoroutine(esperar());
            destino = origem;
        }

    }

    private void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.unscaledDeltaTime);
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(2f);
    }
}