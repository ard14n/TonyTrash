using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour {


    /* DeCasteljau Algorithmus - Bezier Curve
       https://en.wikipedia.org/wiki/De_Casteljau%27s_algorithm
       http://www.malinc.se/m/DeCasteljauAndBezier.php

       In diesem Skript wird die kubische Bezier Curve verwendet
       4 Punkte im 3D-Raum sind hierfür notwendig.
       Davon sind 2 Punkte Start- und Endpunkt.
       Die anderen beiden sind jeweils die Kontrollpunkte.

        Ardian Jahja - 342047


    */

    private GameObject start;
    private GameObject startControl;
    private GameObject end;
    private GameObject endControl;
    private GameObject rampBall;
    
    [Header("Start")]
    public bool triggerActivated = false;

    private Vector3 oldPosition;
    private Vector3 newPosition;
    
    private float c;
    private float pointsNum = 50;

    private Rigidbody ballbody;
    private Vector3 p0, p1, p2, p3;

    private Color cblue = Color.blue;
    private Color cgreen = Color.green;
     
    void Start() {

        rampBall = GameObject.Find("RampBall");

        start = GameObject.Find("w1");
        end = GameObject.Find("w4");

        startControl = GameObject.Find("w2");
        endControl = GameObject.Find("w3");
        
        p0 = start.transform.position;
        p1 = startControl.transform.position;
        p2 = endControl.transform.position;
        p3 = end.transform.position;
       
        oldPosition = p0;
        c = 0;

        ballbody = rampBall.GetComponent<Rigidbody>();
        
    }
     
   
    //Zeichnen der Kurve mithilfe von Gizmos vor dem Start
    private void OnDrawGizmos() {

        Gizmos.color = Color.white;

        start = GameObject.Find("w1");
        end = GameObject.Find("w4");

        startControl = GameObject.Find("w2");
        endControl = GameObject.Find("w3");

        p0 = start.transform.position;
        p1 = startControl.transform.position;
        p2 = endControl.transform.position;
        p3 = end.transform.position;

        Vector3 oldPositionG = p0;
        Vector3 newPositionG = Vector3.zero;

        for (int i = 0; i < pointsNum; i++) {

            float t = i / (float) pointsNum;

            newPositionG = CalculateCubicBezierPoint(t);

            DrawLines(cgreen, oldPositionG, newPositionG);

            oldPositionG = newPositionG;

        }

        
        DrawLines(cblue, p0, p1);
        DrawLines(cblue, p2, p3);

    }


    private void DrawLines(Color color, Vector3 p0, Vector3 p1) {

        Gizmos.color = color;
        Gizmos.DrawLine(p0, p1);
        
    }

    //Diese Funktion gibt einen Vector3-Punkt auf der Kurve mithilfe des Bezier-Algorithmus zurück 
    private Vector3 CalculateCubicBezierPoint(float t) {

        return Mathf.Pow((1f - t), 3) * p0 + 3 * Mathf.Pow((1 - t), 2) * t * p1 + 3 * (1 - t) * Mathf.Pow(t, 2) * p2 + Mathf.Pow(t, 3) * p3;

    }
     
    void Update() {

        if (triggerActivated) {

            if (c < pointsNum) {

                float t = c / (float) pointsNum;

                newPosition = CalculateCubicBezierPoint(t);

                ballbody.transform.Rotate(new Vector3(Time.deltaTime*2f,0,0), Space.World);
                ballbody.transform.position = newPosition;
                
                oldPosition = newPosition;

                c += Time.deltaTime*5f;

            }
        }

    }

    public void ActivateTrigger() {

        this.triggerActivated = true;

    }

    
}

