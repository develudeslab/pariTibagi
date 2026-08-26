// PlayerAnimation.cs
using UnityEngine;

// Garante que o GameObject tenha os componentes necess�rios.
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    // Hashes para os par�metros da Blend Tree.
    private int moveXHash;
    private int moveYHash;
    private int IsMovingHash;

    // Guarda a �ltima dire��o de movimento real para o idle.
    private Vector2 UltimaDirecao = Vector2.zero;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Converte as strings dos par�metros em IDs inteiros (Hashes) para otimiza��o.
        moveXHash = Animator.StringToHash("MoveX");
        moveYHash = Animator.StringToHash("MoveY");
        IsMovingHash = Animator.StringToHash("IsMoving");

        // Inicia a dire��o com os valores atuais do Animator, se houver.
        UltimaDirecao = new Vector2(
            animator.GetFloat(moveXHash),
            animator.GetFloat(moveYHash)
        );
    }

    public void Animacao(Vector2 moveInput)
    {
        bool estaMovendo = moveInput.sqrMagnitude > 0.01f;

        if (estaMovendo)
        {
            UltimaDirecao = moveInput.normalized;
            animator.SetFloat(moveXHash, UltimaDirecao.x);
            animator.SetFloat(moveYHash, UltimaDirecao.y);
        }
        else
        {
            // Mantemos altima direo para o idle.
            animator.SetFloat(moveXHash, UltimaDirecao.x);
            animator.SetFloat(moveYHash, UltimaDirecao.y);
        }

        animator.SetBool(IsMovingHash, estaMovendo);
    }
}
