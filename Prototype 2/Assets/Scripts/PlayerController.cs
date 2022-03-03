using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 10;
    float horizontalInput;
    float verticalInput;
    float xRange = 28;
    Vector3 playerMovement;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");   
        Shoot();

    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        playerMovement = new Vector3(horizontalInput * Time.deltaTime * speed, 0, 0);

        // Keeps player in bounds by teleporting him to the other side if out of bounds.
        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            transform.position = new Vector3(transform.position.x * -0.9f, 0, 0);
        }
        else
        {
            transform.Translate(playerMovement);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
