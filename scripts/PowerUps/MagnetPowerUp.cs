﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 	
	Wird dem MagnetPowerUp-GameObject gegeben, 
	damit man es einsammeln kann
	und damit es im Inventar gespeichert wird
	Ardian Jahja - 342047
*/

public class MagnetPowerUp : MonoBehaviour {

    private GameObject player;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.Find("Player");
            player.GetComponent<Inventory>().AddMagnet();
            Destroy(gameObject);
            
        }
    }

}
