using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalInput;
    [SerializeField] float horizontalInput;
    [SerializeField] public float horsePower;
    [SerializeField] public float turnSpeed;
    [SerializeField] GameObject centerOfMass;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        
    }

    private void FixedUpdate()
    {
        
        rb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
        
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        
    }
}
