using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigo : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Heroe")
        {
            Debug.Log("Heroe detected - attack!");
        }
    }
   
    void OnTriggerExit(Collider other)
    {
        
        if (other.name == "Heroe")
            Debug.Log("Heroe out of range, resume patrol");
    }

}
