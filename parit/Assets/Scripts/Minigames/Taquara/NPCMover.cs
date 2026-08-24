using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class NpcMover : MonoBehaviour
{
    [Header("Velocidade de movimento")]
    [SerializeField] private float velocidade = 1.5f;

    [Header("Distância que pode andar")]
    [SerializeField] private float distanciaMaxima = 4f;

    [Header("Tempo maximo e mínimo andando")]
    [SerializeField] private float tempoMinimoAndando = 1f;
    [SerializeField] private float tempoMaximoAndando = 3f;

    [Header("Tempo maximo e mínimo parado")]
    [SerializeField] private float tempoMinimoParado = 1f;
    [SerializeField] private float tempoMaximoParado = 3f;

    private Vector3 origem;
    private Vector3 destino;
    private float tempoRestante;
    private bool estaAndando;
    private PlayerAnimation animacao;

    private void Start()
    {
        origem = transform.position;
        animacao = GetComponent<PlayerAnimation>();
        Parar();
    }

    private void Update()
    {
        tempoRestante -= Time.deltaTime;

        if (!estaAndando)
        {
            if (tempoRestante <= 0f)
            {
                EscolherDestino();
            }

            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            velocidade * Time.deltaTime);

        Vector3 direcao = destino - transform.position;
        animacao.Animacao(new Vector2(direcao.x, direcao.y));

        if (transform.position == destino || tempoRestante <= 0f)
        {
            Parar();
        }
    }

    private void EscolherDestino()
    {
        Vector3 eixo = Random.value < 0.5f ? Vector3.right : Vector3.up;
        float sentido = Random.value < 0.5f ? -1f : 1f;
        float distancia = Random.Range(0.5f, distanciaMaxima);
        Vector3 deslocamento = eixo * sentido * distancia;
        destino = origem + deslocamento;
        tempoRestante = Random.Range(tempoMinimoAndando, tempoMaximoAndando);
        estaAndando = true;
        animacao.Animacao(new Vector2(deslocamento.x, deslocamento.y));
    }

    private void Parar()
    {
        estaAndando = false;
        tempoRestante = Random.Range(tempoMinimoParado, tempoMaximoParado);

        if (animacao != null)
        {
            animacao.Animacao(Vector2.zero);
        }
    }
}
