using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisparoEnemy : MonoBehaviour
{
    public GameObject objetoADisparar; // El objeto que se disparará
    public Transform puntoDeDisparo; // El punto desde donde se disparará el objeto
    public float fuerzaDeDisparo = 10f; // La fuerza con la que se disparará el objeto
    public TextMeshProUGUI textoContador; // El TextMeshPro que se actualizará

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

        // Crea una instancia del objeto a disparar en la posición y rotación del punto de disparo
        GameObject objetoDisparado = Instantiate(objetoADisparar, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Obtiene el componente Rigidbody del objeto disparado para aplicar la fuerza
        Rigidbody rb = objetoDisparado.GetComponent<Rigidbody>();

        // Aplica una fuerza al objeto para dispararlo hacia la izquierda
        if (rb != null)
        {
            rb.AddForce(-puntoDeDisparo.right * fuerzaDeDisparo, ForceMode.Impulse);
        }
    }
}
