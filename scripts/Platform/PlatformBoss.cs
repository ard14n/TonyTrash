using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Die Platform wird zum "Parent" des Players, sobald dieser auf der Platform steht. 
 * Somit bewegt sich der Player mit der Platform mit. 
 * Die Platform bewegt sich von einem Startpunkt bis zum Endpunkt. 
 * Am Endpunkt verschwindet die Platform durch Verändern der Transparenz.
 * Josephine Eckhoff
 **/

public class PlatformBoss : MonoBehaviour {

    public GameObject Player;
    public GameObject platform;
    private Vector3 startPos;
    private Vector3 endPos;
    private float smooth = 15f;
    private bool movingToTarget = false;
    private float length;
    private float startTimeMovePlat;
    private float startTimeFade;
    private float duration = 2.0f;
    private bool fadeStart = false;
    private bool fadeBegin = false;



    // Use this for initialization
    void Start () {
        startPos = platform.transform.position;
        endPos = new Vector3(100.0f, 7.0f, 6.0f);
        length = Vector3.Distance(startPos, endPos);

    }
	
	// Update is called once per frame

	void Update () {

        if (movingToTarget == true)
        {
            float distancecovered = (Time.time - startTimeMovePlat) * smooth;
            float fracJourney = distancecovered / length;
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
            fadeStart = true;

        }

        if (platform.transform.position == endPos && fadeStart == true)
        {
            Player.transform.parent = null;
            Destroy(platform, duration);
            startTimeFade = Time.time;
            fadeStart = false;
            fadeBegin = true;
            movingToTarget = false;

        }

        if (fadeBegin == true)
        {
            Player.transform.parent = null;
            Color col = platform.GetComponent<Renderer>().material.color;
            col.a = 1 - ((Time.time - startTimeFade) / duration);
            platform.GetComponent<Renderer>().material.color = col;

        }
           
 
    }

    private void OnTriggerEnter(Collider other)
    {
        //BreakPlatform wird aufgerufen, wenn Player die Platform berührt
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
            movingToTarget = true;
            startTimeMovePlat = Time.time;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
           
        }
    }
}
