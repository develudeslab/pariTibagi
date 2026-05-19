// PlayerAnimation.cs
using UnityEngine;

// Garante que o GameObject tenha os componentes necessários.
[RequireComponent(typeof(Animator), typeof(InputHandler))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private InputHandler inputHandler;

    // Hashes para os parâmetros da Blend Tree.
    private int moveXHash;
    private int moveYHash;
    private int isMovingHash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        inputHandler = GetComponent<InputHandler>();

        // Converte as strings dos parâmetros em IDs inteiros (Hashes) para otimização.
        moveXHash = Animator.StringToHash("MoveX");
        moveYHash = Animator.StringToHash("MoveY");
        isMovingHash = Animator.StringToHash("isMoving");
    }

    private void Update()
    {
        // 1. Lemos o input de movimento diretamente do nosso InputHandler.
        Vector2 moveInput = inputHandler.PosicaoInput;

        // 2. Verificamos se há algum input de movimento.
        if (moveInput.magnitude > 0.1f) // Se o jogador estiver se movendo
        {
            // Se estiver se movendo, atualizamos os parâmetros MoveX e MoveY
            // para que a Blend Tree selecione a animação de direção correta.
            animator.SetFloat(moveXHash, moveInput.x);
            animator.SetFloat(moveYHash, moveInput.y);

            // Definimos o parâmetro booleano no Animator.
            animator.SetBool(isMovingHash, true);
        }
        else // Se o jogador NÃO estiver se movendo
        {
            animator.SetBool(isMovingHash, false);
            // Para um "idle" puro, sem movimento de fato, a Blend Tree irá manter
            // o último sprite de direção se não houver um "walk" para sobrepor.
        }
    }
}
