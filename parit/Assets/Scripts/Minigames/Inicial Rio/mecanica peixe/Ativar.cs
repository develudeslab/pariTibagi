using UnityEngine;

public class Ativar : MonoBehaviour
{
   public GameObject Minigame;
   private int chance;
    void Start()
    {
        Minigame.SetActive(false);  
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Peixe"))
        {
            chance = Random.Range(0, 10);
            if (chance > 5) 
            { 
                Destroy(other.gameObject);
                Time.timeScale = 0;
                Minigame.SetActive(true);
            }
        }
         
    }
}
