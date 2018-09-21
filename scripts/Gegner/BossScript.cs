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
    public GameObject directBall;
    public GameObject followBall;
    public float speed;
    public int health;
    private int counter;
    private int lastA;
    private float maxHeight;
    private Vector3 targetPosi;
    private float xdis;
    private float zdis;
    private int direction;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
        enemyInRange = false;
        attack = 0;
        counter = 0;
        maxHeight = 20.0f;
        lastA = 0;
        RaycastHit downR;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out downR, Mathf.Infinity);
        float down = downR.distance;
        transform.position = new Vector3(transform.position.x, transform.position.y - down, transform.position.z);
        direction = -1;
    }

    void Update ()
    {
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
                    new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 10f * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                }
                break;

            case 1:
                lastA = 1;
                transform.eulerAngles = new Vector3(-90, Time.frameCount*2, 0);
                if (Time.frameCount % 4 == 0)
                {
                    GameObject newBall = Instantiate(directBall, transform.position, transform.rotation) as GameObject;
                    newBall.transform.position = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
                    direction++;
                    switch (direction)
                    {
                        case 0:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1).normalized * speed;
                            break;
                        case 1:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0.5f).normalized * speed;
                            break;
                        case 2:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0).normalized * speed;
                            break;
                        case 3:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -0.5f).normalized * speed;
                            break;
                        case 4:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -1).normalized * speed;
                            break;
                        case 5:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0.5f, 0, -1).normalized * speed;
                            break;
                        case 6:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1).normalized * speed;
                            break;
                        case 7:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-0.5f, 0, -1).normalized * speed;
                            break;
                        case 8:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -1).normalized * speed;
                            break;
                        case 9:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -0.5f).normalized * speed;
                            break;
                        case 10:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0).normalized * speed;
                            break;
                        case 11:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0.5f).normalized * speed;
                            break;
                        case 12:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1).normalized * speed;
                            break;
                        case 13:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-0.5f, 0, 1).normalized * speed;
                            break;
                        case 14:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1).normalized * speed;
                            break;
                        case 15:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0.5f, 0, 1).normalized * speed;
                            direction = -1;
                            break;
                    }
                    newBall.AddComponent<DamagePlayer>();
                    var destroyTime = 2;
                    Destroy(newBall, destroyTime);

                } else if((Time.frameCount + 2) % 4 == 0){
                    GameObject newBall = Instantiate(directBall, transform.position, transform.rotation) as GameObject;
                    newBall.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    switch (direction)
                    {
                        case 0:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -1).normalized * speed;
                            break;
                        case 1:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -0.5f).normalized * speed;
                            break;
                        case 2:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0).normalized * speed;
                            break;
                        case 3:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0.5f).normalized * speed;
                            break;
                        case 4:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1).normalized * speed;
                            break;
                        case 5:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-0.5f, 0, 1).normalized * speed;
                            break;
                        case 6:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1).normalized * speed;
                            break;
                        case 7:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0.5f, 0, 1).normalized * speed;
                            direction = -1;
                            break;
                        case 8:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1).normalized * speed;
                            break;
                        case 9:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0.5f).normalized * speed;
                            break;
                        case 10:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0).normalized * speed;
                            break;
                        case 11:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -0.5f).normalized * speed;
                            break;
                        case 12:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -1).normalized * speed;
                            break;
                        case 13:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0.5f, 0, -1).normalized * speed;
                            break;
                        case 14:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1).normalized * speed;
                            break;
                        case 15:
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(-0.5f, 0, -1).normalized * speed;
                            break;
                    }
                    newBall.AddComponent<DamagePlayer>();
                    var destroyTime = 2;
                    Destroy(newBall, destroyTime);
                }
                enemyInRange = false;
                break;

            case 2:
                lastA = 2;
                if (enemyInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 20f * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    if ((Time.frameCount - 150) % 600 == 0){
                        attack = 0;
                    }
                }
                enemyInRange = false;
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
                enemyInRange = false;
                break;

            case 4:
                lastA = 4;
                if (enemyInRange)
                {
                    if (Time.frameCount % 50 == 0)
                    {
                        GameObject newBall = Instantiate(followBall, transform.position, transform.rotation) as GameObject;
                        newBall.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                        newBall.AddComponent<DamagePlayer>();
                        var destroyTime = 3;
                        Destroy(newBall, destroyTime);
                    }
                }
                enemyInRange = false;
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