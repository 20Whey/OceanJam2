using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class basicGarbFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed of the enemy movement
    public HealthScript healthScript;
    void Start()
    {

        healthScript = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthScript>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform; // Find the player by tag if not set
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.LookAt(player);
            transform.position += direction * speed * Time.deltaTime;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            healthScript.TakeDamage(10);
        }
    }
}
