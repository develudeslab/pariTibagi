using UnityEngine;

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

    private void Start()
    {
        origem = transform.position;
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

        if (transform.position == destino || tempoRestante <= 0f)
        {
            Parar();
        }
    }

    private void EscolherDestino()
    {
        Vector3 deslocamento = Random.insideUnitSphere * distanciaMaxima;
        destino = origem + deslocamento;
        tempoRestante = Random.Range(tempoMinimoAndando, tempoMaximoAndando);
        estaAndando = true;
    }

    private void Parar()
    {
        estaAndando = false;
        tempoRestante = Random.Range(tempoMinimoParado, tempoMaximoParado);
    }
}
