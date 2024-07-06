using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoldShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del objeto a disparar
    public Transform firePoint; // Punto desde donde se disparará el objeto
    public float maxChargeTime = 2f; // Tiempo máximo para cargar el disparo
    public float maxShootForce = 20f; // Fuerza máxima del disparo

    private float chargeTime; // Tiempo de carga actual

    void Update()
    {
        // Detectar cuando se mantiene presionado el botón izquierdo del mouse
        if (Input.GetMouseButton(0))
        {
            // Incrementar el tiempo de carga mientras se mantiene presionado el botón
            chargeTime += Time.deltaTime;
        }

        // Detectar cuando se suelta el botón izquierdo del mouse
        if (Input.GetMouseButtonUp(0))
        {
            // Calcular la fuerza del disparo basada en el tiempo de carga
            float shootForce = Mathf.Clamp(chargeTime / maxChargeTime, 0f, 1f) * maxShootForce;

            // Disparar el objeto
            Shoot(shootForce);

            // Reiniciar el tiempo de carga
            chargeTime = 0f;
        }
    }

    void Shoot(float force)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Crear una instancia del proyectil en el punto de disparo
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Obtener el componente Rigidbody2D del proyectil
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Aplicar una fuerza al proyectil en la dirección del firePoint
                rb.AddForce(firePoint.right * force, ForceMode2D.Impulse);
            }
        }
    }
}
