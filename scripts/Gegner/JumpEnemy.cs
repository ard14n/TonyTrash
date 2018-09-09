using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour {

    private int jumpForce;
    private float maxHeight;
    private Vector3 targetPosi;
    private GameObject target;
    private bool inRange;
    private int sightRange;
    private float xdis;
    private float zdis;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
        inRange = false;
        sightRange = 15;
        maxHeight = 8.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.frameCount % 100 == 0){
            Collider[] enemys = Physics.OverlapSphere(transform.position, sightRange);

            foreach (Collider element in enemys)
            {
                if (element.gameObject.tag == "Player")
                {
                    inRange = true;
                    target = element.gameObject;
                }
            }
            if (inRange)
            {
                targetPosi = transform.position - target.transform.position;
                xdis = targetPosi.x;
                zdis = targetPosi.z;

            }

        }

        if (inRange){
            if (Time.frameCount % 100 >= 0 && Time.frameCount % 100 <= 24){
                transform.position = new Vector3(transform.position.x - (xdis / 50), transform.position.y + (maxHeight / 20), transform.position.z - (zdis / 50)); 
            }
            if (Time.frameCount % 100 >= 25 && Time.frameCount % 100 <= 49){
                transform.position = new Vector3(transform.position.x - (xdis / 50), transform.position.y - (maxHeight / 20), transform.position.z - (zdis / 50));
            }
            if (Time.frameCount % 100 == 50){
                inRange = false;
            }
        }


		
	}
}
