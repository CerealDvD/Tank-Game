using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 100f;
    public GameObject projectilePrefab;
    public Transform Disparo;

    void Update()
    {
        // Movimiento
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Translate(0, 0, move);
        transform.Rotate(0, rotate, 0);

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, Disparo.position, Disparo.rotation);
    }
}
