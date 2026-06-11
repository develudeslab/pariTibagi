using UnityEngine;

public class Peixe : MonoBehaviour
{
    public float velocidade = 1;
    void Update()
    {
        velocidade += Time.deltaTime;
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);
    }
}
