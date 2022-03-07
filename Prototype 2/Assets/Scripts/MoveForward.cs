using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 30;
    float topBound = 30;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveForwardOnSpawn();
        
    }

    private void MoveForwardOnSpawn()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
