using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumenUI : MonoBehaviour
{
    public Slider sliderVolumen;
    public AudioMixer mixer;      // arrástrale tu MasterMixer en el inspector
    const string PARAM = "MusicVol";   // nombre del parámetro expuesto

    void Start()
    {
        // ___leer valor guardado (0‑1, por defecto 1)___
        float vLin = PlayerPrefs.GetFloat("Volumen", 1f);
        sliderVolumen.value = vLin;
        SetVolume(vLin);

        // registrar callback
        sliderVolumen.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float vLinear)
    {
        // Mixer usa dB: 20*log10(lineal). Para 0 => −80 dB (silencio)
        float vDb = (vLinear > 0.0001f) ? Mathf.Log10(vLinear) * 20f : -80f;
        mixer.SetFloat(PARAM, vDb);
        PlayerPrefs.SetFloat("Volumen", vLinear);
    }
}
