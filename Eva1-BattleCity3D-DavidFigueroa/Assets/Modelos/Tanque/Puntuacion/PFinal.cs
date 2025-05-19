using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PFinal : MonoBehaviour
{
    public GameObject panelGanar;         
    public TextMeshProUGUI txtResultado;   

    void Start()                       
    {
        panelGanar.SetActive(false);
    }

    public void Mostrar(bool victoria, string nombre)
    {
        panelGanar.SetActive(true);
        txtResultado.text = victoria
            ? $"¡Ganaste {nombre}!"
            : $"Perdiste {nombre} :(";
        Time.timeScale = 0f;             
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
