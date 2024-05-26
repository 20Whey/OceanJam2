using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : MonoBehaviour
{
    public int dmg;
    public GameObject eBullet;
    public Transform player;
    public float speed = 5f; // Speed of the enemy movement
    private bool nTm;
    private sillyStuff SillyStuff;
    public HealthScript healthScript;

    public Transform bulletSpawnPoint;
    private bool hasFired;

    public float bulletSpeed;
    void Start()
    {
        hasFired = false;
        dmg = 8;
        healthScript = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthScript>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform; // Find the player by tag if not set
        }

    }

    void Update()
    {
        nTm = gameObject.GetComponent<sillyStuff>().tm;
        if (nTm == false)
        {
            MoveTowardsPlayer();
        }
        transform.LookAt(player);

    }

    void MoveTowardsPlayer()
    {
        float f = Vector3.Distance(transform.position, player.position);
        
        if (f > 10.0f)
        {
            //gameObject.transform.LookAt(player.transform);
            if (player != null && nTm == false)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        else if (!hasFired)
        {
           // Vector3 direction = (player.position - transform.position).normalized;
            transform.LookAt(player);
            Invoke("spawnBul", 3.0f);
            hasFired = true;

        }


    }
    private void spawnBul()
    {
        GameObject bullet = ObjectPoolManager.SpawnObject(eBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, ObjectPoolManager.PoolType.Projectiles);
        bullet.GetComponent<enemyBullet>().SillyStuff = SillyStuff;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        hasFired = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthScript.TakeDamage(10);
        }
    }
}
