using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform puntoA; // punto inicial
    public Transform puntoB; // punto final
    public float velocidad = 1f;

    private Transform objetivoActual;

    void Start()
    {
        objetivoActual = puntoB;
    }

    void Update()
    {
        // Mover hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        // Cambiar de dirección cuando llega a uno de los puntos
        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.1f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }
}
