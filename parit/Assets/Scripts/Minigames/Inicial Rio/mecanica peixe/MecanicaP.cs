using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

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
        if (Vector3.Distance(transform.position, destino.position) < 0.01f)
        {
            StartCoroutine(esperar());
            destino = origem;
        }
    }

    public void OnContatoPrimario()
    {
        Pegar();
        Mover();
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