using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColocarPedras : MonoBehaviour
{
    public PegarPedras pegarPedras;
    public Transform[] LocalDeColocar;
    public GameObject[] ObjetosParaAtivar;
    public string NomeCena;
    public float TempoAntesDeTrocarCena = 2f;
    private bool trocaCenaEmAndamento;

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
            pegarPedras.CarregandoPedra = false;

            if (TodasPedrasAtivas())
            {
                IniciarTrocaDeCena();
            }
            return;
        }
    }

    void IniciarTrocaDeCena()
    {
        if (trocaCenaEmAndamento)
        {
            return;
        }

        trocaCenaEmAndamento = true;
        StartCoroutine(TrocarCenaDepoisDoTempo());
    }

    IEnumerator TrocarCenaDepoisDoTempo()
    {
        yield return new WaitForSeconds(TempoAntesDeTrocarCena);

        if (!string.IsNullOrEmpty(NomeCena))
        {
            SceneManager.LoadScene(NomeCena);
        }
    }

    bool TodasPedrasAtivas()
    {
        if (ObjetosParaAtivar == null)
        {
            return false;
        }

        for (int i = 0; i < ObjetosParaAtivar.Length; i++)
        {
            if (ObjetosParaAtivar[i] == null || !ObjetosParaAtivar[i].activeSelf)
            {
                return false;
            }
        }

        return true;
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
