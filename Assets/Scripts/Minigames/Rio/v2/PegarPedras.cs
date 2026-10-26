using UnityEngine;

public class PegarPedras : MonoBehaviour
{
    public bool CarregandoPedra = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(CarregandoPedra) return;
        if (other.CompareTag("Pedra") && !CarregandoPedra)
        {
            Destroy(other.gameObject);
            CarregandoPedra = true;
        }
    }

    void Update()
    {
        if(!CarregandoPedra) return;
        if(CarregandoPedra)
        {
            Debug.Log("Carregando pedra");
        }
    }

}
