using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    {
    public float playerRotateSpeed = 0.3f;
    public PlayerStats playerStats;
    public HealthScript healthScript;

    public Transform bulletSpawnPoint;
    public GameObject bulletObject;
    public float bulletSpeed = 10;

    private float abilityTimer;
    private Vector2 moveDirection;
    private Rigidbody playerRB;
    private bool Stunned;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Stunned = gameObject.GetComponent<sillyStuff>().tm;
    }


    void Update()
    {
        if (abilityTimer > 0) abilityTimer -= Time.deltaTime;
        if (!Stunned)
        {
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            RotatePlayer();
            Dash();
            Shoot();
        }
    }

	void FixedUpdate()
	{
        playerRB.AddForce(moveDirection * playerStats.playerMoveSpeed);
	}

    void RotatePlayer()
	{
        //Face Mouse
        
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotateAngle = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateAngle, playerRotateSpeed);
    }

    public void Heal(float healAmount)
    {
        playerStats.playerHealth += healAmount;
        healthScript.updateNewHealth();
    }
    void Shoot()
	{
        if (Input.GetKey(KeyCode.Mouse1))
		{
            if (abilityTimer <= 0)
            {
                GameObject bullet = ObjectPoolManager.SpawnObject(bulletObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation, ObjectPoolManager.PoolType.Projectiles);
                bullet.GetComponent<BulletBehavior>().playerStats = playerStats;
                bullet.GetComponent<BulletBehavior>().playerController = this;
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * bulletSpeed;
                abilityTimer = playerStats.playerFireRate;
            }
		}
	}
    void Dash()
	{
        if (Input.GetKey(KeyCode.E))
        {
            if (abilityTimer <= 0)
            {
                Debug.Log("zoom");
                playerRB.AddForce(moveDirection * playerStats.playerDashLength, ForceMode.Impulse);
                abilityTimer = playerStats.playerDashRate;
            }
        }
	}
}
