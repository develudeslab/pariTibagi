using UnityEngine;

public class SpawnarPedras : MonoBehaviour
{
    private const int MaxPedras = 6;
    private const int MaxTentativasSpawn = 30;
    private const float MargemEntrePedras = 0.1f;
    private int pedrasSpawnadas;

    public GameObject PrefabPedra;
    public float TempoSpawn = 0;
    public Vector2 AreaMin;
    public Vector2 AreaMax;

    void Update()
    {
        if (pedrasSpawnadas >= MaxPedras)
        {
            return;
        }

        TempoSpawn += Time.deltaTime;

        if (TempoSpawn >= 0.001f)
        {
            SpawnarPedra();
            TempoSpawn = 0;
        }
    }
    
    public void SpawnarPedra()
    {
        if (pedrasSpawnadas >= MaxPedras)
        {
            return;
        }

        BoxCollider2D colisorPedra = PrefabPedra.GetComponent<BoxCollider2D>();
        if (colisorPedra == null)
        {
            Debug.LogError("O prefab da pedra precisa ter um BoxCollider2D.", this);
            return;
        }

        Vector2 escala = PrefabPedra.transform.lossyScale;
        Vector2 tamanhoColisor = Vector2.Scale(colisorPedra.size, escala)
            + Vector2.one * (MargemEntrePedras * 2f);
        Vector2 centroColisor = Vector2.Scale(colisorPedra.offset, escala);

        for (int tentativa = 0; tentativa < MaxTentativasSpawn; tentativa++)
        {
            Vector3 posicaoSpawn = new Vector3(
                Random.Range(AreaMin.x, AreaMax.x),
                Random.Range(AreaMin.y, AreaMax.y),
                0
            );

            Collider2D[] colisores = Physics2D.OverlapBoxAll(
                (Vector2)posicaoSpawn + centroColisor,
                tamanhoColisor,
                0f
            );

            bool sobrepoePedra = false;
            foreach (Collider2D colisor in colisores)
            {
                if (colisor.CompareTag("Pedra"))
                {
                    sobrepoePedra = true;
                    break;
                }
            }

            if (sobrepoePedra)
            {
                continue;
            }

            Instantiate(
                PrefabPedra,
                posicaoSpawn,
                Quaternion.identity
            );
            pedrasSpawnadas++;
            return;
        }
    }
}
