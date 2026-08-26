using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    [SerializeField]
    public float tempo;
    public TMP_Text TextoTempo;


    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;

            if (TextoTempo != null)
            {
                TextoTempo.text = Mathf.CeilToInt(tempo).ToString();
            }

            if (tempo <= 0)
            {
                tempo = 0; 
                Debug.Log("Fim de Jogo");
            }
        }
    }
}