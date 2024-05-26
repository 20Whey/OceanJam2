using System;
using UnityEngine;
using rand=UnityEngine.Random;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public CameraBoundsCalculator cameraBoundsCalculator;
    public float spawnDistance = 2.0f; // Distance from the camera bounds to spawn enemies
    public TimerScript timerScript;
    public GameObject[] enemyArray;
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
       // int upperBound = 0;
        GameObject Enemy = enemyArray[rand.Range(0, 5)];
        ObjectPoolManager.SpawnObject(Enemy, spawnPosition, Quaternion.identity, ObjectPoolManager.PoolType.Enemies);
        //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition(Bounds bounds)
    {
        float randomValue = rand.value;
        float spawnX, spawnY;

        // Determine if enemy should spawn on the left/right or top/bottom
        if (randomValue < 0.5f)
        {
            // Spawn on left or right side
            spawnX = (rand.value < 0.5f) ? bounds.min.x - spawnDistance : bounds.max.x + spawnDistance;
            spawnY = rand.Range(bounds.min.y, bounds.max.y);
        }
        else
        {
            // Spawn on top or bottom side
            spawnX = rand.Range(bounds.min.x, bounds.max.x);
            spawnY = (rand.value < 0.5f) ? bounds.min.y - spawnDistance : bounds.max.y + spawnDistance;
        }

        return new Vector3(spawnX, spawnY, 0);
    }
}
