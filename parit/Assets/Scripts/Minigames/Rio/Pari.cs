using UnityEngine;
using UnityEngine.SceneManagement;

public class Pari : MonoBehaviour
{
    public int VidaDoPari = 3;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Pedaço"))
        {
            VidaDoPari--;
            Debug.Log(VidaDoPari);
            if(VidaDoPari <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
