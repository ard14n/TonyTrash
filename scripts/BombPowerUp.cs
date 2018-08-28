﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 	
	Wird dem BombPowerUp-GameObject gegeben, 
	damit man es einsammeln kann
	und damit es im Inventar gespeichert wird
	Ardian Jahja - 342047
*/

public class BombPowerUp : MonoBehaviour {

    private GameObject player;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.Find("Player");
            player.GetComponent<Inventory>().AddBomb();
            Debug.Log("BombPowerUp eingesammelt");
            Destroy(gameObject);

        }
    }
}
