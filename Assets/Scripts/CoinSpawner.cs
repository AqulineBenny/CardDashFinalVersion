using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 0.20f;
    public float spawnRangeX = 5.0f;
    public float spawnHeight = 1.0f;
    public float spawnZStart = 10.0f;
    public float stopZPosition = 50.0f;

    private float spawnZ;
    private List<GameObject> spawnedCoins = new List<GameObject>();

    void Start()
    {
        ResetSpawning();
    }

    IEnumerator SpawnCoins()
    {
        while (spawnZ < stopZPosition)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            spawnZ += Random.Range(5.0f, 10.0f);

            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, spawnZ);
            GameObject spawnedCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            spawnedCoins.Add(spawnedCoin); // Add to the list
            Destroy(spawnedCoin, 20.0f);
        }
    }

    public void ResetSpawning()
    {
        StopAllCoroutines();
        ClearSpawnedObjects(); // Remove existing coins
        spawnZ = spawnZStart;
        StartCoroutine(SpawnCoins());
    }

    private void ClearSpawnedObjects()
    {
        foreach (GameObject coin in spawnedCoins)
        {
            if (coin != null)
            {
                Destroy(coin);
            }
        }
        spawnedCoins.Clear();
    }
}
