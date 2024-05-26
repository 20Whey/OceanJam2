using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    {
    public float playerRotateSpeed = 0.3f;
    public PlayerStats playerStats;
    public HealthScript healthScript;

    //missile objects
    public GameObject missilePoint;
    public GameObject missilePrefab;
    public bool firingMissiles = false;

    //bullet objects
    public Transform bulletSpawnPoint;
    public GameObject bulletObject;
    public float bulletSpeed = 10;

    private GameObject axes;
    private GameObject shield;

    public bool playerShielded = false;

    private float abilityTimer;
    private Vector2 moveDirection;
    private Rigidbody playerRB;
    private bool Stunned;

    void Start()
    {
        axes = transform.GetChild(2).gameObject;
        shield = transform.GetChild(3).gameObject;
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
            Axes();
            Shield();
            if (firingMissiles == false)
			{
                Missile();
			}
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
        if (playerStats.playerHealth > playerStats.playerMaxHealth)
		{
            playerStats.playerHealth = playerStats.playerMaxHealth;
        }
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
        if (CheckIfUnlocked(PlayerAbilities.Dash) == true)
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

    void Missile()
	{
        if (CheckIfUnlocked(PlayerAbilities.Missile) == true)
        {
            firingMissiles = true;
            InvokeRepeating("MissileFire", 2.0f, playerStats.playerMissileRate);
        }
    }
    void Axes()
	{
        if (CheckIfUnlocked(PlayerAbilities.Axes) == true)
        {
            axes.SetActive(true);
        }
    }

    void Shield()
	{
        if (CheckIfUnlocked(PlayerAbilities.Shield) == true)
        {
            shield.SetActive(true);
        }
    }
    void MissileFire()
	{
        ObjectPoolManager.SpawnObject(missilePrefab, missilePoint.transform.position, Quaternion.identity);
    }

    private bool CheckIfUnlocked(PlayerAbilities ability)
	{
		if (playerStats.unlockedAbilities.Contains(ability))
		{
            return true;
		}
		else
		{
            return false;
		}
	}
}
