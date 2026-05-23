using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PegarTaquara : MonoBehaviour
{
    public int taquara;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Taquara"))
        {
            taquara++;
            Debug.Log(taquara);
            StartCoroutine(esperar(collision.gameObject));
            if(taquara >= 10)
            {
                SceneManager.LoadScene("MontarPari");
            }
        }
    }

    IEnumerator esperar(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }
}
