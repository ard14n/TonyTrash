using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrells : MonoBehaviour {

	
    void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "RoadBarrellStop"){

            Destroy(gameObject);

        }

    }
}
