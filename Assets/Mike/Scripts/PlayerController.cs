using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerHealth = 100f;
    public float playerDamage = 10f;
    public float playerAcceleration = 10f;
    public float playerRotateSpeed = 0.3f;
    public float dashBoost = 1.5f;

    private Vector2 moveDirection;
    private Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        RotatePlayer();
        Dash();

    }

	void FixedUpdate()
	{
        playerRB.AddForce(moveDirection * playerAcceleration);
	}

    void RotatePlayer()
	{
        //Face Mouse
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotateAngle = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateAngle, playerRotateSpeed);
    }

    void Dash()
	{
        if (Input.GetKey(KeyCode.Space))
        {
            playerRB.AddForce(moveDirection * dashBoost, ForceMode.Impulse);
        }
	}
}
