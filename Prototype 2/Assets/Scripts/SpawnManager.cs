using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    int animalIndex;
    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;



    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
    }


    void Update()
    {
        

    }

    private void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 animalSpawnPosition = new Vector3(Random.Range(-21, 22), 0, 21);
        Instantiate(animalPrefabs[animalIndex], animalSpawnPosition, animalPrefabs[animalIndex].transform.rotation);

    }
}
