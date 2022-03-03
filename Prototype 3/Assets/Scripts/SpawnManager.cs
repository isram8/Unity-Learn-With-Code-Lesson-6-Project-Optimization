using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacle;
    public PlayerController playerControllerScript;

    Vector3 spawnLocation = new Vector3(25, 0, 0);
    float spawnDelay = 1;
    float spawnInterval = 2;
    int randomSpawn;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            randomSpawn = Random.Range(0, 4);
            Instantiate(obstacle[randomSpawn], spawnLocation, obstacle[randomSpawn].transform.rotation);
        }
        
    }
}
