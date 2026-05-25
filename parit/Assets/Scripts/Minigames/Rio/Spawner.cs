using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float TempoSpawn = 0;
    public Vector2 AreaMin;
    public Vector2 AreaMax;
    public AudioSource peixe;
    public AudioSource pedaco;

    void Update()
    {
        TempoSpawn += Time.deltaTime;

        if (TempoSpawn >= 1f)
        {
            SpawnarCoiso();
            TempoSpawn = 0;
        }
    }
    
    public void SpawnarCoiso()
    {
        int Aleatorio = UnityEngine.Random.Range(0, Prefabs.Length);
        float posX = UnityEngine.Random.Range(AreaMin.x, AreaMax.x);
        float posY = UnityEngine.Random.Range(AreaMin.y, AreaMax.y);
        Vector3 posicaoSpawn = new Vector3(posX, posY, 0);
        
        if(Aleatorio == 0)
        {
            pedaco.Play();
        }
        if (Aleatorio == 1)
        {
            peixe.Play();
        }
        Instantiate(
            Prefabs[Aleatorio],
            posicaoSpawn,
            Quaternion.identity
        );
    }
}

   
