using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI minusHPText;
    private float initialPlayerHealth = 10;
    private float currentPlayerHealth;
    private float healthDecreaseNumber = 1;
    private float healthBarFill;
    private float increseValue = 0;

    private void Start() 
    {
        currentPlayerHealth = initialPlayerHealth;
    }

    private void Update() 
    {
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        healthBarFill = currentPlayerHealth / initialPlayerHealth + increseValue;
        healthSlider.GetComponent<Slider>().value = healthBarFill; 
    }

    public void DecreaseHealth()
    {
        currentPlayerHealth -= healthDecreaseNumber;
        ShowHealthDecrease();
        if(currentPlayerHealth <= 0)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    IEnumerator DisplayHit()
    {
        float minusHPValue = healthDecreaseNumber;
        minusHPText.text = "-" + minusHPValue.ToString();
        yield return new WaitForSeconds(0.5f);
        minusHPText.text = String.Empty;
    }

     private void ShowHealthDecrease()
    {
        StartCoroutine(DisplayHit());
    }

    public void IncreasePlayerHealth()
    {
        increseValue = 3;
        currentPlayerHealth += increseValue;
    }
}
