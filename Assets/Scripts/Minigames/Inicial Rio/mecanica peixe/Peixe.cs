using TMPro;
using System;
using UnityEngine;
using System.Collections;

public class Peixe : MonoBehaviour
{
    public float velocidade = 5;
    public float limiteY = -5f;
    public static int peixes;
    public GameObject Minigame;
    public GameObject Player;
    public GameObject BotaoMenu;
    public Transform OrigemPeixe;
    private bool aguardando;
    public TextMeshProUGUI textoAcerto;
    public TextMeshProUGUI textoErro;
    public TextMeshProUGUI Textpeixe;

    void Start()
    {
        ResetPeixe();
        velocidade = 5f;
   
    }

    private void OnEnable()
    {
        ResetPeixe();
    }

    void Update()
    {
        AtualizarUI();
        if (aguardando)
            return;

        velocidade += Time.unscaledDeltaTime;
        Vector3 posicao = transform.position;
        posicao.y -= velocidade * Time.unscaledDeltaTime;
        transform.position = posicao;
        if (transform.position.y <= limiteY)
        {
            velocidade = 0f;
            textoErro.gameObject.SetActive(true);
            aguardando = true;
            StartCoroutine(Esperar());
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mao") && !aguardando)
        {
            peixes++;
            velocidade = 0f;
            textoAcerto.gameObject.SetActive(true);
            aguardando = true;
            StartCoroutine(Esperar());
        }
    }

    public void ResetPeixe()
    {
        if (OrigemPeixe == null)
            return;

        transform.position = OrigemPeixe.position;
        velocidade = 5f;
        textoAcerto.gameObject.SetActive(false);
        textoErro.gameObject.SetActive(false);
    }

    public void AtualizarUI()
    {
        if (Textpeixe != null)
        {
            Textpeixe.text = peixes.ToString();
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        Minigame.SetActive(false);
        Player.SetActive(true);
        BotaoMenu.SetActive(true);
        aguardando = false;
        ResetPeixe();
    }
}