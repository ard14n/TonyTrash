using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayTrigger : MonoBehaviour {


    private bool trig = false;

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "RampBall") {

            trig = true;

        }

    }

    void FixedUpdate() {

        if (trig)
        {   
            
            GameObject.Find("RampBall").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GameObject.Find("RampBall").GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            GameObject.Find("RampBall").GetComponent<Rigidbody>().isKinematic = true;
        }
        

    }
}
