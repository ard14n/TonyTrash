using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameTrigger : MonoBehaviour {

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        if (other.name == "Kugel") {

            Debug.Log("Kugel hat Ziel erreicht");
            GameObject.Find("DynamicPivotPoint").GetComponent<MiniGameController>().SetMiniGameWon();
            
        }
    }
}
