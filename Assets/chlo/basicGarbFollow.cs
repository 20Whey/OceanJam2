using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class basicGarbFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed of the enemy movement

    void Start()
    {
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
            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.LookAt(player);

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
