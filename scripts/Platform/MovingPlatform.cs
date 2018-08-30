using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Die Platform bewegt sich von einem Startpunkt zu einem Endpunkt und wieder zurück.
 * Josephine Eckhoff
 **/

public class MovingPlatform : MonoBehaviour {

    public Transform Platform1;
    public Transform PosA;
    public Transform PosB;
    public Vector3 newPos;
    public int current;
    public float reset = 3;

	// Use this for initialization
	void Start () {
        MovePlatform();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Platform1.position = Vector3.Lerp (Platform1.position, newPos, Time.deltaTime);
    }

    void MovePlatform()
    {
        if (current == 1)
        {
            current = 2;
            newPos = PosB.position;
        }
        else if (current == 2)
        {
            current = 1;
            newPos = PosA.position;
        }
        else if (current == 0)
        {
            current = 2;
            newPos = PosB.position;
        }
        Invoke ("MovePlatform", reset);
    }
}
