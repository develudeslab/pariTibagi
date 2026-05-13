using UnityEngine;

public class PegarTaquara : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Taquara"))
        {
            Destroy(collision.gameObject);     
        }
    }
}
