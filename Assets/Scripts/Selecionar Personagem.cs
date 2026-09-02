using UnityEngine;
using UnityEngine.EventSystems;

public class SelecionarPersonagem : MonoBehaviour, IPointerClickHandler
{
    public Personagens personagens;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Objeto Clicado: " + gameObject.name);
    }

    public void ReceberItem(string itemSelecionado)
    {
        Debug.Log("Item recebido com sucesso: " + itemSelecionado);
    }
}