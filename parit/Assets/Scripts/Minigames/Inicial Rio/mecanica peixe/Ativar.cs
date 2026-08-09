using UnityEngine;
using UnityEngine.SceneManagement;

public class Ativar : MonoBehaviour
{
   public GameObject Minigame;
   public GameObject Player;
   public Peixe peixeScript;

    void Awake()
    {
        peixeScript = FindObjectOfType<Peixe>();
    }
    
    void Update()
    {
        if (Peixe.peixes >= 5)
        {
            SceneManager.LoadScene("Fase1");
        }
    }

    void Start()
    {
        Minigame.SetActive(false);  
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Peixe"))
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            Minigame.SetActive(true);
            Player.SetActive(false);
        }
    }
}
