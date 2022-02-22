using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward);      
    }
}
