using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI minusHPText;
    [SerializeField] private Transform target;
    private float moveSpeed = 2;
    private float initialEnemyHealth = 5;
    private float currentEnemyHealth;
    private float healthBarFill;
    private int softPointsIncrease = 10;
    private SoftPointsIncreaser softPoints;
    private SoftPointsManager softPointsManager;
    private EnemyAttack enemyAttack;

    private void Start() 
    {
        softPoints = FindObjectOfType<SoftPointsIncreaser>();
        enemyAttack = GetComponent<EnemyAttack>();
        softPointsManager = FindObjectOfType<SoftPointsManager>();
        currentEnemyHealth = initialEnemyHealth;
    }
    private void Update() 
    {
        Move();
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBarFill = currentEnemyHealth / initialEnemyHealth;
        healthSlider.GetComponent<Slider>().value = healthBarFill; 
    }

    private void Move()
    {
        if(enemyAttack.GetIsAttacking() == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag == "Bullet")
        {
            ProcessHit();
        }
    }

    private void ProcessHit()
    {   
        currentEnemyHealth -= softPointsManager.GetAttackValue();
        StartCoroutine(DisplayHit());
        if (currentEnemyHealth <= 0)
        {
            softPoints.IncreaseSoftPoints(softPointsIncrease);
            Destroy(gameObject);
        }
    }

    IEnumerator DisplayHit()
    {
        float minusHPValue = softPointsManager.GetAttackValue();
        minusHPText.text = "-" + minusHPValue.ToString();
        yield return new WaitForSeconds(0.5f);
        minusHPText.text = String.Empty;
    }
}
