using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Öffnet die Rechte Tür des Gates 
	Ardian Jahja - 342047
*/


public class RightDoor : MonoBehaviour {

    private bool isOpened = false;
    float smooth = 1.0f;
    float DoorOpenAngleRight = 90.0f;


    // Update is called once per frame
    void Update() {

        if (isOpened) {

            var targetRight = Quaternion.Euler(0, DoorOpenAngleRight, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRight, Time.deltaTime * smooth);
            
        }

    }

    public void setOpened(){

        isOpened = true;

    }
}
