using UnityEngine;

public class MissileMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which to move towards the enemy
    public int damage;
    private GameObject[] enemies;
    private Transform targetEnemy;
    void Start()
    {
        // Find all enemies with the tag "Enemy" in the scene
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            // Select a random enemy
            int randomIndex = Random.Range(0, enemies.Length);
            targetEnemy = enemies[randomIndex].transform;
        }
        else
        {
            Debug.LogWarning("No enemies found with the tag 'Enemy' in the scene.");
        }
    }

    void Update()
    {
        if (targetEnemy != null)
        {
            // Move towards the target enemy
            Vector3 direction = (targetEnemy.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Optional: Rotate to face the enemy
            Vector3 lookDirection = targetEnemy.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
