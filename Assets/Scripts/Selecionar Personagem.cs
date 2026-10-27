using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelecionarPersonagem : MonoBehaviour, IPointerClickHandler
{
    public Personagens personagens;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (personagens != null)
            personagens.SalvarSelecao();

        Debug.Log("Objeto Clicado: " + gameObject.name);
        SceneManager.LoadScene("Fase1");
    }

    public void ReceberItem(string itemSelecionado)
    {
        Debug.Log("Item recebido com sucesso: " + itemSelecionado);
    }
}