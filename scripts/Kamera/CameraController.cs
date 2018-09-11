using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** 
 * Third Person Camera Controller, bei welchem die Camera um ein Pivot dreht, welches mit dem Player Model geparented ist.
 * Steuerung der Kamera erfolgt über die Maus - Code nimmt Rotationswerte aus den X und Y Achsen der Mausbewegung.
 * Ebenso wird die Blickrichtung nach oben und unten gelocked.
 * 
 * 
 * Marc Rosenkranz - 143025
 **/

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float rotateSpeed;
    public Transform pivot;
    public float maxView;
    public float minView;

    // Use this for initialization
    void Start()
    {

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Freelook mit Maus
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);                                  //hoch/runter invertieren


        //Cam drehen mit offset

        float neededYAngle = pivot.eulerAngles.y;
        float neededXAngle = pivot.eulerAngles.x;
        float neededZAngle = pivot.eulerAngles.z;

        //Cam fix hoch und runter - Maximaler und Minimaler Blockwinkel auf der x-Achse.
        if (pivot.rotation.eulerAngles.x > maxView && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxView, neededYAngle, 0f);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minView)
        {
            pivot.rotation = Quaternion.Euler(360f + minView, neededYAngle, 0f);
        }

        
        
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //Cam wird am Boden gelocked, sodass sie nicht durch den Boden geht. 
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target); // Cam auf Player richten.
    }
}
