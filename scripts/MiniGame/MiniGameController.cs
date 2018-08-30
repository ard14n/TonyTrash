using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour {

    float smooth = 2f;
    float angleup = -20f;
    float angledown = 20f;
    float angleleft = 20f;
    float angleright = -20f;

    float xforce = 10.0f;
    float zforce = 10.0f;

    private GameObject ball;
    private Rigidbody ballbody;
    private GameObject platform;

    private bool gamePlayed = false;
    private bool platformArrived = false;

    private Camera camera;

	// Use this for initialization
	void Start () {

        ball = GameObject.Find("Kugel");
        ballbody = ball.GetComponent<Rigidbody>();
        ballbody.maxAngularVelocity = 10000f;
        platform = GameObject.Find("PlatformTrigger");
        camera = GameObject.Find("MiniGameCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        
        if(gamePlayed == false && platform.GetComponent<ButtonTrigger>().PlatformArrived()) {

            Debug.Log("Plattform ist oben jetzt gehts los");

            if (Input.GetKey(KeyCode.I))  {
                Debug.Log("Hoch");
                var targetLeft = Quaternion.Euler(0, 0, angleup);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smooth);

            }

            if (Input.GetKey(KeyCode.J)) {

                Debug.Log("Links");
                var targetLeft = Quaternion.Euler(angleleft, 0, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smooth);

            }

            if (Input.GetKey(KeyCode.K)) {

                Debug.Log("Runter");
                var targetLeft = Quaternion.Euler(0, 0, angledown);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smooth);

            }

            if (Input.GetKey(KeyCode.L)) {

                Debug.Log("Rechts");
                var targetLeft = Quaternion.Euler(angleright, 0, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetLeft, Time.deltaTime * smooth);

            }

            var defaultposition = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultposition, Time.deltaTime * smooth);


            camera.enabled = true;
        }

        
        

        

    }
}
