using UnityEngine;

public class MoverEntrePontos : MonoBehaviour
{
    public Transform local;
    public Transform origem;
    public float velocidade = 2f;

    private Transform destino;

    void Start()
    {
        destino = origem;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino.position) < 0.01f)
        {
            if (destino == local)
            {
                destino = origem;
            }
            else
            {
                destino = local;
            }
        }
    }
}