using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class MecanicaP : MonoBehaviour
{
    public Transform local;
    public Transform origem;
    private Transform destino;
    public float velocidade = 2f;
    private bool Movendo;

    void Start()
    {
        destino = local;
    }

    void Update()
    {
        bool clicou = false;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            clicou = true;
        }

        if (!clicou && Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            clicou = true;
        }

        if (clicou)
        {
            Pegar();
        }

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

    private void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.unscaledDeltaTime);
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(2f);
    }
}