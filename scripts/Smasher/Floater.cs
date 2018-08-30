using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {


    public Floater2 floater2;

    Vector3 current_position;
    float direction = 1.0f; 	// Hoch oder runter 
    float speed = 2f; 			//Schnelligkeit
    float heightlimit = 8f; 	//Limit wie Hoch das Objekt sich bewegen soll
    bool isDown = false;


    void Start(){
        floater2 = GameObject.Find("CubeEnemy2").GetComponent<Floater2>();
        current_position = this.transform.position;

    }

    public void resetDirection(){
        direction = 1;
    }

    public void moveObject(){

        transform.Translate(0, direction * (speed * Time.deltaTime), 0);

        if (transform.position.y > current_position.y + heightlimit){

            direction = -1;
            speed = 11f;
        }
        else if (transform.position.y < current_position.y){

            direction = 0;
            isDown = true;

            if (isDown){
                floater2.ChangeState();
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

    void Update() {

        if (floater2.ReturnObjectState()){
			
            moveObject();

        }

    }

}
