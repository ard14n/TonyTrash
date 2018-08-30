using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {

    private CharacterController controller;
    private Vector3 lookRotation;

    private bool moving;
    private bool enemyInRange;

    public float movementSpeed;
    public float sightRange;
    public float minDistance;
    public float maxDistance;

    public GameObject target;

    void Start () {
        controller = GetComponent<CharacterController> ();
        enemyInRange = false;
    }

    void Update () {

        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit, Mathf.Infinity);
        float down = hit.distance-0.00001f;
        transform.position = new Vector3(transform.position.x, transform.position.y - down, transform.position.z);


        enemyInRange = false;

        Collider[] enemys = Physics.OverlapSphere (transform.position, sightRange);

            foreach(Collider element in enemys)
            {
                if (element.gameObject.tag == "Player") 
                {
                    enemyInRange = true;
                    target = element.gameObject;
                }
            }


        if(enemyInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2f*Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        }

    }

}