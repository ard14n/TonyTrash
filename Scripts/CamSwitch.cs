using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Skript zum Wechsel zwischen FPS und TPS Camera
 * 
 * Marc Rosenkranz
 * */

public class CamSwitch : MonoBehaviour {

    public Camera FpsCam;
    public Camera TpsCam;
    bool fpsCam = false;

	// Use this for initialization
	void Start () {
        FpsCam.enabled = fpsCam;
        TpsCam.enabled = !fpsCam;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            fpsCam = !fpsCam;
            FpsCam.enabled = fpsCam;
            TpsCam.enabled = !fpsCam;
        }
		
	}
}
