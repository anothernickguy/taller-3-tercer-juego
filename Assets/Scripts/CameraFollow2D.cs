using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá
    public Vector3 offset = new Vector3(0, 0, -10); // Desplazamiento de la cámara respecto al objeto
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la cámara

    void FixedUpdate()
    {
        // Si no hay un objetivo, salir
        if (target == null) return;

        // Calcular la posición deseada con el offset
        Vector3 desiredPosition = target.position + offset;

        // Interpolar suavemente entre la posición actual de la cámara y la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar la posición de la cámara
        transform.position = smoothedPosition;
    }
}
