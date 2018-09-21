using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject target;


	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update () {



        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 5f * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
	}
}
