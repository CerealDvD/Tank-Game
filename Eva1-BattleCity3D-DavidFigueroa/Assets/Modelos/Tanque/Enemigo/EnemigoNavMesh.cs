using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoNavMesh : MonoBehaviour
{
    public Transform objetivo;
    public NavMeshAgent agente;
    private float velocidadBase;
    private bool ralentizado = false;
    private int toquesAlJugador = 2;

    public AudioClip Explocion;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        int dificultad = PlayerPrefs.GetInt("Dificultad", 1);

        switch (dificultad)
        {
            case 1:
                velocidadBase = 0.5f;
                break;
            case 2:
                velocidadBase = 0.7f;
                break;
            case 3:
                velocidadBase = 1f;
                break;
            default:
                velocidadBase = 0.5f;
                break;
        }

        agente.speed = velocidadBase;
    }

    void Update()
    {
        // Movimiento jugador
        agente.destination = objetivo.position;
    }

    public void ActivarRalentizacion()
    {
        if (!ralentizado)
        {
            StartCoroutine(Ralentizar());

            toquesAlJugador--;
            if (Explocion != null)
                AudioSource.PlayClipAtPoint(Explocion, transform.position);
            if (toquesAlJugador <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Ralentizar()
    {
        ralentizado = true;
        agente.speed = velocidadBase * 0.5f;
        yield return new WaitForSeconds(3f);
        agente.speed = velocidadBase;
        ralentizado = false;
    }
}
