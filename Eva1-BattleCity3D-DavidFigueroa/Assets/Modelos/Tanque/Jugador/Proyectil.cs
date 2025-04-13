using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            // Verifica si el objeto tiene el script Enemigo
            DificultadEnemigo enemigo = collision.gameObject.GetComponent<DificultadEnemigo>();

            if (enemigo != null)
            {
                enemigo.RecibirDaño(); // Le resta 1 de vida
            }

            Destroy(gameObject); // Destruye la bala
        }
        else if (collision.gameObject.CompareTag("Jugador"))
        {
            // Puedes ignorar o manejar si lo necesitas
        }
        else
        {
            Destroy(gameObject); // Destruye la bala al chocar con otras cosas
        }
    }
}
