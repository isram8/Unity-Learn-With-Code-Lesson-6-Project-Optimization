using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public int dogCount = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (dogCount < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            dogCount++;
        }

        Debug.Log(dogCount);
    }
}
