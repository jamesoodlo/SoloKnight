using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnPoint : MonoBehaviour
{
    GameManager gameManager;
    public int unlockEnemeis;
    public int numOfEnemies;
    public int minEnemies;
    public int maxEnemies;
    public GameObject[] enemiesPrefab;
    void Awake()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    void Start()
    {
        numOfEnemies = Random.Range(minEnemies, maxEnemies);
    }

    void Update()
    {
        maxEnemies = gameManager.numOfWave;
        numOfEnemies = Random.Range(minEnemies, maxEnemies);
    }

    public void InstantiateObjectsAtRandomPoints()
    {
        if (numOfEnemies > 0)
        {
            int randomPrefabIndex = Random.Range(0, unlockEnemeis);

            GameObject instantiatedEnemies = Instantiate(enemiesPrefab[randomPrefabIndex], transform.position, Quaternion.identity);

            numOfEnemies -= 1;
        }
    }
}
