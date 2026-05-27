using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float velocidadMovimiento;

    private int siguientePlataforma = 1;
    private bool ordenPlataformas = true;

    private Vector3 ultimaPosicion;
    private Vector3 movimientoPlataforma;

    private void Start()
    {
        ultimaPosicion = transform.position;
    }

    private void FixedUpdate()
    {
        if (ordenPlataformas &&
            siguientePlataforma + 1 >= puntosMovimiento.Length)
        {
            ordenPlataformas = false;
        }

        if (!ordenPlataformas &&
            siguientePlataforma <= 0)
        {
            ordenPlataformas = true;
        }

        if (Vector2.Distance(
            transform.position,
            puntosMovimiento[siguientePlataforma].position)
            < 0.1f)
        {
            if (ordenPlataformas)
                siguientePlataforma++;
            else
                siguientePlataforma--;
        }

        ultimaPosicion = transform.position;

        transform.position = Vector2.MoveTowards(
            transform.position,
            puntosMovimiento[siguientePlataforma].position,
            velocidadMovimiento * Time.fixedDeltaTime
        );

        movimientoPlataforma =
            transform.position - ultimaPosicion;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb =
                other.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.position += new Vector2(
                    movimientoPlataforma.x,
                    movimientoPlataforma.y
                );
            }
        }
    }
}