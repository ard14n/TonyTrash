using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater2 : MonoBehaviour
{

    public Floater floater;
    Vector3 current_position;
    float direction = 1.0f; // Hoch oder runter 
    float speed = 2f; //Schnelligkeit
    float heightlimit = 8f; //Limit wie Hoch das Objekt sich bewegen soll
    bool isDown = true;

    void Start()
    {
        floater = GameObject.Find("CubeEnemy").GetComponent<Floater>();
        current_position = this.transform.position;
    }

    public void moveObject()
    {


        transform.Translate(0, direction * (speed * Time.deltaTime), 0);

        if (transform.position.y > current_position.y + heightlimit)
        {


            direction = -1;
            speed = 11f;
        }
        else if (transform.position.y < current_position.y)
        {


            direction = 0;
            isDown = true;


            if (isDown)
            {
                floater.ChangeState();
            }
        }


    }

    public bool ReturnObjectState()
    {
        return isDown;
    }

    public bool ChangeState()
    {
        this.direction = 1;
        this.speed = 2f;
        this.isDown = false;
        return this.isDown;
    }

    void Update()
    {

        if (floater.ReturnObjectState())
        {

            moveObject();
        }


    }


}
