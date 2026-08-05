using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class MovimentoPlayer : MonoBehaviour
{
    // 1. Declare a variável pública para o Input e a velocidade
    public InputAction input;
    public Animator animator;
    public float velocidade = 5f; 

    // 2. Declare as variáveis privadas para o Rigidbody e para guardar a direção
    private Rigidbody2D rb;
    private Vector2 direcaoInput;

    private void OnEnable() => input.Enable(); // Liga a leitura das teclas
    private void OnDisable() => input.Disable(); // Desliga a leitura das teclas

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 4. Leia o valor do Vector2 vindo do teclado e guarde na variável
        direcaoInput = input.ReadValue<Vector2>();
        animator.SetFloat("MoveX", direcaoInput.x);
        animator.SetFloat("MoveY", direcaoInput.y);
        animator.SetBool("IsMoving", direcaoInput.sqrMagnitude > 0.01f);

    }

    void FixedUpdate()
    {
        // 5. Normalização: evita que o jogador corra mais rápido na diagonal
        // Um vetor normalizado sempre tem comprimento
        Vector2 direcao = direcaoInput.normalized;
        // 6. Aplique a velocidade diretamente ao Rigidbody
        rb.linearVelocity = direcao * velocidade;
        
    }
}

