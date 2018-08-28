using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 	
	Wird dem HealthPowerUp-GameObject gegeben, 
	damit man es einsammeln kann
	und damit es dem Spieler ein Leben hinzufügt
	Ardian Jahja - 342047
*/

public class HealthPowerUp : MonoBehaviour {

    private GameObject player;
        
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.Find("Player");
            player.GetComponent<Inventory>().AddLife();
            //Debug.Log("Player ist um 1 Leben geheilt worden");
            Destroy(gameObject);
           
        }
    }
}
