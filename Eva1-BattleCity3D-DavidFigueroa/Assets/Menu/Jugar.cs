using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Jugar : MonoBehaviour
{
    public TMP_InputField inputJugador;
    public Slider sliderVolumen;

    [Header("Panel de descripción")]
    public GameObject panelDescripcion;

    void GuardarPreferencias()
    {
        string nombre = inputJugador.text.Trim();
        float volumen = sliderVolumen.value;

        // Guarda nombre (puedes validar si está vacío)
        if (string.IsNullOrEmpty(nombre))
            nombre = "Jugador";

        PlayerPrefs.SetString("NombreJugador", nombre);
        PlayerPrefs.SetFloat("Volumen", volumen);
    }

    public void JugarF()
    {
        GuardarPreferencias();
        PlayerPrefs.SetInt("Dificultad", 1);
        SceneManager.LoadScene("Juego");
    }

    public void JugarM()
    {
        GuardarPreferencias();
        PlayerPrefs.SetInt("Dificultad", 2);
        SceneManager.LoadScene("Juego");
    }

    public void JugarD()
    {
        GuardarPreferencias();
        PlayerPrefs.SetInt("Dificultad", 3);
        SceneManager.LoadScene("Juego");
    }

    public void Descripcion()
    {;
        if (panelDescripcion != null)
            panelDescripcion.SetActive(true);
    }

    public void CerrarDescripcion()       // botón “Cerrar” en el panel
    {
        if (panelDescripcion != null)
            panelDescripcion.SetActive(false);  // ocultar panel
    }
}
