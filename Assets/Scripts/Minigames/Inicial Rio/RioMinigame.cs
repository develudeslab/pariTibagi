using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class RioMinigame : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadeMovimento;
    private Vector2 offset;
    private Material material;
    public AudioSource agua;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Start()
    {
        agua.Play();
    }

    private void Update()
    {
        offset = velocidadeMovimento * Time.unscaledDeltaTime;
        material.mainTextureOffset += offset;
    }
}
