using UnityEngine;

public class Painel : MonoBehaviour
{
    public GameObject painel;
    public AudioSource UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void Ativar()
    {
        Time.timeScale = 1;
        painel.SetActive(false);
        UI.Play();
    }
}
