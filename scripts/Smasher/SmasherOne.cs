using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherOne : MonoBehaviour {


    private SmasherTwo smasherTwo;
    private Vector3 current_position;
    private float direction;                // Hoch oder runter 
    private float speed;                    //Schnelligkeit
    public float heightlimit;               //Limit wie Hoch das Objekt sich bewegen soll
    private bool isDown;
    private bool isActivated;

    void Start() {

        smasherTwo = GameObject.Find("SmasherTwo").GetComponent<SmasherTwo>();
        current_position = this.transform.position;
        isDown = false;
        isActivated = false;
        heightlimit = 8f;
        speed = 2f;
        direction = 1.0f;
    }

    public void resetDirection() {

        direction = 1;

    }

    public void moveObject() {

        transform.Translate(0, direction * (speed * Time.deltaTime), 0);

        if (transform.position.y > current_position.y + heightlimit) {

            direction = -1;
            speed = 11f;

        } else if (transform.position.y < current_position.y){

            direction = 0;
            isDown = true;

            if (isDown) {

                smasherTwo.ChangeState();

            }

        }

    }

    public bool ChangeState() {
		
        this.direction = 2;
        this.speed = 1f;
        this.isDown = false;
        return this.isDown;
		
    }

    public bool ReturnObjectState() {

        return isDown;

    }

    public void SetActivated() {

        this.isActivated = true;

    }

    void Update() {

        if (smasherTwo.ReturnObjectState() && isActivated) {
			
            moveObject();

        }

    }

}
