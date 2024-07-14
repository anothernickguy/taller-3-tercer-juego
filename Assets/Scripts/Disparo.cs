using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Disparo : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform direccionTransform;
    public GameObject balaPrefab;
    public UnityEvent OnEnter;

    public float fuerzaMaxima;
    float tiempoDeCarga;
    public float tiempoMaximoCarga;

    float fuerzaDisparo;
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // cargando disparo
            tiempoDeCarga+= Time.deltaTime;
            tiempoDeCarga = Mathf.Clamp(tiempoDeCarga, 0, tiempoMaximoCarga);
        }

        if(Input.GetMouseButtonUp(0))
        {
            // disparar
            float porcentajeFuerza = tiempoDeCarga / tiempoMaximoCarga;
            fuerzaDisparo = fuerzaMaxima * porcentajeFuerza;

            tiempoDeCarga = 0;

            DispararBala();
            OnEnter.Invoke();
        }
    }

    void DispararBala()
    {
        GameObject balaTemp = Instantiate(balaPrefab);
        balaTemp.transform.position = spawnPoint.position;

        Rigidbody2D rbTemp = balaTemp.GetComponent<Rigidbody2D>();
        rbTemp.AddForce(direccionTransform.right * fuerzaDisparo, ForceMode2D.Impulse);
    }
}
