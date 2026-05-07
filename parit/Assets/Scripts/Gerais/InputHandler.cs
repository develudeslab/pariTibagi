using UnityEngine;
using UnityEngine.InputSystem;
using System; // Necessário para usar o Action (Eventos)

/// <summary>
/// Classe central que gerencia todas as entradas (inputs) do jogo.
/// Ela serve como uma ponte entre o hardware e a lógica dos objetos.
/// </summary>
public class InputHandler : MonoBehaviour
{
    // PROPRIEDADE: Permite que outros scripts leiam a posição do toque, 
    // mas apenas este script pode alterar o valor (private set).
    public Vector2 PosicaoInput { get; private set; }

    // EVENTOS ESTÁTICOS: Funcionam como canais de rádio. 
    // Qualquer objeto na cena pode "sintonizar" aqui para saber quando houve um toque.
    public static event Action OnContatoIniciado;
    public static event Action OnContatoFinalizado;

    // Referência para a classe que o Unity gerou automaticamente do Asset de Input.
    private ControlesDeToque controls;

    private void Awake()
    {
        // Instancia a classe de controles definida no passo 1 do guia.
        controls = new ControlesDeToque();

        // CONFIGURAÇÃO DOS CALLBACKS (Respostas do sistema):

        // 1. Posição: Quando o ponteiro se move (performed), guardamos a coordenada Vector2.
        controls.Toque.PosicaoPrimaria.performed += ctx => PosicaoInput = ctx.ReadValue<Vector2>();

        // 2. Cancelamento: Se o toque sumir, resetamos a posição para zero.
        controls.Toque.PosicaoPrimaria.canceled += ctx => PosicaoInput = Vector2.zero;

        // 3. Contato (Início): Quando o dedo encosta na tela (started), avisamos todos os ouvintes.
        controls.Toque.ContatoPrimario.started += _ => OnContatoIniciado?.Invoke();

        // 4. Contato (Fim): Quando o dedo levanta da tela (canceled), avisamos o fim do toque.
        controls.Toque.ContatoPrimario.canceled += _ => OnContatoFinalizado?.Invoke();
    }

    // É OBRIGATÓRIO habilitar o mapa de ações para que ele comece a escutar o hardware.
    private void OnEnable() => controls.Toque.Enable();

    // Desabilitamos ao sair para economizar bateria e evitar erros de memória.
    private void OnDisable() => controls.Toque.Disable();
}
