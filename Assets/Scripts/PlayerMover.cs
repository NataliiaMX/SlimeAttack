using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform emitter;
    [SerializeField] private GameObject bullet;
    private Rigidbody rb;
    private float moveSpeed = -5;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, emitter.transform.position, transform.rotation);
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0));
    }
}
