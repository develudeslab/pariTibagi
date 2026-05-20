using UnityEngine;
using UnityEngine.SceneManagement;

public class PegarTaquara : MonoBehaviour
{
    public int taquara;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Taquara"))
        {
            //Destroy(collision.gameObject);
            taquara++;
            if(taquara >= 10)
            {
                SceneManager.LoadScene("Fase2");
            }
        }
    }
}
