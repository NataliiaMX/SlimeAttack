using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private Transform target;
    private Animator animator;
    private PlayerHealth playerHealth;
    private float distanceToTarget = Mathf.Infinity;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        AttackPlayer();
    }


    private void AttackPlayer()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (distanceToTarget <= attackRange)
            {
                isAttacking = true;
                animator.SetBool("Attacks", true);
            }
            else if (distanceToTarget > attackRange)
            {
                isAttacking = false;
                animator.SetBool("Attack", false);
            }
        }
    }

    public void HitPlayer()
    {
        if (playerHealth != null && isAttacking)
        {
          playerHealth.DecreaseHealth();  
        }
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
