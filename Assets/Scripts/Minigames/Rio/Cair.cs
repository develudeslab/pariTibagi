using UnityEngine;
using System.Collections.Generic;

public class Cair : MonoBehaviour
{
    public float velocidade = 1f;
    public float Tempo = 5f;
    
    void Update()
    {
        velocidade += Time.deltaTime;
        Tempo -= Time.deltaTime;
        if (Tempo <= 0f)
        {
            Destroy(gameObject);
        }

        Vector3 posicao = transform.position;
        posicao.y -= velocidade * Time.deltaTime;
        transform.position = posicao;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pedra"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Pari"))
        {
            Destroy(gameObject);
        }
         if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}