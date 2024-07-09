using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoldShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del objeto a disparar
    public Transform firePoint; // Punto desde donde se disparará el objeto
    public float maxChargeTime = 2f; // Tiempo máximo para cargar el disparo
    public float maxShootForce = 20f; // Fuerza máxima del disparo
    public float gravity = -9.81f; // Valor de la gravedad
    public Rigidbody2D rb2d;

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

    void Shoot(float shootForce)
    {
        // Crear el proyectil en el punto de disparo
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Verificar que se haya encontrado el Rigidbody2D
        if (rb != null)
        {
            // Aplicar una fuerza al proyectil
            rb.AddForce(firePoint.up * shootForce, ForceMode2D.Impulse);

            // Añadir la gravedad personalizada al proyectil
            ProjectileGravity2D pg = projectile.AddComponent<ProjectileGravity2D>();
            pg.gravity = gravity;
            pg.rb2d = rb;
        }
        else
        {
            Debug.LogError("No se encontró Rigidbody2D en el proyectil.");
        }
    }
}

public class ProjectileGravity2D : MonoBehaviour
{
    public float gravity = -9.81f;
    public Rigidbody2D rb2d;

    void FixedUpdate()
    {
        // Aplicar una fuerza hacia abajo (como si fuera gravedad)
        rb2d.AddForce(Vector2.up * gravity, ForceMode2D.Force);
    }
}
