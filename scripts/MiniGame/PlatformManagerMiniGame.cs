using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManagerMiniGame : MonoBehaviour {


    
    private GameObject platform;

    private float smooth = 15f;

    private bool triggered = false;

    private Vector3 startposition;
    private Vector3 endposition;
    private float length;
    private float starttime;

    private bool platformArrived = false;

    private bool moveDown = false;
    private bool moveUp = false;
    

    // Use this for initialization
    void Start () {

        endposition = new Vector3(12.48f, 177f, 104f);
        length = Vector3.Distance(startposition, endposition);
        platform = GameObject.Find("Platform");
        startposition = platform.transform.position;
       

    }
	
	// Update is called once per frame
	void Update () {

        MoveUp();
        CheckPlatformArrived();
        MoveDown();

    }

    public bool PlatformArrived() {

        return platformArrived;

    }

    public void MoveDown() {

        if (moveDown) {

            

            Debug.Log("Move Down Funktion wurde aufgerufen");
            DisableCamera();

            startposition = platform.transform.position;
            endposition = new Vector3(12.48f, 1.21f, 104f);
            length = Vector3.Distance(startposition, endposition);
            Debug.Log("Update Move Down");
            starttime = Time.time;

            float distancecovered = (Time.time - starttime) * smooth;
            float fracJourney = distancecovered / length;

            if (fracJourney >= 0) {

                platform.transform.position = Vector3.Lerp(startposition, endposition, fracJourney);

            } else {
                moveDown = false;
                moveUp = false;
            }

        }

    }

    private void DisableCamera() {

        if (GameObject.Find("MiniGameCamera") != null) {

            GameObject.Find("MiniGameCamera").SetActive(false);

        }

    }

    private void MoveUp() {

        if (moveUp) {

            Debug.Log("MoveUp Funktion wurde aufgerufen");
            
            float distancecovered = (Time.time - starttime) * smooth;
            float fracJourney = distancecovered / length;
            platform.transform.position = Vector3.Lerp(startposition, endposition, fracJourney);

        }

    }

    

    public void SetPlatformMoveUp() {

        
        starttime = Time.time;
        this.moveUp = true;

    }

    public void SetPlatformMoveDown() {

        
        this.moveDown = true;

    }

    public void CheckPlatformArrived() {

        if (platform.transform.position == endposition) {

            platformArrived = true;
            

        }
    }
}
