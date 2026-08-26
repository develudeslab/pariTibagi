using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Parimontado : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(esperar());
    }

   IEnumerator esperar()
    {
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene("Fase2");
    }
}
