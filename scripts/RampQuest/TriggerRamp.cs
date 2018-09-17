using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRamp : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().material.color = Color.red;

	}
	
	// Update is called once per frame
	void Update () {
		


	}


    void OnTriggerEnter(Collider col){

        GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("Ramp").GetComponent<BezierCurve>().ActivateTrigger();

    }
}
