using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI NombreJ;
    public TextMeshProUGUI Puntos;
    private int puntuacion = 0;

    void Start()
    {
        string nombre = PlayerPrefs.GetString("NombreJugador", "Jugador");
        NombreJ.text = nombre;

        int ultimaPuntuacion = PlayerPrefs.GetInt("Puntuacion", 0);
        Debug.Log("Última puntuación: " + ultimaPuntuacion);
        StartCoroutine(ContadorConsola());
        ActualizarTexto();
    }

    public void AumentarPuntuacion()
    {
        puntuacion++;
        ActualizarTexto();
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
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
    }

    public void SalirDelJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
