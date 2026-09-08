using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AplicarControllerPersonagem : MonoBehaviour
{
    [Header("Controllers dos Personagens")]
    [SerializeField] private RuntimeAnimatorController[] controllers;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        AplicarControllerSalvo();
    }

    public void AplicarControllerSalvo()
    {
        if (controllers == null || controllers.Length == 0)
            return;

        int indiceSelecionado = PlayerPrefs.GetInt(Personagens.ChaveSelecao, 0);
        indiceSelecionado = Mathf.Clamp(indiceSelecionado, 0, controllers.Length - 1);

        if (controllers[indiceSelecionado] != null)
            animator.runtimeAnimatorController = controllers[indiceSelecionado];
    }
}