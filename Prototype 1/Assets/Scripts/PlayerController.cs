using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalInput;
    [SerializeField] float horizontalInput;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] public float horsePower;
    [SerializeField] public float turnSpeed;
    [SerializeField] GameObject centerOfMass;
    public GameObject ground;
    public TextMeshProUGUI speedometerText;
    public TextMeshProUGUI rpmText;
    Rigidbody rb;

    const float wheelRadius = 37;
    const float wheelCircumference = wheelRadius * 2 * 3.14f;

    [SerializeField] bool isOnGround;

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
        if (isOnGround && verticalInput != 0)
        {
            rb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
        
        }

        speed = Mathf.Round(rb.velocity.magnitude * 3.6f);
        rpm = Mathf.Round((speed % 30) * 40);

        speedometerText.text = "Km/h: " + speed.ToString();
        rpmText.text = "RPM: " + rpm.ToString();

        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);






    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isOnGround = false;

        }
    }
}
