using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    private CharacterController controller;
    private Vector3 lookRotation;

    private bool enemyInRange;

    public float movementSpeed;
    public float sightRange;

    public GameObject target;
    public int attack;

    public float range;
    public GameObject ball;
    public float speed;

    public int health;



    void Start ()
    {
        controller = GetComponent<CharacterController>();
        enemyInRange = false;
        attack = 0;

    }
	
    void Update ()
    {

        RaycastHit downR;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out downR, Mathf.Infinity);
        float down = downR.distance - 2.5f;
        transform.position = new Vector3(transform.position.x, transform.position.y - down, transform.position.z);


        enemyInRange = false;

        Collider[] enemys = Physics.OverlapSphere(transform.position, sightRange);

        foreach (Collider element in enemys)
        {
            if (element.gameObject.tag == "Player")
            {
                enemyInRange = true;
                target = element.gameObject;
            }
        }

        if (Time.frameCount%600 == 0){
            attack = Random.Range(1, 3);
        }

        if ((Time.frameCount-300)%600 == 0){
            attack = 0;
        }

        switch(attack){
            case 0:
                if (enemyInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 3f * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                }
                break;


            case 1:
                transform.eulerAngles = new Vector3(0, Time.frameCount*2, 0);
                if (Time.frameCount % 6 == 0)
                {
                    GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
                    newBall.GetComponent<Rigidbody>().velocity = transform.forward.normalized * speed;
                    newBall.AddComponent<DamagePlayer>();
                    var destroyTime = 2;
                    Destroy(newBall, destroyTime);

                } else if((Time.frameCount + 3) % 6 == 0){
                    GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
                    newBall.GetComponent<Rigidbody>().velocity = -transform.forward.normalized * speed;
                    newBall.AddComponent<DamagePlayer>();
                    var destroyTime = 2;
                    Destroy(newBall, destroyTime);
                }
                break;


            case 2:
                if (enemyInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 12f * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    if ((Time.frameCount - 150) % 600 == 0){
                        attack = 0;
                    }
                }
                break;
        }

        if (health <= 0){
            Destroy(GameObject.Find("Boss"));
        }


    }

    public void MinusHealth(){
        health --;
    }



}
