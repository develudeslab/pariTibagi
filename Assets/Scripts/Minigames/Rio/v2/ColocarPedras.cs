using UnityEngine;

public class ColocarPedras : MonoBehaviour
{
    public PegarPedras pegarPedras;
    public Transform[] LocalDeColocar;
    public GameObject[] ObjetosParaAtivar;

    void OnValidate()
    {
        AjustarTamanhoDosObjetos();
    }

    void Awake()
    {
        AjustarTamanhoDosObjetos();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Local"))
        {
            return;
        }

        if (pegarPedras == null)
        {
            Debug.LogError("A referencia de PegarPedras nao foi definida.", this);
            return;
        }

        if (!pegarPedras.CarregandoPedra || LocalDeColocar == null)
        {
            return;
        }

        for (int i = 0; i < LocalDeColocar.Length; i++)
        {
            Transform local = LocalDeColocar[i];
            if (local == null || (other.transform != local && !other.transform.IsChildOf(local)))
            {
                continue;
            }

            if (ObjetosParaAtivar[i] == null)
            {
                Debug.LogError($"O objeto do indice {i} nao foi definido.", this);
                return;
            }
            ObjetosParaAtivar[i].SetActive(true);
            IgnorarColisaoComObjeto(other, ObjetosParaAtivar[i]);
            pegarPedras.CarregandoPedra = false;
            return;
        }
    }

    void IgnorarColisaoComObjeto(Collider2D local, GameObject objetoAtivado)
    {
        Collider2D[] colisoresPlayer = pegarPedras.GetComponentsInChildren<Collider2D>();
        Collider2D[] colisoresObjeto = objetoAtivado.GetComponentsInChildren<Collider2D>();

        foreach (Collider2D colisorPlayer in colisoresPlayer)
        {
            if (colisorPlayer == null || !colisorPlayer.enabled)
            {
                continue;
            }

            Physics2D.IgnoreCollision(colisorPlayer, local);

            foreach (Collider2D colisorObjeto in colisoresObjeto)
            {
                if (colisorObjeto != null && colisorObjeto.enabled)
                {
                    Physics2D.IgnoreCollision(colisorPlayer, colisorObjeto);
                }
            }
        }
    }

    void AjustarTamanhoDosObjetos()
    {
        int tamanho = LocalDeColocar == null ? 0 : LocalDeColocar.Length;
        if (ObjetosParaAtivar == null)
        {
            ObjetosParaAtivar = new GameObject[tamanho];
        }
        else if (ObjetosParaAtivar.Length != tamanho)
        {
            System.Array.Resize(ref ObjetosParaAtivar, tamanho);
        }
    }
}
