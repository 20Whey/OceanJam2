using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeOrbit : MonoBehaviour
{
    GameObject player;
    Transform center;
    public Vector3 axis = Vector3.forward;
    public Vector3 desiredPosition;
    public float radius;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    void Start()
    {
        player = GameObject.FindWithTag("orbitpiv");
        center = player.transform;
        transform.position = (transform.position - center.position).normalized * radius + center.position;

    }

    void Update()
    {
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radiusSpeed);
    }
}