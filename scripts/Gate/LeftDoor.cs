using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Öffnet die Linke Tür des Gates 
	Ardian Jahja - 342047
*/

public class LeftDoor : MonoBehaviour {

    private bool isOpened = false;
    float smooth = 1.0f;
    float DoorOpenAngleLeft = -90.0f;

    // Update is called once per frame
    void Update() {

        if (isOpened) {

            var targetLeft = Quaternion.Euler(0, DoorOpenAngleLeft, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smooth);

        }

    }

    public void setOpened() {

        isOpened = true;

    }
}
