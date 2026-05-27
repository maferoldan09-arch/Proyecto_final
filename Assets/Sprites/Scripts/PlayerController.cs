using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;

    public float fuerzaSalto = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    private bool enSuelo;
    public bool muerto;

    private Rigidbody2D rb;

    public Animator animator;

    // PUNTAJE
    public int score = 0;

    // MONEDAS
    public int monedas = 0;
    public int totalMonedas = 0;

    // BILLETES
    public int billetes = 0;
    public int totalBilletes = 0;

    // COFRE
    public bool hasCofre = false;

    // UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI billetesText;
    public TextMeshProUGUI notificationText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        UpdateScore();
        UpdateMonedas();
        UpdateBilletes();
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            Movimiento();

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
            enSuelo = hit.collider != null;

            if (enSuelo && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            }

            animator.SetBool("ensuelo", enSuelo);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Morir();
        }
    }

    public void Movimiento()
    {
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        animator.SetFloat("movement", Mathf.Abs(velocidadX * velocidad));

        if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 posicion = transform.position;

        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
    }

    public void Morir()
    {
        muerto = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // MONEDAS
        if(other.CompareTag("Moneda"))
        {
            monedas++;
            score += 1;

            UpdateMonedas();
            UpdateScore();

            ShowNotification("Moneda recogida");

            Destroy(other.gameObject);
        }

        // BILLETES
        if(other.CompareTag("Billete"))
        {
            billetes++;
            score += 5;

            UpdateBilletes();
            UpdateScore();

            ShowNotification("Billete recogido");

            Destroy(other.gameObject);
        }

        // COFRE FINAL
        if(other.CompareTag("Cofre"))
        {
            hasCofre = true;

            ShowNotification("¡Ganaste!");

            Debug.Log("Ganaste");
        }

        // AGUA
        if(other.CompareTag("Agua"))
        {
            Morir();

            ShowNotification("Game Over");

            Debug.Log("Game Over");
        }
    }

    // UI

    void UpdateScore()
    {
        if(scoreText != null)
            scoreText.text = "Puntaje: " + score;
    }

    void UpdateMonedas()
    {
        if(monedasText != null)
            monedasText.text = "Monedas: " + monedas;
    }

    void UpdateBilletes()
    {
        if(billetesText != null)
            billetesText.text = "Billetes: " + billetes;
    }

    void ShowNotification(string message)
    {
        if(notificationText != null)
            notificationText.text = message;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}