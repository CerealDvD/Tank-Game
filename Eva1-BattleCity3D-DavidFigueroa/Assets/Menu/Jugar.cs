using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    public void JugarF()
    {
        PlayerPrefs.SetInt("Dificultad", 1);
        SceneManager.LoadScene("Juego");
    }

    public void JugarM()
    {
        PlayerPrefs.SetInt("Dificultad", 2);
        SceneManager.LoadScene("Juego");
    }

    public void JugarD()
    {
        PlayerPrefs.SetInt("Dificultad", 3);
        SceneManager.LoadScene("Juego");
    }
}
