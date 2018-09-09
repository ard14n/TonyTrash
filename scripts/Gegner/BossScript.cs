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
    private int attack;
    public float range;
    public GameObject ball;
    public float speed;
    public int health;
    public int counter;
    public int lastA;
    private float maxHeight;
    private Vector3 targetPosi;
    private float xdis;
    private float zdis;
    private float angle;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
        enemyInRange = false;
        attack = 0;
        counter = 0;
        maxHeight = 20.0f;
        lastA = 0;
    }
	
    void Update ()
    {
        //RaycastHit downR;
        //Ray downRay = new Ray(transform.position, -Vector3.up);
        //Physics.Raycast(downRay, out downR, Mathf.Infinity);
        //float down = downR.distance - 2.5f;
        //transform.position = new Vector3(transform.position.x, transform.position.y - down, transform.position.z);

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
            if (counter == 1){
                if (lastA == 1)
                {
                    attack = Random.Range(2, 5); ;
                    counter = 0;
                }
                else if (lastA == 2)
                {
                    List<int> numbersToChooseFrom = new List<int>(new int[] { 1, 3, 4 });
                    attack = Random.Range(0, numbersToChooseFrom.Count);
                    counter = 0;
                }
                else if (lastA == 3)
                {
                    List<int> numbersToChooseFrom = new List<int>(new int[] { 1, 2, 4 });
                    attack = Random.Range(0, numbersToChooseFrom.Count);
                    counter = 0;
                }
                else if (lastA == 4)
                {
                    attack = Random.Range(1, 4); ;
                    counter = 0;
                }
            }
            else
            {
                attack = Random.Range(1, 5);
                if (attack == lastA){
                    counter++;
                }
            }
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
                lastA = 1;
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
                lastA = 2;
                if (enemyInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 12f * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    if ((Time.frameCount - 150) % 600 == 0){
                        attack = 0;
                    }
                }
                break;

            case 3:
                lastA = 3;

                if (Time.frameCount % 100 == 0)
                {
                    if (enemyInRange)
                    {
                        targetPosi = transform.position - target.transform.position;
                        xdis = targetPosi.x;
                        zdis = targetPosi.z;

                    }
                }

                if (enemyInRange)
                {
                    if (Time.frameCount % 100 >= 0 && Time.frameCount % 100 <= 24)
                    {
                        transform.position = new Vector3(transform.position.x - (xdis / 50), transform.position.y + (maxHeight / 20), transform.position.z - (zdis / 50));
                    }
                    if (Time.frameCount % 100 >= 25 && Time.frameCount % 100 <= 49)
                    {
                        transform.position = new Vector3(transform.position.x - (xdis / 50), transform.position.y - (maxHeight / 20), transform.position.z - (zdis / 50));
                    }
                    if (Time.frameCount % 100 == 50)
                    {
                    enemyInRange = false;
                    }
                }
                break;

            case 4:
                lastA = 4;
                if (enemyInRange)
                {

                    angle = Vector3.Angle(transform.position, target.transform.position);
                    transform.eulerAngles = new Vector3(0, angle, 0);

                    if (Time.frameCount % 50 == 0)
                    {
                        GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
                        newBall.AddComponent<BossFollow>();
                        newBall.AddComponent<DamagePlayer>();
                        var destroyTime = 3;
                        Destroy(newBall, destroyTime);
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