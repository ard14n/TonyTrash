using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Die Platform wird zum "Parent" des Players, sobald dieser auf der Platform steht. 
 * Somit bewegt sich der Player mit der Platform mit. 
 * Josephine Eckhoff
 **/

public class Stay : MonoBehaviour {

    public GameObject Player;

   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
