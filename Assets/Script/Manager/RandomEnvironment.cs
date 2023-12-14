using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnvironment : MonoBehaviour
{
    public GameObject[] environmentPrefabs;
    public int numberOfElements = 10;
    public Vector3 minBounds;
    public Vector3 maxBounds;

    void Start()
    {
        InstantiateEnvironment();
    }

    void InstantiateEnvironment()
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            float randomX = Random.Range(minBounds.x, maxBounds.x);
            float randomZ = Random.Range(minBounds.z, maxBounds.z);

            Vector3 randomPosition = new Vector3(Random.Range(-32, 32), 0f, Random.Range(-32, 32));

            int randomPrefabIndex = Random.Range(0, environmentPrefabs.Length);

            Instantiate(environmentPrefabs[randomPrefabIndex], randomPosition, Quaternion.identity);
        }
    }
}
