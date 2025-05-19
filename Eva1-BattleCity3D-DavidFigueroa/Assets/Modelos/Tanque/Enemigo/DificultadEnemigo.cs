using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultadEnemigo : MonoBehaviour
{
    public int vida;
    private int dificultad;

    public AudioClip Explocion;

    public Material MFacil;
    public Material MMedio;
    public Material MDificil;

    void Start()
    {
        dificultad = PlayerPrefs.GetInt("Dificultad", 1); 
        vida = dificultad; 

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            switch (dificultad)
            {
                case 1:
                    renderer.material = MFacil;
                    break;
                case 2:
                    renderer.material = MMedio;
                    break;
                case 3:
                    renderer.material = MDificil;
                    break;
            }
        }
    }

    public void RecibirDaño()
    {
        vida--;

        if (vida <= 0)
        {
            if (Explocion != null)
                AudioSource.PlayClipAtPoint(Explocion, transform.position, PlayerPrefs.GetFloat("Volumen", 1f));

            FindObjectOfType<Puntaje>().AumentarPuntuacion();

            Destroy(gameObject);
        }

    }

    public void RestablecerVida()
    {
        vida = dificultad;
    }
}
