using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;
    private float launchForce;
    private float torqueForce;
    private Vector2 targetPosition;
    public ParticleSystem explosion;

    private float spawnRange = 4.5f;
    private float minSpeed = 5f;
    private float maxSpeed = 20f;
    public int scoreValue;

    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb.useGravity = false;
        LaunchTarget();
    }



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2)
        {
            Destroy(gameObject); 
        }

        if (transform.position.y < -2 && gameObject.CompareTag("Good"))
        {
            gameManager.isGameActive = false;
            gameManager.GameOver();
        }
    }


    private void LaunchTarget()
    {
        rb.useGravity = true;
        launchForce = Random.Range(minSpeed, maxSpeed);
        torqueForce = Random.Range(minSpeed, maxSpeed);
        targetPosition = new Vector2(Random.Range(-spawnRange, spawnRange), -0.15f);

        rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(1, 1, 1) * torqueForce, ForceMode.Impulse);
        transform.position = targetPosition;
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.ScoreUpdate(scoreValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            explosion.Play();
        }

        if (gameObject.CompareTag("Restart Button"))
        {
            gameManager.RestartGame();
        }
    }
}
