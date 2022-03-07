using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalInput;
    [SerializeField] float horizontalInput;
    [SerializeField] public float speed;
    [SerializeField] public float turnSpeed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        
    }

    private void FixedUpdate()
    {
        
        rb.AddForce(Vector3.forward * verticalInput * speed, ForceMode.Acceleration);

        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        
    }
}
