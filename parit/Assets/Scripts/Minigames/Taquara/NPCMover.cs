using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCMover : MonoBehaviour
{
    public float vel = 2f;
    
    [Header("Tempo que o caboco fica andando")]
    public float MinimoAndar = 1f;
    public float MaximoAndar = 3f;

    [Header("Mesma coisa só que pra parar")]
    public float PausaCurta = 0.5f;
    public float PausaLenta = 2f;

    public Transform origem;

    private Rigidbody2D rb;
    private Vector2 direcao;
    private bool ando;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    
        StartCoroutine(WanderRoutine());
        transform.position = origem.position;
    }

    void FixedUpdate()
    {
        if (ando)
        {
            rb.linearVelocity = direcao * vel;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    IEnumerator WanderRoutine()
    {
        transform.position = origem.position;
        while (true)
        {
            direcao = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            ando = true;
            float TempoAndar = Random.Range(MinimoAndar, MaximoAndar);
            yield return new WaitForSeconds(TempoAndar);
            ando = false;
            float TempoPausa = Random.Range(PausaCurta, PausaLenta);
            yield return new WaitForSeconds(TempoPausa);
        }
    }
}
