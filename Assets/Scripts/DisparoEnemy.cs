using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DisparoEnemy : MonoBehaviour
{
    public GameObject objetoADisparar; // El objeto que se disparar�
    public Transform puntoDeDisparo; // El punto desde donde se disparar� el objeto
    public float fuerzaDeDisparo = 10f; // La fuerza con la que se disparar� el objeto
    public TextMeshProUGUI textoContador; // El TextMeshPro que se actualizar�
    public UnityEvent OnEnter;

    private int contador = 1;

    void Update()
    {
        // Detecta si se ha hecho clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(EsperarYDisparar(3f));
        }
    }

    IEnumerator EsperarYDisparar(float segundos)
    {
        // Espera el tiempo especificado en segundos
        yield return new WaitForSeconds(segundos);

        // Incrementa el contador y actualiza el texto
        contador++;
        textoContador.text = contador.ToString();

        // Crea una instancia del objeto a disparar en la posici�n y rotaci�n del punto de disparo
        GameObject objetoDisparado = Instantiate(objetoADisparar, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Obtiene el componente Rigidbody del objeto disparado para aplicar la fuerza
        Rigidbody rb = objetoDisparado.GetComponent<Rigidbody>();

        OnEnter.Invoke();

        // Aplica una fuerza al objeto para dispararlo hacia la izquierda globalmente en el eje x
        if (rb != null)
        {
            // Vector3.left es (�1, 0, 0) en el espacio local, para el eje global x usamos (-1, 0, 0)
            rb.AddForce(Vector3.left * fuerzaDeDisparo, ForceMode.Impulse);
        }
    }
}
