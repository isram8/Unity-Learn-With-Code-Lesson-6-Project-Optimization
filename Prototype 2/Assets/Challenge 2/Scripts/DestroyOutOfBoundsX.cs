using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -46;
    private float bottomLimit = -5;
    private PlayerControllerX pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerControllerX>();
    }

    void Update()
    {
        
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
            pc.dogCount = 0;
            
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
