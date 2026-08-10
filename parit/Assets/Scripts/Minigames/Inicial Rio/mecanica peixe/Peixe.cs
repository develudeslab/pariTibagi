using UnityEngine;

public class Peixe : MonoBehaviour
{
    public float velocidade = 5;
    public float limiteY = -5f;
    public static int peixes;
    public GameObject Minigame;
    public GameObject Player;
    public Transform OrigemPeixe;

    void Start()
    {
        ResetPeixe();
    }

    private void OnEnable()
    {
        ResetPeixe();
    }

    void Update()
    {
        velocidade += Time.unscaledDeltaTime;
        transform.Translate(Vector3.down * velocidade * Time.unscaledDeltaTime);

        if (transform.position.y <= limiteY)
        {
            Time.timeScale = 1;
            Minigame.SetActive(false);
            Player.SetActive(true);
            ResetPeixe();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mao"))
        {
            Time.timeScale = 1;
            peixes++;
            Minigame.SetActive(false);
            Player.SetActive(true);
            ResetPeixe();
        }
    }

    public void ResetPeixe()
    {
        if (OrigemPeixe == null)
            return;

        transform.position = OrigemPeixe.position;
        velocidade = 5f;
    }
}