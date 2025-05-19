using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PFinal : MonoBehaviour
{
    public GameObject panelGanar;          // Panel entero (desactivado al inicio)
    public TextMeshProUGUI txtResultado;   // TMP dentro del panel

    void Start()                           // se ejecuta una sola vez
    {
        panelGanar.SetActive(false);
    }

    // Llamar con true = victoria ; false = derrota
    public void Mostrar(bool victoria, string nombre)
    {
        panelGanar.SetActive(true);
        txtResultado.text = victoria
            ? $"¡Ganaste, {nombre}!"
            : $"Perdiste, {nombre}";
        Time.timeScale = 0f;               // pausa el juego
    }

    // Botón “Volver al menú”
    public void VolverMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
