using UnityEngine;

/// <summary>
/// Move o objeto acompanhando a posição do dedo enquanto houver contato.
/// </summary>
public class ArrastarComEventos : MonoBehaviour
{
    private Camera _cam;
    private InputHandler _input;
    private bool _estaArrastando;

    void Awake()
    {
        _cam = Camera.main;
        // Busca o gerenciador central na cena para ler a posição.
        _input = FindFirstObjectByType<InputHandler>();
    }

    // INSCRIÇÃO: Ligamos este objeto aos eventos do rádio central.
    void OnEnable()
    {
        InputHandler.OnContatoIniciado += IniciarArrasto;
        InputHandler.OnContatoFinalizado += PararArrasto;
    }

    // DESINSCRIÇÃO: Sempre desligue os eventos ao desativar o objeto.
    void OnDisable()
    {
        InputHandler.OnContatoIniciado -= IniciarArrasto;
        InputHandler.OnContatoFinalizado -= PararArrasto;
    }

    private void IniciarArrasto() => _estaArrastando = true;
    private void PararArrasto() => _estaArrastando = false;

    void Update()
    {
        // Se o rádio avisou que o dedo está na tela, seguimos a posição.
        if (_estaArrastando && _input != null)
        {
            Vector2 screenPos = _input.PosicaoInput;

            // Converte pixels da tela para coordenadas do mundo 3D da Unity.
            Vector3 worldPos = _cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, _cam.nearClipPlane));
            worldPos.z = 0f; // Trava no plano 2D.

            transform.position = worldPos;
        }
    }
}
