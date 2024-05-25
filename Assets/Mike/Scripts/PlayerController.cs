using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    {
    public float playerHealth = 100f;
    public float playerDamage = 10f;
    public float playerAcceleration = 10f;

    private Vector2 moveDirection;
    private Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

	void FixedUpdate()
	{
        playerRB.AddForce(moveDirection * playerAcceleration);
	}
}
