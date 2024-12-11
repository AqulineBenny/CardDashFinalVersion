using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnerZ : MonoBehaviour
{
    public GameObject rockPrefab;
    public float spawnInterval = 0.05f;
    public float spawnRangeX = 5.0f;
    public float spawnHeight = 1.0f;
    public float spawnZStart = 10.0f;
    public float stopZPosition = 180.0f;
    public int totalObstacles = 10;

    private float spawnZ;
    private int obstacleCount = 0;
    private List<GameObject> spawnedRocks = new List<GameObject>();

    void Start()
    {
        ResetSpawning();
    }

    IEnumerator SpawnRocks()
    {
        while (obstacleCount < totalObstacles)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            spawnZ += Random.Range(15.0f, 20.0f);

            if (spawnZ > stopZPosition)
                break;

            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, spawnZ);
            GameObject spawnedRock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
            spawnedRocks.Add(spawnedRock); // Add to the list
            Destroy(spawnedRock, 8.0f);

            obstacleCount++;
        }
    }

    public void ResetSpawning()
    {
        StopAllCoroutines();
        ClearSpawnedObjects(); // Remove existing obstacles
        spawnZ = spawnZStart;
        obstacleCount = 0;
        StartCoroutine(SpawnRocks());
    }

    private void ClearSpawnedObjects()
    {
        foreach (GameObject rock in spawnedRocks)
        {
            if (rock != null)
            {
                Destroy(rock);
            }
        }
        spawnedRocks.Clear();
    }
}
