using System;
using UnityEngine;
using UnityEngine.UI;

public class Personagens : MonoBehaviour
{
    [Serializable]
    public class DadosPersonagem
    {
        public string nome;
        public Sprite sprite;
    }

    [Header("Personagens")]
    [SerializeField] private DadosPersonagem[] personagens;

    [Header("UI")]
    [SerializeField] private Button botaoAnterior;
    [SerializeField] private Button botaoProximo;
    [SerializeField] private Image imagemPreview;
    [SerializeField] private Text nomeSelecionado;

    [Header("Seleção")]
    [SerializeField] private int indiceSelecionado;

    public SelecionarPersonagem selecionarPersonagem;

    public int IndiceSelecionado => indiceSelecionado;
    public DadosPersonagem PersonagemAtual => personagens != null && personagens.Length > 0 ? personagens[indiceSelecionado] : null;

    private void Start()
    {
        if (personagens != null && personagens.Length > 0)
            indiceSelecionado = Mathf.Clamp(indiceSelecionado, 0, personagens.Length - 1);

        RegistrarBotoes();
        AtualizarUI();
    }

    private void RegistrarBotoes()
    {
        if (botaoAnterior != null)
        {
            botaoAnterior.onClick.RemoveAllListeners();
            botaoAnterior.onClick.AddListener(() => MudarPersonagem(-1));
        }

        if (botaoProximo != null)
        {
            botaoProximo.onClick.RemoveAllListeners();
            botaoProximo.onClick.AddListener(() => MudarPersonagem(1));
        }
    }

    public void MudarPersonagem(int direcao)
    {
        if (personagens == null || personagens.Length == 0)
            return;

        indiceSelecionado = (indiceSelecionado + direcao + personagens.Length) % personagens.Length;
        AtualizarUI();
    }

    public void SelecionarPersonagem(int indice)
    {
        if (personagens == null || personagens.Length == 0)
            return;

        if (indice < 0 || indice >= personagens.Length)
            return;

        indiceSelecionado = indice;
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        if (personagens == null || personagens.Length == 0)
            return;

        indiceSelecionado = Mathf.Clamp(indiceSelecionado, 0, personagens.Length - 1);

        if (imagemPreview != null)
            imagemPreview.sprite = personagens[indiceSelecionado].sprite;

        if (nomeSelecionado != null)
            nomeSelecionado.text = personagens[indiceSelecionado].nome;
    }
}
