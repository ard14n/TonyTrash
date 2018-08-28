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
            transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
        }

    }

}