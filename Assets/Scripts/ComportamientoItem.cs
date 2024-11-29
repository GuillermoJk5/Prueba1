using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoItem : MonoBehaviour
{
   public ComportamientoGame ComportamientoGame;

    void Start() {

        ComportamientoGame = GameObject.Find("GameManager").GetComponent<ComportamientoGame>();
    }

    void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.name == "Heroe")
        {
            
            Destroy(this.transform.gameObject);
            
            Debug.Log("Item collected!");
            ComportamientoGame.Items += 1;
        }
    }

}
