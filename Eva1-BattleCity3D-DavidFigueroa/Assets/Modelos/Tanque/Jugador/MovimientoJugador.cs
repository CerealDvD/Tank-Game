using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimientoJugador : MonoBehaviour
{
    public int vida = 2;
    public TextMeshProUGUI textoVida;
    private Puntaje puntaje;
    private bool invulnerable = false;
    public float tiempoInvulnerabilidad = 0.5f;

    public float moveSpeed = 1f;
    public float turnSpeed = 100f;
    public GameObject projectilePrefab;
    public Transform Disparo;

    public AudioClip SDisparo;
    public AudioClip SMovimiento;

    private AudioSource audioSource;

    void Start()
    {
        textoVida.text = "" + vida;
        puntaje = FindObjectOfType<Puntaje>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    public void RecibirDaño()
    {
        if (invulnerable)
            return;

        invulnerable = true;
        Invoke("TerminarInvulnerabilidad", tiempoInvulnerabilidad);

        vida--;
        textoVida.text = "" + vida;

        if (vida <= 0)
        {
            puntaje.MostrarDerrota();
            Camera.main.transform.parent = null;
            Destroy(gameObject);
        }
    }

    void TerminarInvulnerabilidad()
    {
        invulnerable = false;
    }


    void Update()
    {
        bool moviendo = false;

        // Movimiento hacia adelante o atrás
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            moviendo = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            moviendo = true;
        }

        // Rotación
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            moviendo = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            moviendo = true;
        }

        // Activar sonido si se está moviendo
        if (moviendo)
        {
            if (!audioSource.isPlaying && SMovimiento != null)
            {
                audioSource.clip = SMovimiento;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SDisparo != null)
                AudioSource.PlayClipAtPoint(SDisparo, transform.position);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, Disparo.position, Disparo.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            RecibirDaño();
        }
    }
}
