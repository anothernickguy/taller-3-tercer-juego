using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeObjeto : MonoBehaviour
{
    public GameObject objetoParaActivar; // El objeto que se activará

    public void ActivarObjeto()
    {
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true);
            Debug.Log("Objeto activado: " + objetoParaActivar.name);
        }
        else
        {
            Debug.LogWarning("El objeto para activar no está asignado.");
        }
    }
}
