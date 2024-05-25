using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public CameraBoundsCalculator cameraBoundsCalculator;
    public float spawnDistance = 2.0f; // Distance from the camera bounds to spawn enemies
    public TimerScript timerScript;
    void Start()
    {
        if (cameraBoundsCalculator == null)
        {
            cameraBoundsCalculator = FindObjectOfType<CameraBoundsCalculator>();
        }

        InvokeRepeating("SpawnEnemy", 2.0f, timerScript.difficulty); // Example: spawn an enemy every 5 seconds
    }

    void SpawnEnemy()
    {
        Bounds bounds = cameraBoundsCalculator.GetCameraBounds();
        Vector3 spawnPosition = GetRandomSpawnPosition(bounds);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition(Bounds bounds)
    {
        float randomValue = Random.value;
        float spawnX, spawnY;

        // Determine if enemy should spawn on the left/right or top/bottom
        if (randomValue < 0.5f)
        {
            // Spawn on left or right side
            spawnX = (Random.value < 0.5f) ? bounds.min.x - spawnDistance : bounds.max.x + spawnDistance;
            spawnY = Random.Range(bounds.min.y, bounds.max.y);
        }
        else
        {
            // Spawn on top or bottom side
            spawnX = Random.Range(bounds.min.x, bounds.max.x);
            spawnY = (Random.value < 0.5f) ? bounds.min.y - spawnDistance : bounds.max.y + spawnDistance;
        }

        return new Vector3(spawnX, spawnY, 0);
    }
}
