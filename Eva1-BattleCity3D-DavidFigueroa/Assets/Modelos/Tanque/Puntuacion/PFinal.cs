using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum MotivoDerrota
{
    SinVida,
    TiempoAgotado
}

public class PFinal : MonoBehaviour
{
    public GameObject panelGanar;
    public TextMeshProUGUI txtResultado;

    void Start() => panelGanar.SetActive(false);

    public void Mostrar(bool victoria, string nombre, MotivoDerrota motivo = MotivoDerrota.SinVida)
    {
        panelGanar.SetActive(true);

        if (victoria)
        {
            txtResultado.text = $"¡Ganaste {nombre}!";
        }
        else
        {
            string mensaje = motivo == MotivoDerrota.TiempoAgotado
                ? "Se acabó el tiempo"
                : "Te mató un Kamikaze";

            txtResultado.text = $"Game Over {nombre}\n{mensaje}";
        }

        Time.timeScale = 0f;
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
