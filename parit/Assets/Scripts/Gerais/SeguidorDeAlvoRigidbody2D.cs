using UnityEngine;

/// <summary>
/// Faz o objeto seguir a posição do toque usando Rigidbody2D.
/// 
/// Como funciona:
/// - Quando o toque/clique começa, o script passa a acompanhar a posição atual do input.
/// - Enquanto o toque estiver acontecendo, o destino é atualizado continuamente.
/// - O movimento é feito no FixedUpdate(), usando o Rigidbody2D,
///   o que é mais apropriado para objetos que participam da física.
/// 
/// Requisitos para funcionar corretamente:
/// - O objeto deve ter um Rigidbody2D.
/// - Deve existir um InputHandler na cena.
/// - A câmera principal deve estar marcada como MainCamera.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class SeguidorDeAlvoRigidbody2D : MonoBehaviour
{
    [Header("Configurações de Movimento")]

    [SerializeField]
    [Tooltip("Velocidade com que o objeto se move até o destino.")]
    private float velocidade = 5f;

    // Referência para a câmera principal da cena.
    private Camera _cam;

    // Referência para o script que centraliza a leitura do input.
    private InputHandler _input;

    // Referência para o Rigidbody2D do objeto.
    private Rigidbody2D _rb;

    // Posição de destino em coordenadas do mundo.
    private Vector2 _destino;

    // Indica se o jogador está pressionando/tocando a tela neste momento.
    private bool _pressionando;

    /// <summary>
    /// Awake é chamado antes do jogo começar.
    /// Aqui pegamos as referências necessárias.
    /// </summary>
    private void Awake()
    {
        _cam = Camera.main;
        _input = FindFirstObjectByType<InputHandler>();
        _rb = GetComponent<Rigidbody2D>();

        // Começa com o destino na posição inicial do próprio objeto.
        _destino = _rb.position;
    }

    /// <summary>
    /// OnEnable é chamado quando o objeto/script é ativado.
    /// Aqui nos inscrevemos nos eventos do InputHandler.
    /// </summary>
    private void OnEnable()
    {
        InputHandler.OnContatoIniciado += AoIniciarContato;
        InputHandler.OnContatoFinalizado += AoFinalizarContato;
    }

    /// <summary>
    /// OnDisable é chamado quando o objeto/script é desativado.
    /// Aqui removemos a inscrição dos eventos para evitar erros e comportamentos duplicados.
    /// </summary>
    private void OnDisable()
    {
        InputHandler.OnContatoIniciado -= AoIniciarContato;
        InputHandler.OnContatoFinalizado -= AoFinalizarContato;
    }

    /// <summary>
    /// Método chamado quando o toque/clique começa.
    /// </summary>
    private void AoIniciarContato()
    {
        _pressionando = true;
    }

    /// <summary>
    /// Método chamado quando o toque/clique termina.
    /// </summary>
    private void AoFinalizarContato()
    {
        _pressionando = false;
    }

    /// <summary>
    /// Update roda a cada frame.
    /// 
    /// Aqui usamos apenas para ler a posição atual do input
    /// e atualizar o ponto de destino.
    /// </summary>
    private void Update()
    {
        // Só atualiza o destino se o jogador estiver pressionando
        // e se o InputHandler existir.
        if (_pressionando && _input != null && _cam != null)
        {
            // Posição do toque/clique na tela (pixels).
            Vector2 posicaoTela = _input.PosicaoInput;

            // Converte a posição da tela para coordenadas do mundo.
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
    /// É o lugar ideal para movimentação com Rigidbody2D,
    /// pois mantém melhor compatibilidade com a física.
    /// </summary>
    private void FixedUpdate()
    {
        // Move o objeto gradualmente até o destino.
        // MoveTowards anda em direção ao alvo com velocidade constante.
        Vector2 novaPosicao = Vector2.MoveTowards(
            _rb.position,                  // posição atual
            _destino,                     // posição alvo
            velocidade * Time.fixedDeltaTime
        );

        Debug.Log(_destino-_rb.position);
        GetComponent<PlayerAnimation>().Animacao((_destino -  _rb.position).normalized);

        // Move o Rigidbody2D para a nova posição calculada.
        _rb.MovePosition(novaPosicao);
    }
}