using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectShooter : MonoBehaviour {

    private bool enemyInRange;
    public float sightRange;
    public GameObject target;
    public GameObject ball;
    public float speed;
    private float angle;

    // Use this for initialization
    void Start () {

        enemyInRange = false;

	}
	
	// Update is called once per frame
	void Update () {

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

        if (enemyInRange){

            angle = Vector3.Angle(transform.position, target.transform.position);
            transform.eulerAngles = new Vector3(0, angle, 0);

            if (Time.frameCount % 40 == 0)
            {
                GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
                newBall.GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * speed;
                newBall.AddComponent<DamagePlayer>();
                var destroyTime = 0.8f;
                Destroy(newBall, destroyTime);
            }
        }



    }
}
