using UnityEngine;
using System.Collections.Generic;

public class Cair : MonoBehaviour
{
    public float velocidade = 1f;
    private int Chance;
    void Update()
    {
        velocidade += Time.deltaTime;
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);
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
            Chance = Random.Range(1, 10);
            if (Chance >= 5)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("O peixe desviou, otario");
            }
        }
    }
}