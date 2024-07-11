using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour, Damagable
{
    public int hp = 200; // HP inicial configurado a 200
    public UnityEvent onHit, onMuere;
    public bool destruirAlMorir;
    public Slider hpSlider; // Referencia al Slider que mostrará el HP

    void Start()
    {
        // Actualiza el valor inicial del slider al valor inicial de hp
        UpdateSliderValue();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        CheckHP();
        UpdateSliderValue(); // Actualiza el slider después de recibir daño
    }

    void CheckHP()
    {
        if (hp <= 0)
            Muere();
    }

    void Muere()
    {
        onMuere.Invoke();
        if (destruirAlMorir) Destroy(gameObject);
    }

    void UpdateSliderValue()
    {
        // Asegura que el valor de hp esté dentro del rango de 0 a 200
        int currentHP = Mathf.Clamp(hp, 0, 200);

        // Calcula el valor normalizado para el slider (entre 0 y 1)
        float sliderValue = (float)currentHP / 200f;

        // Actualiza el valor del slider
        hpSlider.value = sliderValue;
    }
}
