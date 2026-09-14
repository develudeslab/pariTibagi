using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class PegarTaquara : MonoBehaviour
{
    public int taquara;
    public AudioSource corte;
    public AudioSource taquas;
    [SerializeField] private TextMeshProUGUI textoTaquara;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Taquara"))
        {
            taquara++;
            corte.Play();
            taquas.Play();
            StartCoroutine(esperar(collision.gameObject));
            
        }
    }

    IEnumerator esperar(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
        AtualizarUI();
        if (taquara >= 10)
        {
            SceneManager.LoadScene("MontarPari");
        }
    }
    void AtualizarUI() {
        if (textoTaquara != null) {
            textoTaquara.text =taquara + "/10";
        }
    }
}
