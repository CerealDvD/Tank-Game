using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            Destroy(collision.gameObject); // destruye el enemigo
            Destroy(gameObject);           // destruye la bala
        }
        else
        {
            Destroy(gameObject); // destruye la bala al chocar con otra cosa
        }
    }
}
