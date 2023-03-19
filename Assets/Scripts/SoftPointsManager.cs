using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftPointsManager : MonoBehaviour
{
    private SoftPointsIncreaser softPoints;
    private PlayerHealth playerHealth;
    private float attackValue = 1;
    private float attackSpeed = 5f;
    private float attackSpeedIncrease = 10f;

    private void Start() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        softPoints = FindObjectOfType<SoftPointsIncreaser>();
    }

    public void IncreaseAttackSpeed()
    {
        softPoints.DecreaseSoftPoints(5);
        attackSpeed += attackSpeedIncrease;
    }
    public void IncreaseAttackValue()
    {
        softPoints.DecreaseSoftPoints(7);
        attackValue++;
    }

    public void IncreaseHealth()
    {
        softPoints.DecreaseSoftPoints(10);
        playerHealth.IncreasePlayerHealth();
    }

    public float GetAttackValue()
    {
        return attackValue;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
}
