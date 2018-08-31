using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

    private LeftDoor LeftDoor;
    private RightDoor RightDoor;
    
    
    // Use this for initialization
    void Start () {

        LeftDoor = GameObject.Find("LeftPivot").GetComponent<LeftDoor>();
        RightDoor = GameObject.Find("RightPivot").GetComponent<RightDoor>();
		
	}

    public void OpenDoors() {
        LeftDoor.setOpened();
        RightDoor.setOpened();
    }
	
    
}
