using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    private GameObject platform;
    private float smooth = 15f;
    private bool triggered = false;
    private Vector3 startposition;
    private Vector3 endposition;
    private float length;
    private float starttime;
    private bool platformArrived = false;
    private bool moveDown = false;

	void Start () {

        endposition = new Vector3(12.48f, 177f, 104f);
        length = Vector3.Distance(startposition, endposition);
        platform = GameObject.Find("Platform");
        startposition = platform.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (triggered) {

            float distancecovered = (Time.time - starttime) * smooth;
            float fracJourney = distancecovered / length;
            platform.transform.position = Vector3.Lerp(startposition, endposition, fracJourney);

        }

        if( platform.transform.position == endposition) {

            platformArrived = true;
            
        }

        if (moveDown)
        {

            DisableCamera();
            startposition = platform.transform.position;
            endposition = new Vector3(12.48f, 1.21f, 104f);
            length = Vector3.Distance(startposition, endposition);
            Debug.Log("Update Move Down");
            starttime = Time.time;

            float distancecovered = (Time.time - starttime) * smooth;

            float fracJourney = distancecovered / length;

            if(fracJourney >= 0)
            platform.transform.position = Vector3.Lerp(startposition, endposition, fracJourney);


        }

		
	}

    void OnTriggerEnter(Collider other) {

        if(other.tag == "Player") {
            
            Debug.Log("Jetzt geht das MiniGame los");
            triggered = true;
            starttime = Time.time;
            
        }

    }

    public bool PlatformArrived() {

        return platformArrived;

    }

    public void MoveDown() {
        Debug.Log("Move Down Funktion wurde aufgerufen");
        moveDown = true;
    }

    private void DisableCamera()
    {
        if (GameObject.Find("MiniGameCamera") != null){

            GameObject.Find("MiniGameCamera").SetActive(false);

        }

        
    }
    
}
