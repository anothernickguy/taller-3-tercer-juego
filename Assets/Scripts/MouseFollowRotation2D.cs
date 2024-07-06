using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowRotation2D : MonoBehaviour
{
    void Update()
    {
        // Obtener la posición del mouse en el mundo 2D
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección desde el objeto hacia el mouse
        Vector3 direction = mousePosition - transform.position;

        // Asegurarse de que el objeto solo se rota en el plano XY
        direction.z = 0;

        // Calcular el ángulo en el que se debe rotar el objeto para apuntar hacia el mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar la rotación al objeto
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
