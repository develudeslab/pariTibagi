using UnityEngine;

public class FisicaPausada : MonoBehaviour
{
    private void Awake()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
    }

    private void Update()
    {
        Physics2D.Simulate(Time.unscaledDeltaTime);
    }
}