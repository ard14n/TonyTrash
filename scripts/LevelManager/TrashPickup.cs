using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Skript für Verhalten beim "Aufheben" der Pickups und Aufzählen des Scores
 * 
 * Marc Rosenkranz
 * */

public class TrashPickup : MonoBehaviour {

    public int value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddScore(value);    // Übergabe der Punktzahl an Game Manager für UI
            Destroy(gameObject);
        }
    }
}
