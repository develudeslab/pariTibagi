using UnityEngine;
using System.Collections.Generic;

public class Cair : MonoBehaviour
{
    public float velocidade = 5f;
    public float spawnTime = 2f;
    void Update()
    {
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
            
    }
}