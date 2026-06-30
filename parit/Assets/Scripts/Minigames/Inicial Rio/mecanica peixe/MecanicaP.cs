using UnityEngine;
using System.Collections;

public class MecanicaP : MonoBehaviour
{
    public Transform local;
    public Transform origem;
    public float velocidade = 2f;

    private Transform destino;
    private bool Movendo;

    void Start()
    {
        destino = local;
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
    }

    private void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.unscaledDeltaTime);

        if (Vector3.Distance(transform.position, destino.position) < 0.01f)
        {
            transform.position = destino.position;
            Movendo = false;
        }
    }
}