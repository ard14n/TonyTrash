using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampGate : MonoBehaviour {

    public bool isOpenend = false;
    private bool lerpDone = false;
    private Vector3 targetPos;
    private Vector3 startPos;

    private float c;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
        targetPos = new Vector3(startPos.x, 0, startPos.z);
        c = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (isOpenend) {

            /*Vector3 currentPos = transform.position;
            float distance = Vector3.Distance(currentPos, targetPos);
            float distanceCovered = (Time.time - startTime) * 3f;

            float frac = distanceCovered / distance;*/

            if(c <= 50) {

                float t = c / (float) 50;

                transform.position = Vector3.Lerp(startPos, targetPos, t);

                c+=0.2f;

            } else if ( c > 50) {

                GameObject.Find("Ramp").GetComponent<BezierCurve>().ActivateTrigger();

            }

            

        }

	}

    public void OpenRampGate() {

        //startTime = Time.time;
        this.isOpenend = true;

    }
}
