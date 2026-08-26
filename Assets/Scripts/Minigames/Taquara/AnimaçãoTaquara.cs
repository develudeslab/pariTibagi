using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimaçãoTaquara : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Toque");
        }
    }
}
