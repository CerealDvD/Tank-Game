using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaDetector : MonoBehaviour
{
    private PFinal uiFinal;

    void Start()
    {
        uiFinal = FindObjectOfType<PFinal>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Jugador")) return;   // jugador debe tener tag "Jugador"

        string nombre = PlayerPrefs.GetString("NombreJugador", "Jugador");
        uiFinal.Mostrar(true, nombre);              // victoria
    }
}
