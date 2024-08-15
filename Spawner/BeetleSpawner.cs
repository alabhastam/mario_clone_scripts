using System.Collections;
using UnityEngine;

public class BeetleSpawner : MonoBehaviour
{
    public GameObject beetlePrefab; // Reference to the Beetle prefab
    public Transform player; // Reference to the player
    public float spawnRadius = 5f; // Distance from the player to spawn
    public float minSpawnInterval = 2f; // Minimum time between spawns
    public float maxSpawnInterval = 6f; // Maximum time between spawns

    void Start()
    {
        StartCoroutine(SpawnBeetle());
    }

    IEnumerator SpawnBeetle()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnDelay);

            Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(beetlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
