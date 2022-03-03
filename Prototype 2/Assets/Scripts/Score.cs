using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    int missedAnimals = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (missedAnimals == 2)
        {
            SceneManager.LoadScene(1); 
        }
        else if (missedAnimals != 2)
        {
            missedAnimals++;
        }                       
    }

}
