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
            DificultadEnemigo enemigo = collision.gameObject.GetComponent<DificultadEnemigo>();

            if (enemigo != null)
            {
                enemigo.RecibirDaño();
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Jugador"))
        {
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
