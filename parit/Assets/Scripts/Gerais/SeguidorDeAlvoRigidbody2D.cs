using UnityEngine;

/// <summary>
/// Faz o objeto seguir a posi��o do toque usando Rigidbody2D.
/// 
/// Como funciona:
/// - Quando o toque/clique come�a, o script passa a acompanhar a posi��o atual do input.
/// - Enquanto o toque estiver acontecendo, o destino � atualizado continuamente.
/// - O movimento � feito no FixedUpdate(), usando o Rigidbody2D,
///   o que � mais apropriado para objetos que participam da f�sica.
/// 
/// Requisitos para funcionar corretamente:
/// - O objeto deve ter um Rigidbody2D.
/// - Deve existir um InputHandler na cena.
/// - A c�mera principal deve estar marcada como MainCamera.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class SeguidorDeAlvoRigidbody2D : MonoBehaviour
{
    [Header("Configura��es de Movimento")]

    [SerializeField]
    [Tooltip("Velocidade com que o objeto se move at� o destino.")]
    private float velocidade = 5f;

    // Refer�ncia para a c�mera principal da cena.
    private Camera _cam;

    // Refer�ncia para o script que centraliza a leitura do input.
    private InputHandler _input;

    // Refer�ncia para o Rigidbody2D do objeto.
    private Rigidbody2D _rb;

    // Posi��o de destino em coordenadas do mundo.
    private Vector2 _destino;

    // Indica se o jogador est� pressionando/tocando a tela neste momento.
    private bool _pressionando;

    /// <summary>
    /// Awake � chamado antes do jogo come�ar.
    /// Aqui pegamos as refer�ncias necess�rias.
    /// </summary>
    private void Awake()
    {
        _cam = Camera.main;
        _input = FindFirstObjectByType<InputHandler>();
        _rb = GetComponent<Rigidbody2D>();

        // Come�a com o destino na posi��o inicial do pr�prio objeto.
        _destino = _rb.position;
    }

    /// <summary>
    /// OnEnable � chamado quando o objeto/script � ativado.
    /// Aqui nos inscrevemos nos eventos do InputHandler.
    /// </summary>
    private void OnEnable()
    {
        InputHandler.OnContatoIniciado += AoIniciarContato;
        InputHandler.OnContatoFinalizado += AoFinalizarContato;
    }

    /// <summary>
    /// OnDisable � chamado quando o objeto/script � desativado.
    /// Aqui removemos a inscri��o dos eventos para evitar erros e comportamentos duplicados.
    /// </summary>
    private void OnDisable()
    {
        InputHandler.OnContatoIniciado -= AoIniciarContato;
        InputHandler.OnContatoFinalizado -= AoFinalizarContato;
    }

    /// <summary>
    /// M�todo chamado quando o toque/clique come�a.
    /// </summary>
    private void AoIniciarContato()
    {
        _pressionando = true;
    }

    /// <summary>
    /// M�todo chamado quando o toque/clique termina.
    /// </summary>
    private void AoFinalizarContato()
    {
        _pressionando = false;
    }

    /// <summary>
    /// Update roda a cada frame.
    /// 
    /// Aqui usamos apenas para ler a posi��o atual do input
    /// e atualizar o ponto de destino.
    /// </summary>
    private void Update()
    {
        // S� atualiza o destino se o jogador estiver pressionando
        // e se o InputHandler existir.
        if (_pressionando && _input != null && _cam != null)
        {
            // Posi��o do toque/clique na tela (pixels).
            Vector2 posicaoTela = _input.PosicaoInput;

            // Converte a posi��o da tela para coordenadas do mundo.
            Vector3 posicaoMundo = _cam.ScreenToWorldPoint(
                new Vector3(posicaoTela.x, posicaoTela.y, 0f)
            );

            // Como o jogo parece ser 2D, guardamos apenas X e Y.
            _destino = new Vector2(posicaoMundo.x, posicaoMundo.y);
        }
    }

    /// <summary>
    /// FixedUpdate roda em intervalos fixos de tempo.
    /// 
    /// � o lugar ideal para movimenta��o com Rigidbody2D,
    /// pois mant�m melhor compatibilidade com a f�sica.
    /// </summary>
    private void FixedUpdate()
    {
        // Move o objeto gradualmente at� o destino.
        // MoveTowards anda em dire��o ao alvo com velocidade constante.
        Vector2 novaPosicao = Vector2.MoveTowards(
            _rb.position,                  // posi��o atual
            _destino,                     // posi��o alvo
            velocidade * Time.fixedDeltaTime
        );

        //Debug.Log(_destino-_rb.position);
        GetComponent<PlayerAnimation>().Animacao((_destino -  _rb.position).normalized);

        // Move o Rigidbody2D para a nova posi��o calculada.
        _rb.MovePosition(novaPosicao);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Rio"))
        {
            velocidade = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rio"))
        {
            velocidade = 7;
        }
    }
}