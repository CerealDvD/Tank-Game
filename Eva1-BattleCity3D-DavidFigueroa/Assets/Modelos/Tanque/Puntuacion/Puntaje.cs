using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI Puntos;
    private int puntuacion = 0;
    private int puntuacionMaxima = 5;

    void Start()
    {
        // Leer y mostrar la puntuación anterior solo una vez al iniciar
        int ultimaPuntuacion = PlayerPrefs.GetInt("Puntuacion", 0);
        Debug.Log("Última puntuación: " + ultimaPuntuacion);

        // Iniciar el ciclo que imprime cada 3 segundos
        StartCoroutine(ContadorConsola());

        // Mostrar puntuación inicial en la UI
        ActualizarTexto();
    }

    public void AumentarPuntuacion()
    {
        puntuacion++;

        if (puntuacion >= puntuacionMaxima)
        {
            Puntos.text = "¡Terminaste!";
        }
        else
        {
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        Puntos.text = "Puntuación: " + puntuacion;
    }

    IEnumerator ContadorConsola()
    {
        while (true)
        {
            Debug.Log("Puntuación actual: " + puntuacion);
            yield return new WaitForSeconds(3f);
        }
    }

    void OnApplicationQuit()
    {
        // Guardar la puntuación cuando se cierra el juego
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
    }

    public void SalirDelJuego()
    {
        SceneManager.LoadScene("Menu");
    }
}
