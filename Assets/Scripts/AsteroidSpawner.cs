using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class AsteroidSpawner : MonoBehaviour
{
    List<GameObject> spawnPositions;
    
    [SerializeField] List<GameObject> asteroidsPrefabs;
    
    void Awake()
    {
        spawnPositions = new List<GameObject>();
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child.gameObject);
        }
    }

    void Start()
    {
        //Invoracará a função "SpawnAsteroid" no instante "0" e em seguida a cada 1 segundo.
        InvokeRepeating("SpawnAsteroid", 0, 1);
    }


    void SpawnAsteroid()
    {
        //A função Random.Range gera número aleatórios entre "min" e "max" (aberto). 
        int randomAsteroid = Random.Range(0, asteroidsPrefabs.Count);
        int randomPos = Random.Range(0, spawnPositions.Count);

        Instantiate(asteroidsPrefabs[randomAsteroid], spawnPositions[randomPos].transform.position, Quaternion.identity);
    }
}
