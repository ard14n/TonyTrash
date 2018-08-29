using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    private LeftDoor LeftDoor;
    private RightDoor RightDoor;
    
    
    // Use this for initialization
    void Start () {

        LeftDoor = GameObject.Find("LeftPivot").GetComponent<LeftDoor>();
        RightDoor = GameObject.Find("RightPivot").GetComponent<RightDoor>();
		
	}
	
    void OnTriggerEnter(Collider other)
    {   

        if(other.gameObject.tag == "DoorOpenerSphere")
        {
            LeftDoor.setOpened();
            RightDoor.setOpened();
        }
        

    }
}
