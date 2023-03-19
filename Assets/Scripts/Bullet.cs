using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SoftPointsManager softPointsManager;
    private Rigidbody rb;
    private float bulletSpeed;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        softPointsManager = FindObjectOfType<SoftPointsManager>();
    }

    private void Start() 
    {
        bulletSpeed = softPointsManager.GetAttackSpeed();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        rb.velocity = new Vector3(bulletSpeed, 0, 0);
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}
