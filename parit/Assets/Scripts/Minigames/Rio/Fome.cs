using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fome : MonoBehaviour
{
    public Slider BarraFome;
    public float fomeMaxima = 100f;
    public float fomeAtual = 100f;
    public float velocidadeFome = 5f;
    void Start()
    {
        BarraFome.maxValue = fomeMaxima;
        BarraFome.value = fomeAtual;
    }

    void Update()
    {
        DescerFome();
    }

    void DescerFome()
    {
        fomeAtual -= velocidadeFome * Time.deltaTime;
        fomeAtual = Mathf.Clamp(fomeAtual, 0, fomeMaxima);
        BarraFome.value = fomeAtual;
        if (fomeAtual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Peixe"))
        {
            fomeAtual += 20f;
            fomeAtual = Mathf.Clamp(fomeAtual, 0, fomeMaxima);
            BarraFome.value = fomeAtual;
        }
    }
}