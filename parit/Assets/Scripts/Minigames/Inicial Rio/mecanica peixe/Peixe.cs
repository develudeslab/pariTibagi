using UnityEngine;

public class Peixe : MonoBehaviour
{
    public float velocidade = 1;
    void Update()
    {
        velocidade += Time.deltaTime;
        transform.Translate(Vector3.down * velocidade * Time.unscaledDeltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mao"))
        {
            Destroy(gameObject);
            Debug.Log("Colidiu com a area");
        }
    }

}
