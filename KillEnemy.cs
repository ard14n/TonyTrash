using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Zuweisung des Colliders um Genger zu besiegen, wenn man ihn von oben trifft
 * 
 * Marc Rosenkranz
 * */

public class KillEnemy : MonoBehaviour {

    public SphereCollider killEnemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Destroy(transform.parent.gameObject);

        }

    }
}
