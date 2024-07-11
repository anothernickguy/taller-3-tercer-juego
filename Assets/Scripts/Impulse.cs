using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float fuerza = 10f; // La magnitud de la fuerza que se aplicará

    void Start()
    {
        // Obtiene el componente Rigidbody del objeto al que se aplicará la fuerza
        Rigidbody rb = GetComponent<Rigidbody>();

        // Aplica una fuerza hacia la izquierda
        if (rb != null)
        {
            rb.AddForce(Vector3.left * fuerza, ForceMode.Impulse);
        }
    }
}
