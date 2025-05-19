using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInit : MonoBehaviour
{
    [SerializeField] GameObject oneShotPrefab;   // ← arrastra OneShotSFX aquí

    void Awake()
    {
        AudioOneShot.prefab = oneShotPrefab;
    }
}
