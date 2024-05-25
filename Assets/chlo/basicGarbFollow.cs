using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGarbFollow : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public float moveSpeed = 1000f;
    public float maxForce = 10f; // Maximum force that can be applied

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Ensure the target is not null
        if (target != null)
        {
            transform.LookAt(target);

            // Calculate the force to be applied
            Vector3 force = transform.forward * moveSpeed * Time.deltaTime;

            // Clamp the force to the maximum limit
            if (force.magnitude > maxForce)
            {
                force = force.normalized * maxForce;
            }

            // Apply the clamped force
            rb.AddForce(force);
        }
    }
}
