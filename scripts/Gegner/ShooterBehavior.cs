using UnityEngine;

public class ShooterBehavior : MonoBehaviour {

    public float range;
    public GameObject ball;
    public float speed;

    void Update () {


        if (Time.frameCount % 5 == 0)
        {
            transform.eulerAngles = new Vector3(0, Time.frameCount/5*2, 0);
        }

        if (Time.frameCount%40==0){
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
            {
                GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
                newBall.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed;
                newBall.AddComponent<DamagePlayer>();
                var destroyTime = 2;
                Destroy(newBall, destroyTime);
            }
        }
    }
}