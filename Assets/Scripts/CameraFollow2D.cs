using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir�
    public Vector3 offset = new Vector3(0, 0, -10); // Desplazamiento de la c�mara respecto al objeto
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la c�mara

    void FixedUpdate()
    {
        // Si no hay un objetivo, salir
        if (target == null) return;

        // Calcular la posici�n deseada con el offset
        Vector3 desiredPosition = target.position + offset;

        // Interpolar suavemente entre la posici�n actual de la c�mara y la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}
