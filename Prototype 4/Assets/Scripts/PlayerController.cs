using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    GameObject focalPoint;
    public GameObject powerUpRing;
    SpawnManager spawnManager;

    public bool hasPowerUp = false;
    public float speed = 0.1f;
    public float powerUpStrength = 20;
    int powerUpTime = 7;
    Vector3 vectorAwayFromPlayer;
    

    private void Start()
    {
        focalPoint = GameObject.Find("Camera Focal Point");
        rb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
    }
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        }

        //Power up indicator positioning on player
        powerUpRing.transform.Rotate(Vector3.up, 0.5f);
        powerUpRing.transform.position = new Vector3(transform.position.x,
                                                     transform.position.y - 0.2f,
                                                     transform.position.z);

        if (transform.position.y < -30)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerUpRing.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            hasPowerUp = true;
            spawnManager.powerUpCount = spawnManager.powerUpCount - 1;
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp)
        {
            vectorAwayFromPlayer = collision.gameObject.transform.position - transform.position;
            collision.rigidbody.AddForce(vectorAwayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        if (hasPowerUp)
        {
            powerUpTime += powerUpTime;
        }
        yield return new WaitForSeconds(powerUpTime);
        hasPowerUp = false;
        powerUpRing.gameObject.SetActive(false);
        powerUpTime = 7;
    }
}
