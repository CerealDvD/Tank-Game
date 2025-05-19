using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimientoJugador : MonoBehaviour
{
    public int vida = 2;
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoTiempoRestante;
    private Puntaje puntaje;
    private bool invulnerable = false;
    public float tiempoInvulnerabilidad = 0.5f;
    public float tiempoAntesDestruccion = 0.1f;

    public float moveSpeed = 1f;
    public float turnSpeed = 100f;
    public GameObject projectilePrefab;
    public Transform Disparo;

    public AudioClip SDisparo;
    public AudioClip SMovimiento;
    private AudioSource audioSource;

    private PFinal uiFinal;

    void Start()
    {
        textoVida.text = "" + vida;
        puntaje = FindObjectOfType<Puntaje>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = PlayerPrefs.GetFloat("Volumen", 1f);

        uiFinal = FindObjectOfType<PFinal>();
        StartCoroutine(MuertePorTiempo());
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
            Camera.main.transform.parent = null;
            StartCoroutine(DestruirConDelay());
            Derrota();
        }
    }

    IEnumerator DestruirConDelay()
    {
        yield return new WaitForSeconds(tiempoAntesDestruccion);
        Destroy(gameObject);
    }

    IEnumerator MuertePorTiempo()
    {
        float tiempoRestante = 15f;
        while (tiempoRestante >= 0)
        {
            if (textoTiempoRestante != null)
            {
                textoTiempoRestante.text = "T: " + Mathf.CeilToInt(tiempoRestante).ToString();
            }
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
        }

        Camera.main.transform.parent = null;
        Destroy(gameObject);
        Derrota();
    }

    void Derrota()              
    {
        string nombre = PlayerPrefs.GetString("NombreJugador", "Jugador");
        uiFinal.Mostrar(false, nombre);
        Camera.main.transform.parent = null;
        Destroy(gameObject, 0.1f);
    }

    void TerminarInvulnerabilidad()
    {
        invulnerable = false;
    }

    void Update()
    {
        bool moviendo = false;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SDisparo != null)
                AudioSource.PlayClipAtPoint(SDisparo, transform.position, PlayerPrefs.GetFloat("Volumen", 1f));
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

            EnemigoNavMesh enemigo = collision.gameObject.GetComponent<EnemigoNavMesh>();
            if (enemigo != null)
            {
                enemigo.ActivarRalentizacion();
            }
        }

        if (collision.gameObject.CompareTag("Ganar"))
        {
        }
    }
}
