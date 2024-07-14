using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DisparoEnemy : MonoBehaviour
{
    public GameObject objetoADisparar; // El objeto que se disparar�
    public Transform puntoDeDisparo; // El punto desde donde se disparar� el objeto
    public float fuerzaDeDisparo = 10f; // La fuerza con la que se disparar� el objeto (positivo para fuerza hacia la izquierda)
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
            Vector3 fuerza = Vector3.left * fuerzaDeDisparo;
            rb.AddForce(fuerza, ForceMode.Impulse);

            // Debug logs para ver lo que est� pasando
            Debug.Log("Fuerza aplicada: " + fuerza);
            Debug.Log("Posici�n inicial del objeto disparado: " + objetoDisparado.transform.position);
        }
        else
        {
            Debug.LogError("El objeto disparado no tiene un componente Rigidbody.");
        }
    }
}
