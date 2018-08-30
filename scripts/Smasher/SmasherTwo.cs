using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherTwo : MonoBehaviour {

    private SmasherOne smasherOne;
    private Vector3 current_position;
    private float direction;                // Hoch oder runter 
    private float speed;                    //Schnelligkeit
    public float heightlimit;               //Limit wie Hoch das Objekt sich bewegen soll
    private bool isDown;
    private bool isActivated;

    void Start() {

        smasherOne = GameObject.Find("SmasherOne").GetComponent<SmasherOne>();
        current_position = this.transform.position;
        isDown = true;
        isActivated = false;
        heightlimit = 8f;
        speed = 2f;
        direction = 1.0f;

    }

    public void moveObject() {

        transform.Translate(0, direction * (speed * Time.deltaTime), 0);

        if (transform.position.y > current_position.y + heightlimit) {

            direction = -1;
            speed = 11f;

        } else if (transform.position.y < current_position.y) {

            direction = 0;
            isDown = true;

            if (isDown) {
                smasherOne.ChangeState();
            }
        }

    }

    public bool ReturnObjectState() {

        return isDown;

    }

    public bool ChangeState() {

        this.direction = 1;
        this.speed = 2f;
        this.isDown = false;
        return this.isDown;

    }

    public void SetActivated() {

        this.isActivated = true;

    }

    void Update() {

        if (smasherOne.ReturnObjectState() && isActivated) {

            moveObject();

        }

    }

}
