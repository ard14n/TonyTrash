using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShooter : MonoBehaviour
{

    private bool enemyInRange;
    public float sightRange;
    public GameObject target;
    public GameObject ball;
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

        if (enemyInRange)
        {

            angle = Vector3.Angle(transform.position, target.transform.position);
            transform.eulerAngles = new Vector3(0, angle, 0);

            if (Time.frameCount % 200 == 0)
            {
                GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
                newBall.AddComponent<FollowPlayer>();
                newBall.AddComponent<DamagePlayer>();
                var destroyTime = 3;
                Destroy(newBall, destroyTime);
            }
        }




    }
}
