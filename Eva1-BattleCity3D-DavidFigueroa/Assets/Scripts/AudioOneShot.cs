using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioOneShot
{
    // arrastraremos el prefab en un único lugar al iniciar
    public static GameObject prefab;

    /// Reproduce un clip en la posición dada y lo destruye cuando termina
    public static void Play(AudioClip clip, Vector3 pos)
    {
        if (clip == null || prefab == null) return;

        GameObject go = Object.Instantiate(prefab, pos, Quaternion.identity);
        AudioSource src = go.GetComponent<AudioSource>();
        src.clip = clip;
        src.Play();
        Object.Destroy(go, clip.length);
    }
}
