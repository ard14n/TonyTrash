using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisEnemy : MonoBehaviour {

    private CharacterController controller;
    private bool enemyInRange;
    public float sightRange;
    public GameObject target;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        enemyInRange = false;

        Color col = gameObject.GetComponent<Renderer>().material.color;
        col.a = 0.1f;
        gameObject.GetComponent<Renderer>().material.color = col;
    }

    void Update()
    {

        RaycastHit downR;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out downR, Mathf.Infinity);
        float down = downR.distance - 1f;
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

        if (enemyInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 4f * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float dist = Vector3.Distance(target.transform.position, transform.position);
            if (dist <= 15.0f && dist > 5.0f){
                Color coll = gameObject.GetComponent<Renderer>().material.color;
                coll.a = 0.1f + (15.0f - dist)/10.0f;
                if(coll.a > 1.0f){
                    coll.a = 1.0f;
                }
            gameObject.GetComponent<Renderer>().material.color = coll;
            }
        }
    }
}