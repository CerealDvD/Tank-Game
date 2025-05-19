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
    public AudioClip SGanar;
    public AudioClip SPerder;

    void Start() => panelGanar.SetActive(false);

    public void Mostrar(bool victoria, string nombre, MotivoDerrota motivo = MotivoDerrota.SinVida)
    {
        panelGanar.SetActive(true);

        Vector3 posAudio = Camera.main.transform.position;
        float vol = PlayerPrefs.GetFloat("Volumen", 1f);

        if (victoria)
        {
            if (SGanar) AudioSource.PlayClipAtPoint(SGanar, posAudio, vol);
            txtResultado.text = $"¡Ganaste {nombre}!";
        }
        else
        {
            if (SPerder) AudioSource.PlayClipAtPoint(SPerder, posAudio, vol);
            string msg = motivo == MotivoDerrota.TiempoAgotado
                         ? "Se acabó el tiempo"
                         : "Te mató un Kamikaze";
            txtResultado.text = $"Game Over {nombre}\n{msg}";
        }

        Time.timeScale = 0f;
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
