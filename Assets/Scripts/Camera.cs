using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject vehicle;
    Vector3 vehiclePos;
    Vector3 thirdPerson;
    Vector3 firstPerson;
    Quaternion cameraRotReset;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] bool fpCamera;

    private void Start()
    {
        thirdPerson = new Vector3(0, 5, -10);
        firstPerson = new Vector3(-0.50f, 2.2f, 0.2f);
        cameraRotReset = new Quaternion(0, 0, 0, 0);
        cameraOffset = thirdPerson;   
        fpCamera = false;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fpCamera ^= true;
            cameraSwitch();
            if (!fpCamera)
            {
                gameObject.transform.rotation = cameraRotReset;
            }
        }
        
        vehiclePos = vehicle.transform.position;
        gameObject.transform.position = vehiclePos + cameraOffset;
        if (fpCamera)
        {
            gameObject.transform.rotation = vehicle.transform.rotation;
        }

    }

    private void cameraSwitch()
    {
        if (!fpCamera)
        {
            cameraOffset = thirdPerson;
        }
        if (fpCamera)
        {
            cameraOffset = firstPerson;
        }
        
    }

}
