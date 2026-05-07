using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float TempoSpawn = 0;
    public Transform Spaw;
    void Update()
    {
        TempoSpawn += Time.deltaTime;
        if(TempoSpawn >= 2f)
        {
            SpawnarCoisos();
            TempoSpawn = 0;
        }
    }

    public void SpawnarCoisos()
    {
        for (int i = 0; i < Prefabs.Length; i++)
        {
            Instantiate(Prefabs[i],
            Spaw.position + new Vector3(i * 2, 0, 0),
            Quaternion.identity);
        }
    }
}

   
