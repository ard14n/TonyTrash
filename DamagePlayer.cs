using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Collider um Gegnerkontakt zu steuern, mit verschiedenen Schadenswerten.
 * Manipulation der Health-Werte in Health Script, sowie Knockback in Movement Script.
 * Marc Rosenkranz
 **/

public class DamagePlayer : MonoBehaviour {

    public int damageFromEnemy = 1;
    public BoxCollider damagePlayer;

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

            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            FindObjectOfType<Health>().HurtPlayer(damageFromEnemy, hitDirection);

        } 
            
     }
}
