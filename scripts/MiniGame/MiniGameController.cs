using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour {

    [Header("Platform Movement")]
    public float smoothness = 2f;

    public float angleup = -20f;
    public float angledown = 20f;
    public float angleleft = 20f;
    public float angleright = -20f;
    
    private GameObject ball;
    private Rigidbody ballbody;
    private GameObject platform;
    private GameObject platformManager;

    
    private bool gamePlayed = false;
    private bool platformArrived = false;
    private bool gameStarted = false;

    private new Camera camera;

	// Use this for initialization
	void Start () {
        
        platform = GameObject.Find("Platform");
        camera = GameObject.Find("MiniGameCamera").GetComponent<Camera>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if(gamePlayed == false && CheckPlatformArrived()) {
            
            StartBuildingMiniGame();
            KeyController();
            DisableCamera();
            
        }

        
    }

    private void StartBuildingMiniGame(){

        Debug.Log("Plattform ist oben jetzt gehts los");
        if (gameStarted == false){

            GameObject.Find("MiniGame").GetComponent<BuildMinigamePlatform>().StartBuilding();
            gameStarted = true;

        }

    }

    private bool CheckPlatformArrived(){

        return platform.GetComponent<PlatformManagerMiniGame>().PlatformArrived() ? true : false;

    }

    private void DisableCamera() {

        camera.enabled = true;

    }

    private void KeyController() {
        

        if(Input.GetAxis("Mouse X") < 20f && Input.GetAxis("Mouse X") > 0f ){

            
            Quaternion target = Quaternion.Euler(angleright, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smoothness);

        }

        if (Input.GetAxis("Mouse X") > -20f && Input.GetAxis("Mouse X") < 0f){

            Quaternion target = Quaternion.Euler(angleleft, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smoothness);

        }

        if (Input.GetAxis("Mouse Y") < 20f && Input.GetAxis("Mouse Y") > 0f) {

           
            Quaternion target = Quaternion.Euler(0f, 0f, angleup);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smoothness);

        }
        if (Input.GetAxis("Mouse Y") > -20f && Input.GetAxis("Mouse Y") < 0f) {

            
            Quaternion target = Quaternion.Euler(0f, 0f, angledown);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smoothness);

        }



        if (Input.GetKey(KeyCode.I)) {

            Debug.Log("Hoch");
            Quaternion target = Quaternion.Euler(0f, 0f, angleup);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smoothness);

        }

        if (Input.GetKey(KeyCode.J)) {

            Debug.Log("Links");
            Quaternion targetLeft = Quaternion.Euler(angleleft, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smoothness);

        }

        if (Input.GetKey(KeyCode.K)) {

            Debug.Log("Runter");
            Quaternion targetLeft = Quaternion.Euler(0f, 0f, angledown);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smoothness);

        }

        if (Input.GetKey(KeyCode.L)) {

            Debug.Log("Rechts");
            Quaternion targetLeft = Quaternion.Euler(angleright, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smoothness);

        }

        Quaternion defaultposition = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, defaultposition, Time.deltaTime * 0.001f);


    }

    public void SetMiniGameWon() {
        
        GameObject.Find("Platform").GetComponent<PlatformManagerMiniGame>().SetPlatformMoveDown();
        GameObject.Find("LevelOneManager").GetComponent<LevelOneManager>().SetMiniGameCompleted();
        gamePlayed = true;
        
    }
}
