using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject vehicle;
    Vector3 vehiclePos;
    Vector3 thirdPerson;
    Vector3 firstPerson;
    Vector3 frontView;
    Quaternion cameraFrontViewRot;
    Quaternion cameraRotReset;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] bool fpCamera;

    private void Start()
    {
        thirdPerson = new Vector3(0, 5, -10);
        firstPerson = new Vector3(-0.50f, 2.2f, 0.2f);
        frontView = new Vector3(0f, 5f, 8.75f);
        cameraFrontViewRot = new Quaternion(0, 180, 0, 0);
        cameraRotReset = new Quaternion();
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

        if (Input.GetKey(KeyCode.G) && !fpCamera)
        {
            cameraOffset = frontView;
            gameObject.transform.rotation = cameraFrontViewRot;
        }
        else
        {
            cameraSwitch();
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
            gameObject.transform.rotation = cameraRotReset;
        }
        if (fpCamera)
        {
            cameraOffset = firstPerson;
            gameObject.transform.rotation = cameraRotReset;
        }
        
    }

}
