using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public GameObject orbiter; // GameObject, um welches der Orbit gelegt wird
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OrbitAround(); // Funktion die das Objekt in den Orbit schickt
	}

    void OrbitAround()
    {
        transform.RotateAround(orbiter.transform.position, Vector3.forward, speed * Time.deltaTime);

    }
}
