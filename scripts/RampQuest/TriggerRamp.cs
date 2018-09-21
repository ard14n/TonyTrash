using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRamp : MonoBehaviour {

	
    void OnTriggerEnter(Collider col){

        if (col.tag == "PushBoxRamp") {

            GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("RampGate").GetComponent<RampGate>().OpenRampGate();

        }
        
    }
}
