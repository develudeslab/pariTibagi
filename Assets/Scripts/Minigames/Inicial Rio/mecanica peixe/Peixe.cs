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
    public Transform OrigemPeixe;
    private bool aguardando;
    public TextMeshProUGUI textoAcerto;
    public TextMeshProUGUI textoErro;

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
        if (aguardando)
            return;

        velocidade += Time.unscaledDeltaTime;
        transform.Translate(Vector3.down * velocidade * Time.unscaledDeltaTime);

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

    IEnumerator Esperar()
    {
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        Minigame.SetActive(false);
        Player.SetActive(true);
        aguardando = false;
        ResetPeixe();
    }
}