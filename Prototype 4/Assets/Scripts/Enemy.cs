using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    Rigidbody rb;
    SpawnManager spawnManager;
    public float speed = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        Vector3 vectorToPlayer = (playerPos - transform.position);
        rb.AddForce(vectorToPlayer * speed);

        if (transform.position.y < -6)
        {      
            Destroy(gameObject);
            

        }
    }
}
