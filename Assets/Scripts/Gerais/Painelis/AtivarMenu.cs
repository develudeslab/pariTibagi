using UnityEngine;

public class AtivarMenu : MonoBehaviour
{
    public GameObject PainelMenu;
   

    public void Ativar()
    {
        PainelMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Desativar()
    {
        PainelMenu?.SetActive(false);
        Time.timeScale = 1;
    }

    /*void VerificarTemp()
    {
        if(PainelMenu = null)
        {
            Time.timeScale = 1;
        }
        if(PainelMenu != null)
        {
            Time.timeScale = 0;
        }
    }
    */
}
