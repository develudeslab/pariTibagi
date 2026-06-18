using UnityEngine;
using System.Collections;

public class MecanicaP : MonoBehaviour
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

    }

    public void Pegar()
    {
            transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.position, destino.position) < 0.01f)
            {
                if (destino == local)
                {
                    StartCoroutine(Esperar());
                    destino = origem;
                }
                else
                {
                    destino = local;
                }
            }
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("ta esperando");
    }
}