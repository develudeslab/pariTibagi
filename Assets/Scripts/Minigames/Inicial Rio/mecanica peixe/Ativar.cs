using UnityEngine;
using UnityEngine.SceneManagement;

public class Ativar : MonoBehaviour
{
   public GameObject Minigame;
   public GameObject Player;
   public Peixe peixeScript;
   public GameObject BotaoMenu;
   private bool carregandoProximaFase;

    void Awake()
    {
        peixeScript = FindObjectOfType<Peixe>();
    }
    
    void Update()
    {
        if (!carregandoProximaFase && Peixe.peixes >= 3)
        {
            carregandoProximaFase = true;
            SceneManager.LoadScene("Fase2");
        }
    }

    void Start()
    {
        Peixe.peixes = 0;
        Minigame.SetActive(false);  
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Peixe"))
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            BotaoMenu.SetActive(false);
            Minigame.SetActive(true);
            Player.SetActive(false);
        }
    }
}
