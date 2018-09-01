using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {


    private GameObject platformManager;

	
    void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {

            GameObject.Find("Platform").GetComponent<PlatformManagerMiniGame>().SetPlatformMoveUp();

        }

    }

}
