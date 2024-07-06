using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ComboSystem : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public float comboDuration = 2f;
    public int comboDamageThreshold = 5; // Umbral de combo para cambiar el valor de damage
    public int newDamageValue = 10; // Nuevo valor de damage cuando el combo alcanza el umbral

    public GameObject effectGameObject; // GameObject que se prender� y apagar�

    private int comboCount = 0;
    private Coroutine comboCoroutine;

    public UnityEvent onHighcombo;

    private void Start()
    {
        comboText.text = "Combo: " + comboCount.ToString();
    }

    public void IncreaseCombo()
    {
        comboCount++;
        comboText.text = "Combo: " + comboCount.ToString();

        if (comboCount >= comboDamageThreshold)
        {
            // Cambiar el valor de damage en el script del Proyectil
            Proyectil[] proyectiles = FindObjectsOfType<Proyectil>();
            foreach (Proyectil proyectil in proyectiles)
            {
                proyectil.damage = newDamageValue;
            }

            // Prender el GameObject de efecto
            if (effectGameObject != null)
                effectGameObject.SetActive(true);

            onHighcombo.Invoke();
        }

        if (comboCoroutine != null)
            StopCoroutine(comboCoroutine);

        comboCoroutine = StartCoroutine(ResetCombo());
    }

    IEnumerator ResetCombo()
    {
        yield return new WaitForSeconds(comboDuration);
        comboCount = 0;
        comboText.text = "Combo: " + comboCount.ToString();

        // Apagar el GameObject de efecto
        if (effectGameObject != null)
            effectGameObject.SetActive(false);
    }
}
