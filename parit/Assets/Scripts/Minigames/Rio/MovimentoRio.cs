using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MovimentoRio : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadeMovimento;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = velocidadeMovimento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
